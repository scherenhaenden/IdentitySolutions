using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface ILoginType: IBaseEntity
{
    public string Name { get; set; }
    public string NameCode { get; set; }
    public string Description { get; set; }
}