using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain.Global;

public interface ITenant: IBaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Domain { get; set; }
    
}