using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Services.Installation;

public interface IIdentityServiceInstallationDataAccessService
{
    // Install Database/ Generate context and tables/ add first user
    SystemUser? Install( InstallationModel model);

    public SystemUser? Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal);
}