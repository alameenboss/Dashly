using Dashly.API.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashly.API.Data.Entity
{
    public class PostgresDbContext : DashlyContext
    {
        public PostgresDbContext(IConfiguration configuration): base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection"));
        }
    }
}
