using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.Persistence.Entry;
using Template.Infrastructure.Persistence.Mapping;

namespace Template.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<UserMenu> UserMenu { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);
    }
}