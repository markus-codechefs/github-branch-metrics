using Branch.Lifespan.Core.Model;

namespace Branch.Lifespan.Core;

public interface IRepositoryBranchStatisticService
{
    Task<RepositoryModel> GetStatistics();
}