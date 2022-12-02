using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

public class LoginInformation : BaseEntity
{
    public string JsonLoginData { get; set; } = null!;
}