using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface IUserCompact: IBaseEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}