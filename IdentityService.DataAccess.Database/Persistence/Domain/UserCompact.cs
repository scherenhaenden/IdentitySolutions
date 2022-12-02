using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class UserCompact : BaseEntity, IUserCompact
{
    [Required]
    public string Email
    {
        // validate email
        get;
        set;
        
    } = null!;
    
    [Required]
    public string Username { get; set; } = null!;
    
    [Required]
    [MinLength(14)]
    public string Password { get; set; } = null!;

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