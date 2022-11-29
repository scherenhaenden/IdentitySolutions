using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

public class UserCompact : BaseEntity, IUserCompact
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; }
}