using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OthelloAPI
{
    public class OthelloContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public OthelloContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("OthelloConnection"));
        }
    }
}
