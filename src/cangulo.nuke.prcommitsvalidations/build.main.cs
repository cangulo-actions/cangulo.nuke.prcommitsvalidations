using cangulo.nuke.prcommitsvalidations.Parsers;
using cangulo.nuke.prcommitsvalidations.Services;
using Nuke.Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

internal partial class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.ValidatePRCommits);

    private Target ValidatePRCommits => _ => _
        .Executes(async () =>
        {
            ParseSettings();

            var prService = new PullRequestService();
            var ghClient = GetGHClient(GitHubActions);
            var commitMsgs = await prService.GetCommitsFromCurrentPR(ghClient, GitHubActions);
            //var commitMsgs = new string[] { "feat:wip-123bla bla", "feat:WIP-123bla bla", "Fix:WiP-133bla bla" };

            ControlFlow.Assert(commitMsgs.Any(), "no commits founds");

            var commits = commitMsgs.ToList();

            Logger.Info($"{commits.Count} commits found:");
            commits
                .ForEach(Logger.Info);

            ControlFlow.NotEmpty(
                ValidationSettings.ConventionalCommitTypes,
                "Please provide the conventional commit settings");
            EnsureCommitsFollowConventions(commits, ValidationSettings.ConventionalCommitTypes);

            var regex = ValidationSettings.CommitMsgRegexValidator;
            if (!string.IsNullOrEmpty(regex))
                ValidateCommitsBody(commits, regex);

            if (ValidationSettings.OutputCommitList)
            {
                File.WriteAllLines(ValidationSettings.OutputCommitListPath, commitMsgs);
                Logger.Success($"Commits listed in the file: {ValidationSettings.OutputCommitListPath}");
            }
        });
    private static void EnsureCommitsFollowConventions(List<string> commits, string[] commitTypesAllowed)
    {

        var commitParser = new CommitParser();

        var conventionalCommits = commits
            .Select(
                comMsg => commitParser.ParseConventionalCommit(comMsg, commitTypesAllowed))
            .ToList();

        Logger
            .Success($"Found the next {conventionalCommits.Count} conventional commits:");
        conventionalCommits
            .ForEach(Logger.Info);
    }

    private static void ValidateCommitsBody(List<string> commits, string regexValidator)
    {
        commits.ForEach(x =>
        {
            var issueProvided = Regex.IsMatch(x, regexValidator, RegexOptions.IgnoreCase);
            ControlFlow.Assert(issueProvided, $"issue number not provided for the commit {issueProvided}");
        });
        Logger.Success("All commit bodies are valid");
    }
}
