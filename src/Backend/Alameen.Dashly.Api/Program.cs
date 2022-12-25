using Alameen.Dashly.Repository.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace Alameen.Dashly.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = CreateHostBuilder(args).Build();

                //using (var scope = host.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;
                //    var context = scope.ServiceProvider.GetService<DashlyContext>();
                //    DataSeeder.SeedWebapps(context);
                //}
                IWebHostEnvironment env = host.Services.GetRequiredService<IWebHostEnvironment>();
                var config = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables()
                        .Build();

                Log.Logger = new LoggerConfiguration()
                            .ReadFrom
                            .Configuration(config)
                            .CreateLogger();

                Log.Information("Starting host...");

                var filesStoragePath = config["AppConfig:FilesStoragePath"];
                if (!Directory.Exists(filesStoragePath))
                {
                    Directory.CreateDirectory(filesStoragePath);
                }

                ApplyDBMigration(config);

                host.Run();


            }
            catch (System.Exception ex)
            {

                Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static void ApplyDBMigration(IConfigurationRoot configuration)
        {
            switch (configuration["DatabaseProvider"])
            {
                case "MsSql":
                    using (var client = new MsSqlDbContext(configuration))
                        client.Database.Migrate();
                    break;

                case "SQLite":
                    using (var client = new SQLiteDbContext(configuration))
                        client.Database.Migrate();
                    break;

                case "PostgreSql":
                    //
                    break;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog() // Uses Serilog instead of default .NET Logger
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}