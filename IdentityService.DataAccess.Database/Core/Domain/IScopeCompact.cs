using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface IScopeCompact: IBaseEntity
{
    public string ScopeCode { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}