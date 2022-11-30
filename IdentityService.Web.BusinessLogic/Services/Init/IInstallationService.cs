namespace IdentityService.Web.BusinessLogic.Services.Init;

public interface IInitService
{
    bool Init();
    
    // Is the application connected to the database?
    bool IsDatabaseConnected();
    
    // Is the application installed?
    bool IsInstalled();
}

public class InitService : IInitService
{
    public bool Init()
    {
        throw new NotImplementedException();
    }

    public bool IsDatabaseConnected()
    {
        return false;
    }

    public bool IsInstalled()
    {
        return false;
    }
}


public interface IInstallationService
{
    // Install the application step 1

}