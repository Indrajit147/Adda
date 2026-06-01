using AddaApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AddaApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

             
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
