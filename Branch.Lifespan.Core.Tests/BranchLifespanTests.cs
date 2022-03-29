using Xunit;
using Branch.Lifespan.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Branch.Lifespan.Core.Tests;

public class BranchLifespanCoreTests
{
    private readonly ApiSettings ApiSettings = new ApiSettings();

    [Fact]
    public async Task TestGetStatistics()
    {
        var settings = new ApiSettings { ApiKey = "", UserAgent="Markus-Trachsel", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        IRepositoryBranchStatisticService statisticsService = new RepositoryBranchStatisticService(settings);

        var result = await statisticsService.GetStatistics();

        Assert.NotNull(result);
        Assert.NotEmpty(result.BranchesConsideredInStatistic = "1");
        Assert.True(result.Repositories.Count==1);        
    }

    [Fact]
    public void TestGetStatisticsWithWrongApiKey()
    {
        var settings = new ApiSettings { ApiKey = "1", UserAgent="Markus-Trachsel", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        IRepositoryBranchStatisticService statisticsService = new RepositoryBranchStatisticService(settings);
        
        var result = Assert.ThrowsAsync<InvalidOperationException>(async () => await statisticsService.GetStatistics());
    }

    [Fact]
    public void TestGetStatisticsWithNoApiKey()
    {
        var settings = new ApiSettings { ApiKey = "", UserAgent="Markus-Trachsel", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        IRepositoryBranchStatisticService statisticsService = new RepositoryBranchStatisticService(settings);
        
        var result = Assert.ThrowsAsync<InvalidOperationException>(async () => await statisticsService.GetStatistics());
    }

    [Fact]
    public void TestGetStatisticsWithNoApiKeyAndNoUserAgent()
    {
        var settings = new ApiSettings { ApiKey = "", UserAgent="", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        IRepositoryBranchStatisticService statisticsService = new RepositoryBranchStatisticService(settings);
        
        var result = Assert.ThrowsAsync<InvalidOperationException>(async () => await statisticsService.GetStatistics());
    }

    [Fact]
    public void TestGetStatisticsWithNoBaseAddress()
    {
        var settings = new ApiSettings { ApiKey = "123456", UserAgent="Markus-Trachsel", BaseAddress = "", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        var result = Assert.Throws<ArgumentNullException>(() =>  new RepositoryBranchStatisticService(settings));
    }

    [Fact]
    public void TestGetStatisticsWithNoOrganisation()
    {
        var settings = new ApiSettings { ApiKey = "123456", UserAgent="Markus-Trachsel", BaseAddress = "https://api.github.com/repos/", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        var result = Assert.Throws<ArgumentNullException>(() =>  new RepositoryBranchStatisticService(settings));
    }

    [Fact]
    public void TestGetStatisticsWithNoRepo()
    {
        var settings = new ApiSettings { ApiKey = "123456", UserAgent="Markus-Trachsel", BaseAddress = "https://api.github.com/repos/",Organisation = "markus-codechefs", PageSizePerRepo = "2" };

        var result = Assert.Throws<ArgumentException>(() =>  new RepositoryBranchStatisticService(settings));
    }
}