namespace Branch.Lifespan.Core.Model;
public class Commits
{
    public Commits()
    {
        Commit = new Commit();
    }
    public Commit Commit { get; set; }    
}
