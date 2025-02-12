using Microsoft.EntityFrameworkCore;

namespace aspnet_webapi_efcore6;

/// <summary>
/// The data context for the application.
/// </summary>
public class AppDataContext : DbContext
{ 
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
        
    }
}