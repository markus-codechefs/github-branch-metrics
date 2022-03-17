namespace github_branch_lifetime.Data;
public class BranchViewModel
{
    public BranchViewModel()
    {
        Branches = new List<Branch>();
    }

    public List<Branch> Branches { get; set; }
    public double AverageLifespanInDaysTotal { get; set; }    
    public int AverageCommits { get; set; }
    public int AverageAdditions { get; set; }
    public int AverageDeletions { get; set; }
    public int AverageChangedFiles { get; set; }
}
