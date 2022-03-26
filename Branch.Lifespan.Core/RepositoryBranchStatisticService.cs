using Branch.Lifespan.Core.Model;

namespace Branch.Lifespan.Core;
public class RepositoryBranchStatisticService : IRepositoryBranchStatisticService
{
    public RepositoryModel GetStatistics(ApiSettings settings)
    {
        return new RepositoryModel{BranchesConsideredInStatistic="1",Repositories = new List<Repository>{new Repository{Name = "Test"}}};
    }
}
