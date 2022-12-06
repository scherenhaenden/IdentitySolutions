using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant;

public interface ILoginType: IBaseEntity
{
    public string TypeString { get; set; }
    public string Description { get; set; }
}