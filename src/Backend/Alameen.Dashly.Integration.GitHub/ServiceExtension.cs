using Dashly.API.Feature.Github.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dashly.API
{
    public static class ServiceExtension
    {
        public static void AddGitHubIntegration(this IServiceCollection services)
        {
            services.AddScoped<IGithubService, GithubService>();
        }
    }
}