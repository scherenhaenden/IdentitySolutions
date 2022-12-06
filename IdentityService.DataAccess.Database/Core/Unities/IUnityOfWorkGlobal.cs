using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Database.Core.Unities;

public interface IUnityOfWorkGlobal : IDisposable
{
    public IRepository<GlobalUser> GlobalUsers { get; set; }
    
    public IRepository<GlobalAddress> GlobalAddresses { get; set; }
    
    public IRepository<GlobalRole> GlobalRoles { get; set; }
    
    public bool Save();

}