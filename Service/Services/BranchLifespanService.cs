using RestSharp;

namespace github_branch_lifetime.Data;

public class BranchLifespanService
{   
    public async Task<DataViewModel> GetCurrentBranchLifespan()
    {
        var client = new RestClient("https://api.github.com");
        
        var request = new RestRequest("/markus-codechefs/github-branch-lifetime/pulls");
        request.AddHeader("accept", " application/vnd.github.v3+json");

        var prResponse = await client.ExecuteGetAsync<PullRequest>(request);

        if(!prResponse.IsSuccessful) return new DataViewModel(); 

        request = new RestRequest("/markus-codechefs/github-branch-lifetime/pulls/5/commits");        

        var commitResponse = await client.ExecuteGetAsync<Commits>(request);
        
        if(!commitResponse.IsSuccessful) return new DataViewModel(); 
        
        if(prResponse != null && commitResponse != null)
        {
            DataViewModel model = new DataViewModel(){Commits = commitResponse.Data};
        }        
        
        return new DataViewModel();
    }
}
