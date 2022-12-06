using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain.Global;

public interface IRole: IBaseEntity
{
    public string CodeName { get; set; }
    public string NormalizedName { get; set; }
}