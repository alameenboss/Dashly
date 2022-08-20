using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dashly.API.Data.Entity
{
    public class SQLiteDbContext : DashlyContext
    {
        public SQLiteDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=DashlyDB.db;");
            //var dataSource = Path.Combine(Configuration["AppConfig:DbPath"], "DashlyDB.db");
            //optionsBuilder.UseSqlite($"Data Source={dataSource};");

            optionsBuilder.UseSqlite(Configuration.GetConnectionString("SQLiteConnection"));
        }
    }
}