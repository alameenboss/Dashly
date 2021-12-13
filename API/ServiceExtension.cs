using Microsoft.Extensions.DependencyInjection;
using Dashly.API.Repositories;
using Dashly.API.Repositories.Interface;
using Dashly.API.Services;
using Dashly.API.ConnectedServices.GitHub;
using Dashly.API.Feature.Documents.Data;
using Dashly.API.Feature.OAuthIntegrations.Data;

namespace Dashly.API.Helpers
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IContextResolver, ContextResolver>();
            services.AddScoped<IWebappRepository, WebappRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGithubService, GithubService>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteCategoryRepository, NoteCategoryRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            services.AddScoped<IOAuthRepository, OAuthRepository>();
        }
    }
}