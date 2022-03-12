using Xunit;
using Newtonsoft.Json;
using System.IO;
using github_branch_lifetime.Data;
using System.Collections.Generic;

namespace BranchLifeSpanTests;

public class BranchLifeSpanTests
{
    [Fact]
    public void SimplePassingTest()
    {
        var json = GetJsonFile();

        var result = JsonConvert.DeserializeObject<List<PullRequest>>(json);     

        Assert.NotNull(json);
        Assert.NotNull(result); 
        Assert.True(result.Count > 0);
        Assert.NotEmpty(result[0].Head.Ref);       
    }

    private string GetJsonFile()
    {
        return File.ReadAllText(@".\data.json");
    }
}