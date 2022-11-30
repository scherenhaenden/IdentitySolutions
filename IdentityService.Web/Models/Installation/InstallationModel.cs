namespace IdentityService.Web.Models.Installation;

public enum DatabaseType
{
    MsSql,
    Sqlite,
    PostgreSql,
    MSSQlS,
}



public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }
    public string AdminEmail { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPasswordConfirm { get; set; }
}