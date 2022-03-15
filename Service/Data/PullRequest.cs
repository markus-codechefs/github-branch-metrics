using System.Text.Json.Serialization;

namespace github_branch_lifetime.Data;

public class PullRequest
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string State { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("closed_at")]
    public DateTime ClosedAt { get; set; }

    [JsonPropertyName("merged_at")]
    public DateTime? MergedAt { get; set; }
    public Head Head { get; set; }
    public bool Draft { get; set; }
}