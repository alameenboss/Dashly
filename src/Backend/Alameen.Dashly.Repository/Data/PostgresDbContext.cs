using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Alameen.Dashly.Repository.Data
{
    public class PostgresDbContext : DashlyContext
    {
        public PostgresDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnection"));
        }
    }
}