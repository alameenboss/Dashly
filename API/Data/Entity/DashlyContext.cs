using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Dashly.API.Repositories.Data.Entity;
using Microsoft.Extensions.Configuration;
using Dashly.API.Models.Github;
using Dashly.API.Repositories.Data.Entity.Notes;
using Dashly.API.Feature.Documents.Models;
using Dashly.API.Feature.OAuthIntegrations.Models;
using Dashly.API.Feature.Contacts.Models;
using System.Reflection;
using System.Linq;

namespace Dashly.API.Repositories.Data
{
    public abstract class DashlyContext : DbContext
    {
        protected  readonly IConfiguration Configuration;
        public DashlyContext(IConfiguration configuration)
        {
           Configuration = configuration;
        }

        public DbSet<Webapp> Webapps { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<GitHubRepo> GitHubRepos { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }

        public DbSet<Document> Documents { get; set; }


        public DbSet<OAuthIntegration> OAuthIntegrations { get; set; }

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