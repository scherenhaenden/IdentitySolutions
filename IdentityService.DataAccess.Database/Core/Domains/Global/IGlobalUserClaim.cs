using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Global;

public interface IGlobalUserClaim: IBaseEntity
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}