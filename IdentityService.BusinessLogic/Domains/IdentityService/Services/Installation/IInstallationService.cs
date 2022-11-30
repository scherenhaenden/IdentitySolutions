namespace IdentityService.BusinessLogic.Domains.IdentityService.Services.Installation;

public interface IInstallationService
{
    Task<bool> InstallAsync();

}