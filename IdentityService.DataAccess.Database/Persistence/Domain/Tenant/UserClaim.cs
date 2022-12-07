using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Tenant;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Tenant
{
    [Index(nameof(ClaimType), nameof(ClaimValue),  IsUnique = true)]
    public class UserClaim : BaseEntity, IUserClaim
    {
        public string ClaimType { get; set; } = null!;
        public string ClaimValue { get; set; } = null!;
    }
}