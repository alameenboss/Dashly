using OnOffSoftware.Dashly.Common.Helpers;
using OnOffSoftware.Dashly.Repository.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace OnOffSoftware.Dashly.Repository.Extension
{
    public static class ServiceExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IContextResolver, ContextResolver>();
            services.AddScoped<IWebappRepository, WebappRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteCategoryRepository, NoteCategoryRepository>();
        }
    }
}