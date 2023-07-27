using OnOffSoftware.Dashly.Common.Helpers;
using OnOffSoftware.Dashly.Core;
using Microsoft.Extensions.DependencyInjection;

namespace OnOffSoftware.Dashly.Common
{
    public static class ServiceExtension
    {
        public static void AddImports(this IServiceCollection services)
        {
            services.AddScoped<IDataImport<Webapp>, ImportWebapp>();
            services.AddScoped<IDataImport<Note>, ImportNote>();
        }
    }
}