using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain;
using IdentityService.DataAccess.Database.Persistence.Domain.Tenant;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Configuration;

public class IdentityContext : DbContext, IContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
        try
        {
            base.Database.EnsureCreated();   
        }catch(Exception ex)
        {
            
        }
        finally{}
        
    }

    public DbSet<UserClaim> Claims { get; set; } = null!;
    public DbSet<LoginInformation> LoginInformation { get; set; } = null!;
    public DbSet<LoginType> LoginType { get; set; } = null!;
    public DbSet<Organization> Organization { get; set; } = null!;
    public DbSet<Role> Role { get; set; } = null!;
    public DbSet<User> User { get; set; } = null!;
}