using IdentityService.DataAccess.Database.Core.Repositories;
using IdentityService.DataAccess.Database.Persistence.Domain;

namespace IdentityService.DataAccess.Database.Core.Unities;

public interface IUnitOfWorkTenant: IDisposable
{
    public IRepository<UserClaim> Claims { get; set; }
    public IRepository<LoginInformation> LoginInformation { get; set; }

    public IRepository<LoginType> LoginType { get; set; }

    public IRepository<Organization> Organization { get; set; }

    public IRepository<Role> Role { get; set; }

    public IRepository<User> User { get; set; }

    public bool Save();
}