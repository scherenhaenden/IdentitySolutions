using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Core.Configuration
{
    public interface IContextGlobal
    {
        // Add all the fields from the name space IdentityService.DataAccess.Database.Core.Domain
        
        // Add Dbset for SystemlUser
        public DbSet<SystemlUser> GlobalUsers { get; set; }
    
        // Add Dbset for SystemAddress
        public DbSet<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for GlobalRole
        public DbSet<GlobalRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public DbSet<GlobalClaim> GlobalUserClaims { get; set; }

    }
}