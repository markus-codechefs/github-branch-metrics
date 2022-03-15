using System.Text.Json.Serialization;

namespace github_branch_lifetime.Data;

public class PullRequestDetails
{
    public int Comments { get; set; }
    public int ReviewComments { get; set; }
    public int Commits { get; set; }
    public int Additions { get; set; }
    public int Deletions { get; set; }
    [JsonPropertyName("changed_files")]
    public int ChangedFiles { get; set; }
}
