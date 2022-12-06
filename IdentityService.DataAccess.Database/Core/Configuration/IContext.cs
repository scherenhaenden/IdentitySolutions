using IdentityService.DataAccess.Database.Persistence.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Core.Configuration;

public interface IContext
{
    // Add all the fields from the name space IdentityService.DataAccess.Database.Core.Domain
    public DbSet<UserClaim> Claims { get; set; }
    public DbSet<LoginInformation> LoginInformation { get; set; }
    
    public DbSet<LoginType> LoginType { get; set; }
    
    public DbSet<Organization> Organization { get; set; }
    
    public DbSet<Role> Role { get; set; }

    public DbSet<User> User { get; set; }
}