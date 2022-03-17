namespace github_branch_lifetime.Data;
public class RepositoryViewModel
{
    public RepositoryViewModel()
    {
        Repositories = new List<Repositories>();
    }

    public List<Repositories> Repositories { get; set; }
}

public class Repositories
{
    public Repositories()
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
