using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

public class Tenant:  BaseEntity, ITenant
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Domain { get; set; }
    public string Configuration { get; set; }
}