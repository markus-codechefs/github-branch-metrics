using Xunit;
using Newtonsoft.Json;
using System.IO;
using github_branch_lifetime.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;

namespace BranchLifeSpanTests;

public class BranchLifeSpanTests
{
    private readonly ApiSettings ApiSettings = new ApiSettings();

    [Fact]
    public void TestCommitDataModel()
    {
        var json = GetJsonFile(@"CommitData.json");

        var result = JsonConvert.DeserializeObject<List<Commits>>(json);

        Assert.NotNull(json);
        Assert.NotNull(result);
        Assert.True(result?.Count > 0);
        Assert.NotEmpty(result?[0].Commit.Message);
    }

    [Fact]
    public void TestPRDataModel()
    {
        var json = GetJsonFile(@"PRData.json");

        var result = JsonConvert.DeserializeObject<List<PullRequest>>(json);

        Assert.NotNull(json);
        Assert.NotNull(result);
        Assert.True(result?.Count > 0);
        Assert.NotEmpty(result?[0].Head.Ref);
    }

    [Fact]
    public async Task TestBranchLifespanService()
    {
        var apiSettingsOption = Options.Create(new ApiSettings
        {
            ApiKey = "",
            BaseAddress = "https://api.github.com/repos/",
            Organisation = "markus-codechefs",
            Repositories = new List<string>() { "github-branch-lifetime" }
        });

        BranchLifespanService service = new BranchLifespanService(apiSettingsOption);

        var data = await service.GetCurrentBranchLifespan();

        Assert.NotNull(data);
    }

    [Fact]
    public async Task TestGithubApiWithHttpClientAndPullRequests()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://api.github.com");
        client.DefaultRequestHeaders.Add("User-Agent", "markus-codechefs");
        var response = await client.GetFromJsonAsync<List<PullRequest>>("repos/markus-codechefs/github-branch-lifetime/pulls?state=all&base=master");

        Assert.NotNull(response);
        Assert.True(response?.Count > 0);
    }

    [Fact]
    public async Task TestGithubApiWithHttpClientAndCommits()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("https://api.github.com");
        client.DefaultRequestHeaders.Add("User-Agent", "markus-codechefs");
        var response = await client.GetFromJsonAsync<List<Commits>>("repos/markus-codechefs/github-branch-lifetime/pulls/5/commits");

        Assert.NotNull(response);
        Assert.True(response?.Count > 0);
    }

    [Fact]
    public void TestStringFormatting()
    {
        Branch branch = new Branch { AgeInDays = 0.00061073073073 };

        var result = branch.AgeInDays.ToString("0.####");

        Assert.NotEmpty(result);
        Assert.NotNull(result);
        Assert.Equal("0.0006", result);
    }

    [Fact]
    public void TestApiSettings()
    {
        var settings = new ApiSettings { ApiKey = "1", BaseAddress = "https://api.github.com/repos/", Organisation = "markus-codechefs", Repositories = new List<string>() { "github-branch-lifetime" } };

        Assert.NotNull(settings);
        Assert.NotEmpty(settings.ApiKey);
        Assert.NotEmpty(settings.Organisation);
        Assert.False(settings.Repositories.Count == 0);
        Assert.NotEmpty(settings.BaseAddress);
    }


    private string GetJsonFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}