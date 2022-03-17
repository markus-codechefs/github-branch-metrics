namespace github_branch_lifetime.Data;
public class Branch
{
     public Branch()
    {
        Name = "";
    }

    public DateTime CreatedAt { get; set; }
    public DateTime MergedAt { get; set; }
    public string Name { get; set; }   
    public double AgeInDays { get; set; }   
    public int CommitCount { get; set; }
    public int Additions { get; set; }
    public int Deletions { get; set; }
    public int ChangedFiles { get; set; }
}