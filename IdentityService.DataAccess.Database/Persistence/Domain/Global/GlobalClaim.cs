using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

public class GlobalClaim:  BaseEntity, IGlobalClaim
{
    public string Description { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
}

