using Dashly.API.Feature.Contacts;
using Dashly.API.Feature.Contacts.Data.Entity;
using Dashly.API.Feature.DataImport;
using Dashly.API.Feature.Notes;
using Dashly.API.Feature.Notes.Data.Entity;
using Dashly.API.Feature.WebApps;
using Dashly.API.Feature.WebApps.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Dashly.API
{
    public static class ServiceExtension
    {
        public static void AddImports(this IServiceCollection services)
        {
            services.AddScoped<IDataImport<Webapp>, ImportWebapp>();
            services.AddScoped<IDataImport<Note>, ImportNote>();
            services.AddScoped<IDataImport<Contact>, ImportContact>();
        }
    }
}