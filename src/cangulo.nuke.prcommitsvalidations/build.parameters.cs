using cangulo.nuke.prcommitsvalidations.Models;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Git;
using Nuke.Common.IO;

internal partial class Build : NukeBuild
{

    [Parameter]
    public AbsolutePath ValidationSettingsPath { get; } = RootDirectory / "prCommitValidationSettings.json";

    private ValidationSettings ValidationSettings;

    [GitRepository]
    private readonly GitRepository GitRepository;

    [Parameter("GitHub auth token", Name = "github-token"), Secret]
    private readonly string GitHubToken;

    [CI]
    private readonly GitHubActions GitHubActions;
}