using Xunit;
using Branch.Lifespan.Core.Model;
using System.Collections.Generic;

namespace Branch.Lifespan.Core.Tests;

public class BranchLifespanCoreTests
{
    private readonly ApiSettings ApiSettings = new ApiSettings();

    [Fact]
    public void TestApiSettings()
    {
        var settings = new ApiSettings { ApiKey = "1", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" },  PageSizePerRepo = "2" };

        Assert.NotNull(settings);
        Assert.NotEmpty(settings.ApiKey);
        Assert.NotEmpty(settings.Organisation);
        Assert.False(settings.Repositories.Count == 0);
        Assert.NotEmpty(settings.BaseAddress);
    }
}