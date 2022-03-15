namespace github_branch_lifetime.Data;
public class BranchViewModel
{
    public BranchViewModel()
    {
        Branches = new List<Branch>();
    }

    public List<Branch> Branches { get; set; }
    public double AverageBranchLifespanInDaysTotal { get; set; }
    public double AverageBranchLifespanInDaysLast3Months { get; set; }    
}
