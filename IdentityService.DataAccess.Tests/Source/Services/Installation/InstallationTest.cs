using Helpers.Configuration;
using Helpers.Configuration.Core;
using Helpers.Configuration.Models;
using IdentityService.DataAccess.Services.Installation;
using DatabaseType = IdentityService.DataAccess.Services.Installation.DatabaseType;

namespace IdentityService.DataAccess.Tests.Source.Services.Installation
{
    [TestFixture]
    public class InstallationTest
    {
        private ConfigurationOfApplication _configuration;
        private IDataBasesManagerForTests _dataBasesManagerForTests;
        private Global _globalDb;
        
        // Setup
        [SetUp]
        public void Setup()
        {
            
            
            
            IConfigurationLoad configurationLoad = new ConfigurationLoad();
            _configuration = configurationLoad.LoadAndGetConfiguration("sqlite");
            _globalDb = _configuration.DataAccess.DataBases.Global.First(x => x.ContextName == "TestInstall");
            _dataBasesManagerForTests = new DataBasesManagerForTests(
                _globalDb.DatabaseType,
                _globalDb.ConnectionString);
            _dataBasesManagerForTests.DatabaseTearDown();
       
        }

        [Test, Order(1)]
        public void Test_01_InstallationOfDatabase_shouldPass()
        {
            // Init Install
            IIdentityServiceInstallationDataAccessService installationDataAccessService =
                new
                    IdentityServiceInstallationDataAccessService();

            InstallationModel installationModel = new InstallationModel();

            installationModel.AdminUserName = "AdminPass";
            installationModel.AdminEmail = "AdminPass@email.com";
            installationModel.AdminPassword = "AddminPassPass";
            installationModel.AdminPasswordConfirm = "AddminPassPass";
            installationModel.AdminFirstName = "AddminPass";
            installationModel.AdminLastName = "AdminPass";
            installationModel.ConnectionString = _globalDb.ConnectionString;
            var databaseType = _globalDb.DatabaseTypeName;
            Enum.TryParse(databaseType, out DatabaseType myStatus);
            installationModel.DatabaseType = myStatus;

            var result = installationDataAccessService.Install(installationModel);
            
            Assert.IsNotNull(result);

        }
        
        
        [Test, Order(2)]
        public void Test_02_InstallationOfDatabase_shouldNotPass()
        {
            Setup();
            // Init Install
            IIdentityServiceInstallationDataAccessService installationDataAccessService =
                new
                    IdentityServiceInstallationDataAccessService();

            InstallationModel installationModel = new InstallationModel();

            installationModel.AdminUserName = "AdminPass";
            installationModel.AdminEmail = "AdminPass";
            installationModel.AdminPassword = "AddminPass";
            installationModel.AdminFirstName = "AddminNotPass";
            installationModel.AdminLastName = "AdminPass";
            installationModel.ConnectionString = _globalDb.ConnectionString;
            var databaseType = _globalDb.DatabaseTypeName;
            Enum.TryParse(databaseType, out DatabaseType myStatus);
            installationModel.DatabaseType = myStatus;

            var result = installationDataAccessService.Install(installationModel);
            
            Assert.IsNull(result);

        }
        
        // Add one time teardown
        [TearDown]
        public void TearDown()
        {
            _dataBasesManagerForTests.DatabaseTearDown();
        }     
    
    }
}