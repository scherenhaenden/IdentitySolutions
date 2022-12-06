using System.Net.Mail;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using IdentityService.DataAccess.Database.Core.Domains.Tenant;

namespace IdentityService.DataAccess.Database.Persistence.Validation;

public static class Validations
{
    public static List<string> GlobalUserValidation(this IGlobalUser user)
    {
        var messages = new List<string>();
        // Validate email
        try
        {
            _ = new MailAddress(user.Email);
        }
        catch (Exception)
        {
            
            messages.Add(ModelValidationMessages.EMAIL_IS_NOT_VALID);
        }
        
        // Validate username
        if (user.Username?.Length < 3)
        {
            messages.Add(ModelValidationMessages.USERNAME_IS_NOT_VALID);
        }
        
        // Validate password
        // TODO: this is not a good way to validate password
        
        if (user.Password?.Length < 8)
        {
            messages.Add(ModelValidationMessages.PASSWORD_IS_NOT_VALID);
        }

        return messages;
    }
    
    
    public static List<string> UserValidation(this IUser user)
    {
        var messages = new List<string>();
        // Validate email
        try
        {
            _ = new MailAddress(user.Email);
        }
        catch (Exception)
        {
            
            messages.Add(ModelValidationMessages.EMAIL_IS_NOT_VALID);
        }
        
        // Validate username
        if (user.Username?.Length < 3)
        {
            messages.Add(ModelValidationMessages.USERNAME_IS_NOT_VALID);
        }
        
        // Validate password
        // TODO: this is not a good way to validate password
        
        if (user.Password?.Length < 8)
        {
            messages.Add(ModelValidationMessages.PASSWORD_IS_NOT_VALID);
        }

        return messages;
    }
}