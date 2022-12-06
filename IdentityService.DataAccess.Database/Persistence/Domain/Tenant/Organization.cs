using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Tenant;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Tenant;

[Index(nameof(Name), IsUnique = true)]
public class Organization : BaseEntity, IOrganization
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string OrganizationCode { get; set; } = null!;
}