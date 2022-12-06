using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Tenant;

public class LoginInformation : BaseEntity
{
    public string JsonLoginData { get; set; } = null!;
}