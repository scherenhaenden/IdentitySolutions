using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain;
using IdentityService.DataAccess.Database.Persistence.Domain.Tenant;
using IdentityService.DataAccess.Database.Persistence.Repositories;

namespace IdentityService.DataAccess.Database.Persistence.Unities
{
    public class UnitOfWorkTenant: IUnitOfWorkTenant
    {
        private readonly IdentityContext _context;
    
        public UnitOfWorkTenant(IdentityContext context)
        {
            _context = context;
            Claims = InitObjects<UserClaim>();
            LoginInformation = InitObjects<LoginInformation>();
            LoginType = InitObjects<LoginType>();
            Organization = InitObjects<Organization>();
            Role = InitObjects<Role>();
            User = InitObjects<User>();
        }
    
        private  IRepository<T> InitObjects<T>()  where T : BaseEntity
        {
            return  new Repository<T>(_context);
        }

        public IRepository<UserClaim> Claims { get; set; }
        public IRepository<LoginInformation> LoginInformation { get; set; }
        public IRepository<LoginType> LoginType { get; set; }
        public IRepository<Organization> Organization { get; set; }
        public IRepository<Role> Role { get; set; }
        public IRepository<User> User { get; set; }
        public bool Save()
        {
            var result = _context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

