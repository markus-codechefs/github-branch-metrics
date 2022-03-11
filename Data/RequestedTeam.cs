namespace github_branch_lifetime.Data{ 

    public class RequestedTeam
    {
        public int Id { get; set; }
        public string NodeId { get; set; }
        public string Url { get; set; }
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Privacy { get; set; }
        public string Permission { get; set; }
        public string MembersUrl { get; set; }
        public string RepositoriesUrl { get; set; }
        public object Parent { get; set; }
    }

}