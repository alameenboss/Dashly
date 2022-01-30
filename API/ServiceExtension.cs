using Dashly.API.Feature.Bookmarks.Data;
using Dashly.API.Feature.Documents.Data;
using Dashly.API.Feature.Github.Services;
using Dashly.API.Feature.Notes.Data.Repository;
using Dashly.API.Feature.OAuthIntegrations.Data;
using Dashly.API.Feature.UserManagement.Services;
using Dashly.API.Feature.WebApps.Data.Repository;
using Dashly.API.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Dashly.API
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


            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
        }
    }
}