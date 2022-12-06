using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant;

public interface IUser: IBaseEntity
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Phone { get; set; }
    string Company { get; set; }
    string Website { get; set; }
    string ImageUrl { get; set; }
    string Bio { get; set; }
    public int AccessFailedCount { get; set; }
    public string ConcurrencyStamp { get; set; }
    public bool NeedsEmailConfirmation { get; set; }
    public bool EmailConfirmed { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool NeedsPhoneConfirmation { get; set; }
    public Guid AddressGuid { get; set; }
}