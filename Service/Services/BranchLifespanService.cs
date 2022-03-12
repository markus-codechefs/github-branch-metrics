using Newtonsoft.Json;
using RestSharp;

namespace github_branch_lifetime.Data;

public class BranchLifespanService
{   
    public async Task<DataViewModel> GetCurrentBranchLifespan()
    {
        //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(data.json);
        var client = new RestClient("https://api.github.com");
        
        var request = new RestRequest("/markus-codechefs/github-branch-lifetime/pulls");
        request.AddHeader("accept", " application/vnd.github.v3+json");

        var prResponse = await client.GetAsync<List<PullRequest>>(request);

        request = new RestRequest("/markus-codechefs/github-branch-lifetime/pulls/5/commits");        

        var commitResponse = await client.GetAsync<Commits>(request);

        if(prResponse != null && commitResponse != null)
        {
            DataViewModel model = new DataViewModel(){PullRequests = prResponse, Commits = commitResponse};
        }        
        
        return new DataViewModel();
    }
}
