using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Validation;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

public class GlobalUser: BaseEntity, IGlobalUser
{
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid AddressGuid { get; set; }
    public Guid Tenant { get; set; }
    
    public List<string> ValidateWithMessage()
    {
        return this.GlobalUserValidation();
    }
}