using Newtonsoft.Json;
using RestSharp;

namespace github_branch_lifetime.Data;

public class BranchLifespanService
{   
    public async Task<List<Root>> GetCurrentBranchLifespan()
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data.json);
        var client = new RestClient("https://api.github.com/repos/octocat/hello-world/pulls");
        var request = new RestRequest();
        request.AddHeader("accept", " application/vnd.github.v3+json");

        var response = await client.GetAsync<List<Root>>(request);

        if(response != null) 
        {
            return response;
        }
        
        return new List<Root>();        
    }
}
