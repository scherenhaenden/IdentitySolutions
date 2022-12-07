using IdentityService.DataAccess.Services.Installation;

namespace IdentityService.DataAccess.Tests._Setup.Model;

public class ConfigurationOfApplication
{
    public DataAccess DataAccess { get; set; }
}

public class DataAccess
{
    public DataBases DataBases { get; set; }
}

public class DataBases
{
    public Global Global { get; set; }
}

public class Global
{
    public DatabaseType DatabaseType { get; set; }

    public string DatabaseTypeName
    {
        get => DatabaseType.ToString();
        set => DatabaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), value);
    }
    
    
    public string ConnectionString { get; set; }
    public string ProviderName { get; set; }
}
