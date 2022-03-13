namespace github_branch_lifetime.Data;
public class Branch
{
    public DateTime CreatedAt { get; set; }
    public DateTime MergedAt { get; set; }
    public DateTime Name { get; set; }
    public DateTime NrOfCommits { get; set; }
    public DateTime NrOfLinesChanged { get; set; }
}