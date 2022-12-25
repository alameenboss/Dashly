using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Alameen.Dashly.Repository.Data
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