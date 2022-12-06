using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Global;

public interface IOrganization: IBaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string OrganizationCode { get; set; }
}