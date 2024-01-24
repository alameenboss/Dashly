using OnOffSoftware.Dashly.Common;
using OnOffSoftware.Dashly.Repository.Data;
using OnOffSoftware.Dashly.Repository.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Text;

namespace OnOffSoftware.Dashly.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }



        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddAutoMapper(typeof(Startup));
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //JWT Authentication -- Start
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //JWT Authentication -- End

            switch (Configuration["DatabaseProvider"])
            {
                case "MsSql":
                    services.AddDbContext<DashlyContext, MsSqlDbContext>();
                    break;

                case "SQLite":
                    services.AddEntityFrameworkSqlite().AddDbContext<DashlyContext, SQLiteDbContext>();
                    break;

                case "PostgreSql":
                    services.AddDbContext<DashlyContext, PostgresDbContext>();
                    break;
            }

            services.RegisterServices();

            services.AddImports();

            services.AddMvc();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "Webapp System API";
                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("ApiKey"));
                // Add custom document processors, etc.
                //API Key open api config
                config.DocumentProcessors.Add(new SecurityDefinitionAppender("ApiKey", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "ApiKey",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Add your Api Key"
                }));

                config.OperationProcessors.Add(new OperationSecurityScopeProcessor("Bearer"));
                config.DocumentProcessors.Add(new SecurityDefinitionAppender("Bearer", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "JWT Authorization header using the bearer scheme"
                }));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Configuration["AppConfig:FilesStoragePath"]),
                RequestPath = new PathString("/Files")
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}