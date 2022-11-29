using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface IClaimBase: IBaseEntity
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}