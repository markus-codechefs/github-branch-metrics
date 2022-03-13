namespace github_branch_lifetime.Data;
public class Branch
{
    public DateTime CreatedAt { get; set; }
    public DateTime MergedAt { get; set; }
    public string Name { get; set; }
    public int NrOfCommits { get; set; }
    public int NrOfLinesChanged { get; set; }
}