using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using Dashly.API.Repositories.Data.Entity;
using Microsoft.Extensions.Configuration;
using Dashly.API.Models.Github;
using Dashly.API.Repositories.Data.Entity.Notes;
using Dashly.API.Feature.Documents.Models;
using Dashly.API.Feature.OAuthIntegrations.Models;

namespace Dashly.API.Repositories.Data
{
    public class DashlyContext : DbContext
    {
        private readonly IConfiguration Configuration;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=DashlyDB.db;");

            var dataSource = Path.Combine(Configuration["AppConfig:DbPath"], "DashlyDB.db");
            optionsBuilder
                .UseSqlite($"Data Source={dataSource};");
        }

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
        }
    }
}