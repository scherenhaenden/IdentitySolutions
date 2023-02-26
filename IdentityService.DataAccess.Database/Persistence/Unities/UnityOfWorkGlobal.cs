using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Repositories;

namespace IdentityService.DataAccess.Database.Persistence.Unities
{
    public class UnityOfWorkGlobal : IUnityOfWorkGlobal
    {
    
        private readonly IdentityContextGlobal _context;
    
        public UnityOfWorkGlobal(IdentityContextGlobal context)
        {
            _context = context;
            GlobalUsers = InitObjects<SystemUser>();
            GlobalAddresses = InitObjects<SystemAddress>();
            GlobalRoles = InitObjects<SystemRole>();
            GlobalUserClaims = InitObjects<SystemClaim>();
        }
    
        private  IRepository<T> InitObjects<T>()  where T : BaseEntity, IBaseEntity
        {
            return  new Repository<T>(_context);
        }

    
    
        public void Dispose()
        {
            _context.Dispose();
        }

        // Add Dbset for SystemUser
        public IRepository<SystemUser> GlobalUsers { get; set; }
        
        // Add Dbset for SystemAddress
        public IRepository<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for SystemRole
        public IRepository<SystemRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public IRepository<SystemClaim> GlobalUserClaims { get; set; }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return true;
        }

    }
}