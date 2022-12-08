using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Code), IsUnique = true)]
public class GlobalClaim:  BaseEntity, IGlobalClaim
{
    public string Description { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}

