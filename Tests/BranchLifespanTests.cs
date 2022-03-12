using Xunit;
using Newtonsoft.Json;
using System.IO;
using github_branch_lifetime.Data;
using System.Collections.Generic;

namespace BranchLifeSpanTests;

public class BranchLifeSpanTests
{
    [Fact]
    public void TestCommitDataModel()
    {
        var json = GetJsonFile(@".\CommitData.json");

        var result = JsonConvert.DeserializeObject<List<Commits>>(json);     

        Assert.NotNull(json);
        Assert.NotNull(result); 
        Assert.True(result?.Count > 0);
        Assert.NotEmpty(result?[0].Commit.Message);       
    }

    [Fact]
    public void TestPRDataModel()
    {
        var json = GetJsonFile(@".\PRData.json");

        var result = JsonConvert.DeserializeObject<List<PullRequest>>(json);     

        Assert.NotNull(json);
        Assert.NotNull(result); 
        Assert.True(result?.Count > 0);
        Assert.NotEmpty(result?[0].Head.Ref);       
    }

    private string GetJsonFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}