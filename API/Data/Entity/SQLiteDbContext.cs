using Dashly.API.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
