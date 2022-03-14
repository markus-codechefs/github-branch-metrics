namespace github_branch_lifetime.Data;

public class BranchLifespanService
{
    public async Task<BranchViewModel> GetCurrentBranchLifespan()
    {
        const string BASE_ADDRESS = "https://api.github.com";
        const string PULLS = "repos/markus-codechefs/github-branch-lifetime/pulls?state=all&base=master";
        

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_ADDRESS);
        client.DefaultRequestHeaders.Add("User-Agent", "markus-codechefs");

        var prResponse = await client.GetFromJsonAsync<List<PullRequest>>(PULLS);

        if (prResponse == null && prResponse.Count > 0) return new BranchViewModel();

        return await CreateBranchViewModel(client, prResponse);
    }

    private async Task<BranchViewModel> CreateBranchViewModel(HttpClient client, List<PullRequest> prData)
    {
        string COMMITS = "repos/markus-codechefs/github-branch-lifetime/pulls/{0}/commits";
        List<Branch> branches = new List<Branch>();
        
        foreach (var pr in prData)
        {
            if(pr.MergedAt.Equals(DateTime.MinValue)) continue;

            var branchCommits = string.Format(COMMITS, pr.Number);
            var commitResponse = await client.GetFromJsonAsync<List<Commits>>(branchCommits);
            
            if(commitResponse == null || commitResponse?.Count == 0) continue;

            Branch branch = new Branch { Name = pr.Head.Ref, MergedAt = pr.MergedAt };
            branch.CreatedAt = commitResponse.OrderBy(c=>c.Commit.Committer.Date).FirstOrDefault().Commit.Committer.Date;
            branch.NrOfCommits = commitResponse.Count;
            branches.Add(branch);
        }
        return new BranchViewModel { Branches = branches };
    }
}
