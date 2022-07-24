using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SixMinApi.Models;

namespace SixMinApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Command> Commands => Set<Command>();
}
