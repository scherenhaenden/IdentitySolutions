using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Global;

public interface ITenant: IBaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Domain { get; set; }
    
}