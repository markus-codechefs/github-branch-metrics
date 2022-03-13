using RestSharp;

namespace github_branch_lifetime.Data;

public class BranchLifespanService
{   
    public async Task<BranchViewModel> GetCurrentBranchLifespan()
    {
        var client = new RestClient("https://api.github.com");
        
        var request = new RestRequest("/repos/octocat/hello-world/pulls");
        request.AddHeader("accept", " application/vnd.github.v3+json");

        var prResponse = await client.ExecuteGetAsync<PullRequest>(request);

        if(!prResponse.IsSuccessful) return new BranchViewModel(); 

        request = new RestRequest("/markus-codechefs/github-branch-lifetime/pulls/5/commits");        

        var commitResponse = await client.ExecuteGetAsync<Commits>(request);
        
        if(!commitResponse.IsSuccessful) return new BranchViewModel(); 
        
        if(prResponse?.Data != null && commitResponse?.Data != null)
        {
            return CreateBranchViewModel(prResponse.Data, commitResponse.Data);
        }        
        
        return new BranchViewModel();
    }

    private BranchViewModel CreateBranchViewModel(PullRequest prData, Commits commitData)
    {
        return new BranchViewModel();    
    }
}
