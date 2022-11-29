using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

public class Claim : BaseEntity, IClaim
{
    public string ClaimType { get; set; } = null!;
    public string ClaimValue { get; set; } = null!;
}