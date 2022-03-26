using Branch.Lifespan.Core.Model;

namespace Branch.Lifespan.Core;

public interface IRepositoryBranchStatisticService
{
    RepositoryModel GetStatistics(ApiSettings settings);
}