using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6.Data
{
    public class AppDbContext : DbContext
    {
        // Add a constructor that takes DbContextOptions<AppDbContext> as a parameter 
        // and call base constructor with the options
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> User { get; set; }
    }
}

