using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistance.Configuration;
using IdentityService.DataAccess.Database.Persistance.Domain;
using IdentityService.DataAccess.Database.Persistance.Repositories;

namespace IdentityService.DataAccess.Database.Persistance.Unities;

public class UnitOfWork: IUnitOfWork
{
    private IdentityContext _context;
    
    public UnitOfWork(IdentityContext context)
    {
        _context = context;
        Claims = InitObjects<Claim>();
        LoginInformation = InitObjects<LoginInformation>();
        LoginType = InitObjects<LoginType>();
        Organization = InitObjects<Organization>();
        Role = InitObjects<Role>();
        ScopeCompact = InitObjects<ScopeCompact>();
        User = InitObjects<User>();
        UserCompact = InitObjects<UserCompact>();
        
        
    }
    
    private  IRepository<T> InitObjects<T>()  where T : BaseEntity
    {
        return  new Repository<T>(_context);
    }

    public IRepository<Claim> Claims { get; set; }
    public IRepository<LoginInformation> LoginInformation { get; set; }
    public IRepository<LoginType> LoginType { get; set; }
    public IRepository<Organization> Organization { get; set; }
    public IRepository<Role> Role { get; set; }
    public IRepository<ScopeCompact> ScopeCompact { get; set; }
    public IRepository<User> User { get; set; }
    public IRepository<UserCompact> UserCompact { get; set; }
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

