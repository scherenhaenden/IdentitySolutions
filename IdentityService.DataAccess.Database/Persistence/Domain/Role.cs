using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

[Index(nameof(Scope), IsUnique = true)]
[Index(nameof(Scope), nameof(CodeName), nameof(NormalizedName), IsUnique = true)]
public class Role : BaseEntity, IRole
{
    public string Scope { get; set; }
    public string CodeName { get; set; }
    public string NormalizedName { get; set; }
}