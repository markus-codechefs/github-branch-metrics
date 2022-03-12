namespace github_branch_lifetime.Data;

public class PullRequest
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string State { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public DateTime MergedAt { get; set; }
    public Head Head { get; set; }
    public bool Draft { get; set; }
}