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

        if (prResponse == null || prResponse?.Count == 0) return new BranchViewModel();

        return await CreateBranchViewModel(client, prResponse);
    }

    private async Task<BranchViewModel> CreateBranchViewModel(HttpClient client, List<PullRequest> prData)
    {
        string COMMITS = "repos/markus-codechefs/github-branch-lifetime/pulls/{0}/commits";
        string PR = "repos/markus-codechefs/github-branch-lifetime/pulls/{0}";
        List<Branch> branches = new List<Branch>();

        foreach (var pr in prData)
        {
            if (pr.Draft || !pr.MergedAt.HasValue || pr.MergedAt.Equals(DateTime.MinValue)) continue;
            
            Branch branch = new Branch { Name = pr.Head.Ref, MergedAt = pr.MergedAt.Value };
            branches.Add(branch);

            var branchCommits = string.Format(COMMITS, pr.Number);            
            var commitResponse = await client.GetFromJsonAsync<List<Commits>>(branchCommits);

            if (commitResponse == null || commitResponse?.Count == 0) continue;            

            var oldestCommit = commitResponse?.OrderBy(c => c.Commit.Committer.Date).FirstOrDefault();

            if (oldestCommit != null)
            {
                branch.CreatedAt = oldestCommit.Commit.Committer.Date;
            }

            branch.AgeInDays = (branch.MergedAt - branch.CreatedAt).TotalDays;

            var prDetails = string.Format(PR, pr.Number);
            var prDetailsResponse = await client.GetFromJsonAsync<PullRequestDetails>(prDetails);

            if(prDetailsResponse == null) continue; 

            branch.NrOfCommits = prDetailsResponse.Commits;
            branch.Additions = prDetailsResponse.Additions;
            branch.Deletions = prDetailsResponse.Deletions;
            branch.ChangedFiles = prDetailsResponse.ChangedFiles;            
        }

        return new BranchViewModel { Branches = branches };
    }
}
