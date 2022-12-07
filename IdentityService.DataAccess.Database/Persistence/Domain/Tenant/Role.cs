using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Tenant;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Tenant
{
    [Index(nameof(Scope), IsUnique = true)]
    [Index(nameof(Scope), nameof(CodeName), nameof(NormalizedName), IsUnique = true)]
    public class Role : BaseEntity, IRole
    {
        public string Scope { get; set; } = default!;
        public string CodeName { get; set; } = default!;
        public string NormalizedName { get; set; } = default!;

    }
}