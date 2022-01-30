using Dashly.API.Feature.Bookmarks.Data.Entity;
using Dashly.API.Feature.Contacts.Data.Entity;
using Dashly.API.Feature.Documents.Data.Entity;
using Dashly.API.Feature.Github.Data.Entity;
using Dashly.API.Feature.Notes.Data.Entity;
using Dashly.API.Feature.OAuthIntegrations.Data.Entity;
using Dashly.API.Feature.UserManagement.Data.Entity;
using Dashly.API.Feature.WebApps.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dashly.API.Data.Entity
{
    public abstract class DashlyContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DashlyContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region "Apps"
        public DbSet<Webapp> Webapps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        #endregion

        #region "Projetcs"
        public DbSet<GitHubRepo> GitHubRepos { get; set; }
        #endregion

        #region "Authentication"
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region "Notes"
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }
        #endregion

        #region "Documents"
        public DbSet<Document> Documents { get; set; }
        #endregion

        #region "Bookmarks"
        public DbSet<Bookmark> Bookmarks { get; set; }
        #endregion

        #region "Contacts"
        public DbSet<Contact> Contacts { get; set; }
        #endregion

        #region "OAuthIntegrations"
        public DbSet<OAuthIntegration> OAuthIntegrations { get; set; }
        #endregion

        //protected void ApplyConfiguration(ModelBuilder modelBuilder, string[] namespaces)
        //{
        //    var methodInfo = (typeof(ModelBuilder).GetMethods()).Single((e =>
        //        e.Name == "ApplyConfiguration" &&
        //        e.ContainsGenericParameters &&
        //        e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        //    foreach (var configType in typeof(DashlyContext).GetTypeInfo().Assembly.GetTypes()

        //        .Where(t => t.Namespace != null &&
        //                    namespaces.Any(n => n == t.Namespace) &&
        //                    t.GetInterfaces().Any(i => i.IsGenericType &&
        //                                               i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))))
        //    {
        //        var type = configType.GetInterfaces().First();
        //        methodInfo.MakeGenericMethod(type.GenericTypeArguments[0]).Invoke(modelBuilder, new[]
        //        {
        //    Activator.CreateInstance(configType)
        //});
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteCategory>()
            .ToTable("NoteCategory");

            modelBuilder.Entity<NoteCategory>()
               .HasMany(x => x.Notes)
               .WithOne(t => t.Category)
               .HasForeignKey(t => t.NoteCategoryId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoteCategory>()
                .HasMany(x => x.Categories);

            modelBuilder.Entity<Note>()
                        .ToTable("Note");

            modelBuilder.Entity<Webapp>()
                .HasQueryFilter(x => x.IsActive == true);

            modelBuilder.Entity<Webapp>()
               .ToTable("Webapp");

            modelBuilder.Entity<Webapp>()
              .HasMany(x => x.Attachments)
              .WithOne(x => x.Webapp)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Webapp>()
              .HasMany(x => x.Tags)
              .WithOne(x => x.Webapp)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tag>()
                .HasQueryFilter(x => x.IsActive == true)
                .ToTable("Tag");

            modelBuilder.Entity<Attachment>()
               .HasQueryFilter(x => x.IsActive == true)
               .ToTable("Attachment");

            modelBuilder.Entity<GitHubRepo>()
                .ToTable("GitHubRepo");

            modelBuilder.Entity<User>()
                 .HasQueryFilter(x => x.IsActive == true)
                 .ToTable("User");

            modelBuilder.Entity<Role>()
                .HasQueryFilter(x => x.IsActive == true)
                .ToTable("Role");

            modelBuilder.Entity<Contact>();
        }
    }
}