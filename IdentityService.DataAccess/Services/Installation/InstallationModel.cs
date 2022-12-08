using System.Net.Mail;
using Helpers.Validations;

namespace IdentityService.DataAccess.Services.Installation;

public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }= null!;
    public string AdminEmail { get; set; } = null!;
    public string AdminUserName { get; set; }= null!;
    
    public string AdminFirstName { get; set; }= null!;
    public string AdminLastName { get; set; }= null!;
    public string AdminPassword { get; set; }= null!;
    public string AdminPasswordConfirm { get; set; } = null!;
    
    public List<string> ValidateWithMessage()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(ConnectionString))
        {
            errors.Add("Connection string is required");
        }
        if (string.IsNullOrWhiteSpace(AdminEmail))
        {
            errors.Add("Admin email is required");
        }
        if (string.IsNullOrWhiteSpace(AdminUserName))
        {
            errors.Add("Admin username is required");
        }
        if (string.IsNullOrWhiteSpace(AdminFirstName))
        {
            errors.Add("Admin first name is required");
        }
        if (string.IsNullOrWhiteSpace(AdminLastName))
        {
            errors.Add("Admin last name is required");
        }
        if (string.IsNullOrWhiteSpace(AdminPassword))
        {
            errors.Add("Admin password is required");
        }
        if (string.IsNullOrWhiteSpace(AdminPasswordConfirm))
        {
            errors.Add("Admin password confirm is required");
        }
        if (AdminPassword != AdminPasswordConfirm)
        {
            errors.Add("Admin password and confirm password must match");
        }
        
        try
        {
            _ = new MailAddress(AdminEmail);
        }
        catch (Exception)
        {
            
            errors.Add(ModelValidationMessages.EMAIL_IS_NOT_VALID);
        }

        
        
        return errors;
    }
    
    
}