using Microsoft.EntityFrameworkCore;
using Template.Infrastructure.Persistence.Entry.Module.General;
using Template.Infrastructure.Persistence.Entry.Module.Registration;
using Template.Infrastructure.Persistence.Mapping.Module.Registration;

namespace Template.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<UserMenu> UserMenu { get; set; }
    public DbSet<EmailConfiguration> EmailConfiguration { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).Assembly);
    }
}