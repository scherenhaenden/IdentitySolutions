using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistance.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistance.Configuration;

public class IdentityContext : DbContext, IContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    public DbSet<Claim> Claims { get; set; } = null!;
    public DbSet<LoginInformation> LoginInformation { get; set; } = null!;
    public DbSet<LoginType> LoginType { get; set; } = null!;
    public DbSet<Organization> Organization { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;
    public DbSet<ScopeCompact> ScopeCompact { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
    public DbSet<UserCompact> UserCompact { get; set; } = null!;
}