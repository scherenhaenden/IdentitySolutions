using IdentityService.DataAccess.Database.ContextManagement;
using IdentityService.DataAccess.Database.ContextManagement.Services;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Services.Installation
{
    public interface IIdentityServiceInstallationDataAccessService
    {
        // Install Database/ Generate context and tables/ add first user
        SystemlUser? Install( InstallationModel model);

        public SystemlUser? Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal);
    }

    public class IdentityServiceInstallationDataAccessService: IIdentityServiceInstallationDataAccessService
    {
        
        
        
        public SystemlUser? Install(InstallationModel model)
        {
            
            
            var errors = model.ValidateWithMessage();
            // need to add logs
            if (errors.Any())
            {
                return null;
            }
            
            
            var context = GenerateContext(model);
            
            IUnityOfWorkGlobal unityOfWorkGlobal = new UnityOfWorkGlobal(context);

            SystemlUser user = new SystemlUser();

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

        public SystemlUser Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal)
        {
            SystemlUser user = new SystemlUser();

            user.Email = model.AdminEmail;
            user.Password = model.AdminPassword;
            user.Username = model.AdminUserName;


            unityOfWorkGlobal.GlobalUsers.Add(user);
            unityOfWorkGlobal.Save();
            return user;
        }
    }
}