namespace github_branch_lifetime.Data{ 

    public class Links
    {
        public Self Self { get; set; }
        public Html Html { get; set; }
        public Issue Issue { get; set; }
        public Comments Comments { get; set; }
        public ReviewComments ReviewComments { get; set; }
        public ReviewComment ReviewComment { get; set; }
        public Commits Commits { get; set; }
        public Statuses Statuses { get; set; }
    }

}