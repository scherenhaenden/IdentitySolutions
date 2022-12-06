using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Repositories;

namespace IdentityService.DataAccess.Database.Persistence.Unities;

public class UnitOfWorkGlobal : IUnityOfWorkGlobal
{
    
    private readonly IdentityContextGlobal _context;
    
    public UnitOfWorkGlobal(IdentityContextGlobal context)
    {
        _context = context;
        GlobalUsers = InitObjects<GlobalUser>();
    }
    
    private  IRepository<T> InitObjects<T>()  where T : BaseEntity, IBaseEntity
    {
        return  new Repository<T>(_context);
    }

    
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public IRepository<GlobalUser> GlobalUsers { get; set; }
    public bool Save()
    {
        var result = _context.SaveChanges();
        return true;
    }

}