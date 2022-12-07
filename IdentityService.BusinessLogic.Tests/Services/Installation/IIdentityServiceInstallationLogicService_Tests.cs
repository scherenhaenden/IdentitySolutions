using IdentityService.BusinessLogic.Services.Installation;
using IdentityService.DataAccess.Services.Installation;

namespace IdentityService.BusinessLogic.Tests.Services.Installation
{
    [TestFixture]
    public class IIdentityServiceInstallationLogicService_Tests
    {
        // Write First Test
        [Test, Order(1)]
        public void DDD_01_TryInstallation_shouldPass()
        {
            InstallationModel model = new InstallationModel(); 
            string _currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(_currentDirectory,"somewhere.db");
        
            //delete if file exists
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            model.AdminEmail = "Admin";
            model.AdminPassword = "Admin";
            model.AdminPasswordConfirm = "Admin";
            model.ConnectionString = $"Data Source={path}";
            model.DatabaseType = DatabaseType.Sqlite;
            model.AdminUserName = "Admin";
            model.AdminFirstName = "Admin";
            model.AdminLastName = "Admin";

            IIdentityServiceInstallationLogicService identityServiceInstallationLogicService = new IdentityServiceInstallationLogicService();

            var result =  identityServiceInstallationLogicService.Install(model);
  
            Assert.IsNotNull(result);
        
        }
    }
}