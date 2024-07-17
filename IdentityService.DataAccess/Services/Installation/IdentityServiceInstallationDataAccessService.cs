using IdentityService.DataAccess.Database.ContextManagement;
using IdentityService.DataAccess.Database.ContextManagement.Services;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Services.Installation
{
    public class IdentityServiceInstallationDataAccessService: IIdentityServiceInstallationDataAccessService
    {
        
        
        
        public SystemUser? Install(InstallationModel model)
        {
            
            
            var errors = model.ValidateWithMessage();
            // need to add logs
            if (errors.Any())
            {
                return null;
            }
            
            
            var context = GenerateContext(model);
            
            IUnityOfWorkGlobal unityOfWorkGlobal = new UnityOfWorkGlobal(context);

            SystemUser user = new SystemUser();

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

        public SystemUser Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal)
        {
            SystemUser user = new SystemUser();

            user.Email = model.AdminEmail;
            user.Password = model.AdminPassword;
            user.Username = model.AdminUserName;


            unityOfWorkGlobal.GlobalUsers.Add(user);
            unityOfWorkGlobal.Save();
            return user;
        }
    }
    
    public class IdentityServiceInstallationDataAccessServiceV2: IIdentityServiceInstallationDataAccessService
    {
        
        
        
        public SystemUser? Install(InstallationModel model)
        {
            
            
            var errors = model.ValidateWithMessage();
            // need to add logs
            if (errors.Any())
            {
                return null;
            }
            
            
            var context = GenerateContext(model);
            
            IUnityOfWorkGlobal unityOfWorkGlobal = new UnityOfWorkGlobal(context);

            SystemUser user = new SystemUser();

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

        public SystemUser Install_Step_AddAminUser(InstallationModel model, IUnityOfWorkGlobal unityOfWorkGlobal)
        {
            SystemUser user = new SystemUser();

            user.Email = model.AdminEmail;
            user.Password = model.AdminPassword;
            user.Username = model.AdminUserName;


            unityOfWorkGlobal.GlobalUsers.Add(user);
            unityOfWorkGlobal.Save();
            return user;
        }
    }
}