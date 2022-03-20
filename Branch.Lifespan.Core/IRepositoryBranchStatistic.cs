using Branch.Lifespan.Core.Model;

namespace Branch.Lifespan.Core;

public interface IRepositoryBranchStatistic
{
    RepositoryModel GetStatistics(ApiSettings settings);
}