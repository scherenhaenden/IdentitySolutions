using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseEntity, IUser
{
    [Required]
    [MinLength(14)]
    public string Password { get; set; } = null!;
    
    [Required]
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; }= null!;
    public string? Phone { get; set; }
    public string? Company { get; set; }
    public string? Website { get; set; }
    public string? ImageUrl { get; set; }
    public string? Bio { get; set; }
    public int AccessFailedCount { get; set; } = 0;
    public string? ConcurrencyStamp { get; set; }
    
    [Required]
    public string? Email { get; set; } = null;
    
    [Required]
    public string Username { get; set; } = null!;
    public bool NeedsEmailConfirmation { get; set; } = false;
    public bool EmailConfirmed { get; set; } = false;
    public bool PhoneNumberConfirmed { get; set; } = false;
    public bool NeedsPhoneConfirmation { get; set; } = false;
    
    public Guid AddressGuid { get; set; }
    
    public List<string> ValidateWithMessage()
    {
        var messages = new List<string>();
        // Validate email
        try
        {
            _ = new MailAddress(Email);
        }
        catch (Exception)
        {
            
            messages.Add(ModelValidationMessages.EMAIL_IS_NOT_VALID);
        }
        
        // Validate username
        if (Username?.Length < 3)
        {
            messages.Add(ModelValidationMessages.USERNAME_IS_NOT_VALID);
        }
        
        // Validate password
        // TODO: this is not a good way to validate password
        
        if (Password?.Length < 8)
        {
            messages.Add(ModelValidationMessages.PASSWORD_IS_NOT_VALID);
        }

        return messages;
    }
}