using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Repositories;

namespace IdentityService.DataAccess.Database.Persistence.Unities
{
    public class UnitOfWorkGlobal : IUnityOfWorkGlobal
    {
    
        private readonly IdentityContextGlobal _context;
    
        public UnitOfWorkGlobal(IdentityContextGlobal context)
        {
            _context = context;
            GlobalUsers = InitObjects<GlobalUser>();
            GlobalAddresses = InitObjects<SystemAddress>();
            GlobalRoles = InitObjects<GlobalRole>();
            GlobalUserClaims = InitObjects<GlobalClaim>();
        }
    
        private  IRepository<T> InitObjects<T>()  where T : BaseEntity, IBaseEntity
        {
            return  new Repository<T>(_context);
        }

    
    
        public void Dispose()
        {
            _context.Dispose();
        }

        // Add Dbset for GlobalUser
        public IRepository<GlobalUser> GlobalUsers { get; set; }
        
        // Add Dbset for SystemAddress
        public IRepository<SystemAddress> GlobalAddresses { get; set; }
        
        // Add Dbset for GlobalRole
        public IRepository<GlobalRole> GlobalRoles { get; set; }
        
        // Add Dbset for GlobalUserClaim
        public IRepository<GlobalClaim> GlobalUserClaims { get; set; }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return true;
        }

    }
}