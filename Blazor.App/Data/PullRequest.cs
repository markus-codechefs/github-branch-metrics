using System.Text.Json.Serialization;

namespace github_branch_lifetime.Data;

public class PullRequest
{
    public PullRequest()
    {
        Head = new Head();
    }
    public int Id { get; set; }
    public int Number { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("merged_at")]
    public DateTime? MergedAt { get; set; }
    public Head Head { get; set; }
    public bool Draft { get; set; }
}