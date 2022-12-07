using IdentityService.DataAccess.Database.ContextManagement;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Services.Installation
{
    public interface IIdentityServiceInstallationDataAccessService
    {
        // Install Database/ Generate context and tables/ add first user
        GlobalUser Install( InstallationModel model);

        public GlobalUser Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal);
    }

    public class IdentityServiceInstallationDataAccessService: IIdentityServiceInstallationDataAccessService
    {
        public GlobalUser Install(InstallationModel model)
        {
            var context = GenerateContext(model);
            
            IUnityOfWorkGlobal unityOfWorkGlobal = new UnitOfWorkGlobal(context);

            GlobalUser user = new GlobalUser();

            user.Email = model.AdminEmail;
            user.Password = model.AdminPassword;
            user.Username = model.AdminUserName;
            user.FirstName = model.AdminFirstName;
            user.LastName = model.AdminLastName;


            unityOfWorkGlobal.GlobalUsers.Add(user);
            unityOfWorkGlobal.Save();
            return user;
        }
        
        private IdentityContextGlobal GenerateContext(InstallationModel model) {
            
            IContextManager contextManager = new ContextManager();
            var typeOfDataBae = Enum.GetName(model.DatabaseType).ToLower();
            var context = contextManager.GenerateGlobalContext(typeOfDataBae, model.ConnectionString);
            return context;
        }

        public GlobalUser Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal)
        {
            GlobalUser user = new GlobalUser();

            user.Email = model.AdminEmail;
            user.Password = model.AdminPassword;
            user.Username = model.AdminUserName;


            unityOfWorkGlobal.GlobalUsers.Add(user);
            unityOfWorkGlobal.Save();
            return user;
        }
    }
}