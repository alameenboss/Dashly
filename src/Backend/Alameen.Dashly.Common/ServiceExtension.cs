using Alameen.Dashly.Common.Helpers;
using Alameen.Dashly.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Alameen.Dashly.Common
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