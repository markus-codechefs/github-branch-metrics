namespace github_branch_lifetime.Data;
public class BranchViewModel
{
    public BranchViewModel()
    {
        Branches = new List<Branch>();
    }

    public List<Branch> Branches { get; set; }
    public decimal AverageBranchLifespanInDaysTotal { get; set; }
    public decimal AverageBranchLifespanInDaysLast3Months { get; set; }    
}
