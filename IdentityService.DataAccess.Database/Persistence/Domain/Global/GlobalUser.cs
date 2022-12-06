using System.ComponentModel.DataAnnotations;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

[Index(nameof(Username), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class GlobalUser: BaseEntity, IGlobalUser
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Guid AddressGuid { get; set; }
    public Guid Tenant { get; set; }
    
    public List<string> ValidateWithMessage()
    {
        return this.GlobalUserValidation();
    }
}