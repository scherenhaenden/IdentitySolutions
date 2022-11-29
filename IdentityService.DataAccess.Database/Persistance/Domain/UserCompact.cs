using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistance.Domain;

///[Index(nameof(Email), IsUnique = true, nameof(Username), IsUnique = true)]
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
    public string Password { get; set; } = null!;

    public List<string> ValidateWithMessage()
    {
        var messages = new List<string>();
        // Validate email
        try
        {
            var mailAddress = new MailAddress(Email);
        }
        catch (Exception)
        {
            messages.Add("Email is not valid");
        }
        
        // Validate username
        if (Username?.Length < 3)
        {
            messages.Add("Username must be at least 3 characters long");
        }
        
        // Validate password
        if (Password?.Length < 8)
        {
            messages.Add("Password must be at least 8 characters long");
        }

        return messages;
    }
}