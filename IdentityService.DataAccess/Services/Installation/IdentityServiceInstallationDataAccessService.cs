using IdentityService.DataAccess.Database.ContextManagment;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Services.Installation;

public interface IIdentityServiceInstallationDataAccessService
{
    // Install Database/ Generate context and tables/ add first user
    GlobalUser InstallAsync( InstallationModel model);
}

public class IdentityServiceInstallationDataAccessService: IIdentityServiceInstallationDataAccessService
{
    public GlobalUser InstallAsync(InstallationModel model)
    {
        
        IContextManager contextManager = new ContextManager();
        var typeOfDataBae = Enum.GetName(model.DatabaseType).ToLower();
        var context = contextManager.GenerateGlobalContext(typeOfDataBae, model.ConnectionString);
            
        IUnityOfWorkGlobal unityOfWorkGlobal = new UnitOfWorkGlobal(context);

        GlobalUser user = new GlobalUser();

        user.Email = model.AdminEmail;
        user.Password = model.AdminPassword;
        user.Username = model.AdminUserName;


        unityOfWorkGlobal.GlobalUsers.Add(user);
        context.SaveChanges();
        return user;





    }
}

public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }
    public string AdminEmail { get; set; }
    public string AdminUserName { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPasswordConfirm { get; set; }
}

public enum DatabaseType
{
    MsSql,
    Sqlite,
    PostgreSql,
    MSSQlS,
}