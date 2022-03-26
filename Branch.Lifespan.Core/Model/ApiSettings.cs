namespace Branch.Lifespan.Core.Model;
public class ApiSettings
{
    public ApiSettings()
    {
        ApiKey = "";
        UserAgent = "";
        Organisation = "";
        BaseAddress = "";
        PageSizePerRepo = "";
        Repositories = new List<string>();
    }

    public string ApiKey { get; set; }
    public string UserAgent { get; set; }
    public string Organisation { get; set; }
    public string BaseAddress { get; set; }
    public List<string> Repositories { get; set; }
    public string PageSizePerRepo { get; set; }
}