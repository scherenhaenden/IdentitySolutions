using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

public class LoginInformation : BaseEntity
{
    public string JsonLoginData { get; set; } = null!;
}