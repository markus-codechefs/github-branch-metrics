namespace github_branch_lifetime.Data;
public class Commit
{
    public Commit()
    {
        Committer = new Committer();
        Message = "";
    }
    public Committer Committer { get; set; }
    public string Message { get; set; }
}
