using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Repository.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Alameen.Dashly.Repository.Extension
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
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IOAuthRepository, OAuthRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IBoardRepository, BoardRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICallRecordingRepository,CallRecordingRepository>();
        }
    }
}