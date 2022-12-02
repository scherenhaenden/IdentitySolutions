using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

public class User : BaseEntity, IUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }= null!;
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? Website { get; set; }
    public string? ImageUrl { get; set; }
    public string? Bio { get; set; }
    public int AccessFailedCount { get; set; } = 0;
    public string? ConcurrencyStamp { get; set; }
    public string? Email { get; set; } = null;
    public bool NeedsEmailConfirmation { get; set; } = false;
    public bool EmailConfirmed { get; set; } = false;
    public bool PhoneNumberConfirmed { get; set; } = false;
    public bool NeedsPhoneConfirmation { get; set; } = false;
    
    public Guid AddressGuid { get; set; }
}