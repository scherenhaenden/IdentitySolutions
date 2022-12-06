using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant;

public interface IUserClaim: IBaseEntity
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}