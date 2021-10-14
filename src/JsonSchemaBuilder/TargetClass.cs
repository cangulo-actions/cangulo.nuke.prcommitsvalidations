using System.ComponentModel.DataAnnotations;

namespace JsonSchemaBuilder
{
    public class TargetClassToCreateSchema
    {
        public string[] ConventionalCommitTypes { get; set; }
        public string CommitMsgRegexValidator { get; set; }
        public bool OutputCommitList { get; set; }
        public string OutputCommitListPath { get; set; } = "commits.txt";
    }
}
