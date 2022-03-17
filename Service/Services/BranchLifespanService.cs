using Microsoft.Extensions.Options;

namespace github_branch_lifetime.Data;

public class BranchLifespanService
{
    private readonly ApiSettings ApiSettings;

    public BranchLifespanService(IOptions<ApiSettings> apiSettings)
    {
        this.ApiSettings = apiSettings.Value;
    }

    public async Task<RepositoryViewModel?> GetCurrentBranchLifespan()
    {
        string PULLS = $"{ApiSettings.Organisation}/{ApiSettings.Repositories[0]}/pulls?state=all&base=master";

        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(ApiSettings.BaseAddress);
        client.DefaultRequestHeaders.Add("User-Agent", "Markus Trachsel");

        if (!string.IsNullOrEmpty(ApiSettings.ApiKey)) client.DefaultRequestHeaders.Add("Authorization", "Bearer " + ApiSettings.ApiKey);

        var prResponse = await client.GetFromJsonAsync<List<PullRequest>>(PULLS);

        if (prResponse == null || prResponse?.Count == 0) return new RepositoryViewModel();

        return await CreateRepositoryViewModel(client, prResponse);
    }

    private async Task<RepositoryViewModel> CreateRepositoryViewModel(HttpClient client, List<PullRequest>? prData)
    {
        if (prData == null) return new RepositoryViewModel();

        List<Branch> branches = new List<Branch>();

        foreach (var pr in prData)
        {
            if (pr.Draft || !pr.MergedAt.HasValue || pr.MergedAt.Equals(DateTime.MinValue)) continue;

            string COMMITS = $"{ApiSettings.Organisation}/{ApiSettings.Repositories[0]}/pulls/{pr.Number}/commits";
            string PRDetails = $"{ApiSettings.Organisation}/{ApiSettings.Repositories[0]}/pulls/{pr.Number}";

            Branch branch = new Branch { Name = pr.Head.Ref, MergedAt = pr.MergedAt.Value };
            branches.Add(branch);

            var commitResponse = await client.GetFromJsonAsync<List<Commits>>(COMMITS);

            if (commitResponse == null || commitResponse?.Count == 0) continue;

            var oldestCommit = commitResponse?.OrderBy(c => c.Commit.Committer.Date).FirstOrDefault();

            if (oldestCommit != null)
            {
                branch.CreatedAt = oldestCommit.Commit.Committer.Date;
            }

            branch.AgeInDays = (branch.MergedAt - branch.CreatedAt).TotalDays;

            var prDetailsResponse = await client.GetFromJsonAsync<PullRequestDetails>(PRDetails);

            if (prDetailsResponse == null) continue;

            branch.CommitCount = prDetailsResponse.Commits;
            branch.Additions = prDetailsResponse.Additions;
            branch.Deletions = prDetailsResponse.Deletions;
            branch.ChangedFiles = prDetailsResponse.ChangedFiles;
        }

        return new RepositoryViewModel
        {
            Repositories = new List<Repositories>
            {
                new Repositories
                {
                    Branches = branches, 
                    AverageLifespanInDaysTotal = branches.Average(x => x.AgeInDays),
                    AverageAdditions = branches.Average(x=>x.Additions),
                    AverageDeletions = branches.Average(x=>x.Deletions),
                    AverageCommits = branches.Average(x=>x.CommitCount),
                    AverageChangedFiles = branches.Average(x=>x.ChangedFiles)
                }
            }
        };
    }
}
