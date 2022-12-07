namespace IdentityService.DataAccess.Services.Installation;

public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }
    public string AdminEmail { get; set; }
    public string AdminUserName { get; set; }
    
    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPasswordConfirm { get; set; }
    
    
}