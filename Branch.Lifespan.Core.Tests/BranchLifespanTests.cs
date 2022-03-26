using Xunit;
using Branch.Lifespan.Core.Model;
using System.Collections.Generic;

namespace Branch.Lifespan.Core.Tests;

public class BranchLifespanCoreTests
{
    private readonly ApiSettings ApiSettings = new ApiSettings();

    [Fact]
    public void TestGetStatistics()
    {
        var settings = new ApiSettings { ApiKey = "1", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        IRepositoryBranchStatisticService statisticsService = new RepositoryBranchStatisticService();

        var result = statisticsService.GetStatistics(settings);

        Assert.NotNull(result);
        Assert.NotEmpty(result.BranchesConsideredInStatistic = "1");
        Assert.True(result.Repositories.Count==1);        
    }
}