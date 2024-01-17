using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OthelloAPI
{
    public class OthelloContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private readonly IConfiguration Configuration;

        public OthelloContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("OthelloConnection"));
        }
    }
}
