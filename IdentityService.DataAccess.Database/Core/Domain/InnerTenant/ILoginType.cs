using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain.InnerTenant;

public interface ILoginType: IBaseEntity
{
    public string TypeString { get; set; }
    public string Description { get; set; }
}