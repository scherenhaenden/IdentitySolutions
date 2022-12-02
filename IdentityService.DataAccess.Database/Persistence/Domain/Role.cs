using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

public class Role : BaseEntity, IRole
{
    public string CodeName { get; set; }
    public string NormalizedName { get; set; }
}