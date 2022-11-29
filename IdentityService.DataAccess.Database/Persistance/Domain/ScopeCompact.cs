using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

public class ScopeCompact : BaseEntity, IScopeCompact
{
    public string ScopeCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; } 
}