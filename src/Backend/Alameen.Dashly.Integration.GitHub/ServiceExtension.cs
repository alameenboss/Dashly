using Microsoft.Extensions.DependencyInjection;

namespace Alameen.Dashly.Integration.GitHub
{
    public static class ServiceExtension
    {
        public static void AddGitHubIntegration(this IServiceCollection services)
        {
            services.AddScoped<IGithubService, GithubService>();
        }
    }
}