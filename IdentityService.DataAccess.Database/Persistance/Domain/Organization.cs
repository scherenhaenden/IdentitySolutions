using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

public class Organization : BaseEntity, IOrganization
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string OrganizationCode { get; set; } = null!;
}