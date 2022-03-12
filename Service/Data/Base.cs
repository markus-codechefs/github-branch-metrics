namespace github_branch_lifetime.Data{ 

    public class Base
    {
        public string Label { get; set; }
        public string Ref { get; set; }
        public string Sha { get; set; }
        public User User { get; set; }
        public Repo Repo { get; set; }
    }

}