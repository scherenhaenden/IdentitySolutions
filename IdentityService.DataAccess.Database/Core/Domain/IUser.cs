using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface IUser: IBaseEntity
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Phone { get; set; }
    string Address { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }
    string Country { get; set; }
    string Company { get; set; }
    string Website { get; set; }
    string ImageUrl { get; set; }
    string Bio { get; set; }
    public int AccessFailedCount { get; set; }
    public string ConcurrencyStamp { get; set; }
    public string Email { get; set; }
    public bool NeedsEmailConfirmation { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool NeedsPhoneConfirmation { get; set; }
}