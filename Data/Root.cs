using System.Collections.Generic;
using System;
namespace github_branch_lifetime.Data;

public class Root
{
    public string Url { get; set; }
    public int Id { get; set; }
    public string NodeId { get; set; }
    public string HtmlUrl { get; set; }
    public string DiffUrl { get; set; }
    public string PatchUrl { get; set; }
    public string IssueUrl { get; set; }
    public string CommitsUrl { get; set; }
    public string ReviewCommentsUrl { get; set; }
    public string ReviewCommentUrl { get; set; }
    public string CommentsUrl { get; set; }
    public string StatusesUrl { get; set; }
    public int Number { get; set; }
    public string State { get; set; }
    public bool Locked { get; set; }
    public string Title { get; set; }
    public User User { get; set; }
    public string Body { get; set; }
    public List<Label> Labels { get; set; }
    public Milestone Milestone { get; set; }
    public string ActiveLockReason { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime ClosedAt { get; set; }
    public DateTime MergedAt { get; set; }
    public string MergeCommitSha { get; set; }
    public Assignee Assignee { get; set; }
    public List<Assignee> Assignees { get; set; }
    public List<RequestedReviewer> RequestedReviewers { get; set; }
    public List<RequestedTeam> RequestedTeams { get; set; }
    public Head Head { get; set; }
    public Base Base { get; set; }
    public Links Links { get; set; }
    public string AuthorAssociation { get; set; }
    public object AutoMerge { get; set; }
    public bool Draft { get; set; }
}