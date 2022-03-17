using github_branch_lifetime.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BranchLifetimeExtension
    {
        public static IServiceCollection AddBranchlifetimeConnector(this IServiceCollection services, IConfiguration config)
        {
            if (config != null)
            {
                services.AddOptions();
                services.Configure<ApiSettings>(config.GetSection("ApiSettings"));
            }

            services.AddSingleton<BranchLifespanService>();

            return services;
        }
    }
}