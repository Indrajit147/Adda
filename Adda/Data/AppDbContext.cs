using Microsoft.EntityFrameworkCore;

namespace Adda.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

             
        }

        public DbSet<Models.Post> Posts { get; set; }
    }
}
