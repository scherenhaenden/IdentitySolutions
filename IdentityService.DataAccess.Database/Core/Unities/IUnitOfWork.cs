using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Persistance.Domain;

namespace IdentityService.DataAccess.Database.Core.Unities;

public interface IUnitOfWork: IDisposable
{
    public IRepository<Claim> Claims { get; set; }
    public IRepository<LoginInformation> LoginInformation { get; set; }

    public IRepository<LoginType> LoginType { get; set; }

    public IRepository<Organization> Organization { get; set; }

    public IRepository<Role> Role { get; set; }

    public IRepository<ScopeCompact> ScopeCompact { get; set; }

    public IRepository<User> User { get; set; }

    public IRepository<UserCompact> UserCompact { get; set; }
    
    public bool Save();
}