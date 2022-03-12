using Xunit;
using Newtonsoft.Json;
using System.IO;
using github_branch_lifetime.Data;

namespace BranchLifeSpanTests;

public class UnitTest1
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