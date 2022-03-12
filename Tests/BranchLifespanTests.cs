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

        var result = JsonConvert.DeserializeObject<List<Root>>(json);     

        Assert.NotNull(json);
        Assert.NotNull(result);        
    }

    private string GetJsonFile()
    {
        return File.ReadAllText(@".\data.json");
    }
}