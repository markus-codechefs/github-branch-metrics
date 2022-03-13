namespace github_branch_lifetime.Data;

public class BranchLifespanService
{
    public async Task<BranchViewModel> GetCurrentBranchLifespan()
    {
        const string BASE_ADDRESS = "https://api.github.com";
        const string PULLS = "repos/markus-codechefs/github-branch-lifetime/pulls";
        const string COMMITS = "repos/markus-codechefs/github-branch-lifetime/pulls/5/commits";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(BASE_ADDRESS);
        client.DefaultRequestHeaders.Add("User-Agent", "markus-codechefs");

        var prResponse = await client.GetFromJsonAsync<List<PullRequest>>(PULLS);

        if (prResponse == null && prResponse.Count > 0) return new BranchViewModel();

        var commitResponse = await client.GetFromJsonAsync<List<Commits>>(COMMITS);

        if (commitResponse == null && commitResponse.Count > 0) return new BranchViewModel();

        return CreateBranchViewModel(prResponse, commitResponse);
    }

    private BranchViewModel CreateBranchViewModel(List<PullRequest> prData, List<Commits> commitData)
    {
        List<Branch> branches = new List<Branch>();
        foreach (var pr in prData)
        {
            Branch branch = new Branch { Name = pr.Head.Ref, MergedAt = pr.MergedAt };
            branches.Add(branch);
        }
        return new BranchViewModel { Branches = branches };
    }
}
