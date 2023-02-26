using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Core.Configuration
{
    public interface IContextGlobal
    {
        // Add all the fields from the name space IdentityService.DataAccess.Database.Core.Domain
        
        // Add Dbset for SystemUser
        public DbSet<SystemUser> GlobalUsers { get; set; }
    
        // Add Dbset for SystemAddress
        public DbSet<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for SystemRole
        public DbSet<SystemRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public DbSet<SystemClaim> GlobalUserClaims { get; set; }

    }
}