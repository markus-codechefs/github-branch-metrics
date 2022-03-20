namespace github_branch_lifetime.Data;
public class RepositoriesViewModel
{
    public RepositoriesViewModel()
    {
        Repositories = new List<Repository>();
        BranchesConsideredInStatistic = "";
    }

    public List<Repository> Repositories { get; set; }
    public string BranchesConsideredInStatistic { get; set; }
}

public class Repository
{
    public Repository()
    {
        Name = "";
        Branches = new List<Branch>();
    }

    public string Name { get; set; }
    public List<Branch> Branches { get; set; }
    public double AverageLifespanInDaysTotal { get; set; }
    public double AverageCommits { get; set; }
    public double AverageAdditions { get; set; }
    public double AverageDeletions { get; set; }
    public double AverageChangedFiles { get; set; }
}
