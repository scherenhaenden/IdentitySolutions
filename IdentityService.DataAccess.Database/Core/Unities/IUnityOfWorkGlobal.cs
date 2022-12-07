using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Database.Core.Unities
{
    public interface IUnityOfWorkGlobal : IDisposable
    {
        // Add Dbset for GlobalUser
        public IRepository<GlobalUser> GlobalUsers { get; set; }
        
        // Add Dbset for SystemAddress
        public IRepository<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for GlobalRole
        public IRepository<GlobalRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public IRepository<GlobalClaim> GlobalUserClaims { get; set; }
    
        public bool Save();

    }
}