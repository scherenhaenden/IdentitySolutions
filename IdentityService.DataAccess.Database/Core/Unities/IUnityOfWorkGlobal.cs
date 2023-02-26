using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Database.Core.Unities
{
    public interface IUnityOfWorkGlobal : IDisposable
    {
        // Add Dbset for SystemUser
        public IRepository<SystemUser> GlobalUsers { get; set; }
        
        // Add Dbset for SystemAddress
        public IRepository<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for SystemRole
        public IRepository<SystemRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public IRepository<SystemClaim> GlobalUserClaims { get; set; }
    
        public bool Save();

    }
}