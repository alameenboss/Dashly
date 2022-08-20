using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dashly.API.Data.Entity
{
    public class MsSqlDbContext : DashlyContext
    {
        public MsSqlDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MsSqlConnection"));
        }
    }
}