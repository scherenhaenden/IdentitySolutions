using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain.InnerTenant;

public interface IUserClaim: IBaseEntity
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}