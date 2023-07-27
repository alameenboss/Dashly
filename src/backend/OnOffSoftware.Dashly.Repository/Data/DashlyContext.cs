using OnOffSoftware.Dashly.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnOffSoftware.Dashly.Repository.Data
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
        #endregion


        #region "Authentication"
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region "Notes"
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteCategory> NoteCategories { get; set; }
        #endregion

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

 

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

            modelBuilder.Entity<User>()
                 .HasQueryFilter(x => x.IsActive == true)
                 .ToTable("User");

            modelBuilder.Entity<Role>()
                .HasQueryFilter(x => x.IsActive == true)
                .ToTable("Role");
        }
    }
}