using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<User> User { get; set; }
    }
}

