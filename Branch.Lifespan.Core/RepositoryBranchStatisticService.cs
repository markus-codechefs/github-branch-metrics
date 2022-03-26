using System.Net.Http.Json;
using Branch.Lifespan.Core.Model;

namespace Branch.Lifespan.Core;
public class RepositoryBranchStatisticService : IRepositoryBranchStatisticService
{
    private HttpClient Client {get; set;}
    private ApiSettings ApiSettings {get; set;}

    public RepositoryBranchStatisticService(ApiSettings settings)
    {
        this.Client = new HttpClient();
        this.ApiSettings = settings;
        if (settings is null) throw new ArgumentNullException(nameof(this.ApiSettings));
        if (string.IsNullOrWhiteSpace(this.ApiSettings.BaseAddress)) throw new ArgumentNullException(nameof(this.ApiSettings.BaseAddress));
        if (string.IsNullOrWhiteSpace(this.ApiSettings.Organisation)) throw new ArgumentNullException(nameof(this.ApiSettings.Organisation));        
        if (this.ApiSettings.Repositories.Count == 0) throw new ArgumentException(nameof(this.ApiSettings.Repositories.Count) + " must be larger than zero.");        
        if (string.IsNullOrWhiteSpace(this.ApiSettings.PageSizePerRepo)) this.ApiSettings.PageSizePerRepo = "30";

        InitializeHttpClient();
    }

    public async Task<RepositoryModel> GetStatistics()
    {  
        var model = new RepositoryModel();       

        foreach (var repo in this.ApiSettings.Repositories)
        {
            string PULLS = $"{this.ApiSettings.Organisation}/{repo}/pulls?state=closed&base=master&per_page={this.ApiSettings.PageSizePerRepo}";                       

            var prResponse = await this.Client.GetFromJsonAsync<List<PullRequest>>(PULLS);

            if (prResponse == null || prResponse?.Count == 0) return new RepositoryModel();

            var repository = await CreateRepositoryModel(prResponse);
            repository.Name = repo;

            model.Repositories.Add(repository);
        }

        return model;
    }

    private async Task<Repository> CreateRepositoryModel(List<PullRequest>? prData)
    {
        if (prData == null) return new Repository();

        List<Branch.Lifespan.Core.Model.Branch> branches = new List<Branch.Lifespan.Core.Model.Branch>();

        foreach (var pr in prData)
        {
            if (pr.Draft || !pr.MergedAt.HasValue || pr.MergedAt.Equals(DateTime.MinValue)) continue;

            string COMMITS = $"{this.ApiSettings.Organisation}/{this.ApiSettings.Repositories[0]}/pulls/{pr.Number}/commits";
            string PRDetails = $"{this.ApiSettings.Organisation}/{this.ApiSettings.Repositories[0]}/pulls/{pr.Number}";

            Branch.Lifespan.Core.Model.Branch branch = new Branch.Lifespan.Core.Model.Branch { Name = pr.Head.Ref, MergedAt = pr.MergedAt.Value };

            branches.Add(branch);

            var commitResponse = await this.Client.GetFromJsonAsync<List<Commits>>(COMMITS);

            if (commitResponse == null || commitResponse?.Count == 0) continue;

            var oldestCommit = commitResponse?.OrderBy(c => c.Commit.Committer.Date).FirstOrDefault();

            if (oldestCommit != null)
            {
                branch.CreatedAt = oldestCommit.Commit.Committer.Date;
            }

            branch.AgeInDays = (branch.MergedAt - branch.CreatedAt).TotalDays;

            var prDetailsResponse = await this.Client.GetFromJsonAsync<PullRequestDetails>(PRDetails);

            if (prDetailsResponse == null) continue;

            branch.CommitCount = prDetailsResponse.Commits;
            branch.Additions = prDetailsResponse.Additions;
            branch.Deletions = prDetailsResponse.Deletions;
            branch.ChangedFiles = prDetailsResponse.ChangedFiles;
        }

        return new Repository
        {
            Branches = branches,
            AverageLifespanInDaysTotal = branches.Average(x => x.AgeInDays),
            AverageAdditions = branches.Average(x => x.Additions),
            AverageDeletions = branches.Average(x => x.Deletions),
            AverageCommits = branches.Average(x => x.CommitCount),
            AverageChangedFiles = branches.Average(x => x.ChangedFiles)
        };
    }

    private void InitializeHttpClient()
    {
        this.Client.BaseAddress = new Uri(this.ApiSettings.BaseAddress);
        if (!string.IsNullOrEmpty(this.ApiSettings.UserAgent)) this.Client.DefaultRequestHeaders.Add("User-Agent", this.ApiSettings.UserAgent);        
        if (!string.IsNullOrEmpty(this.ApiSettings.ApiKey)) this.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.ApiSettings.ApiKey);
    }
}
