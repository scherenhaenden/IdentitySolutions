using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

[Index(nameof(ClaimType), nameof(ClaimValue),  IsUnique = true)]
public class ClaimDbModel : BaseEntity, IClaim
{
    public string ClaimType { get; set; } = null!;
    public string ClaimValue { get; set; } = null!;
}