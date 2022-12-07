using IdentityService.DataAccess.Services.Installation;
using IdentityService.DataAccess.Tests._Setup;
using IdentityService.DataAccess.Tests._Setup.Model;

namespace IdentityService.DataAccess.Tests.Source.Services.Installation
{
    [TestFixture]
    public class InstallationTest
    {
        private ConfigurationOfApplication _configuration;
        private IDataBasesManagerForTests _dataBasesManagerForTests;
        
        // Setup
        [SetUp]
        public void Setup()
        {
            
            
            IConfigurationLoad configurationLoad = new ConfigurationLoad();
            _configuration = configurationLoad.LoadAndGetConfiguration("sqlite");
            _dataBasesManagerForTests = new DataBasesManagerForTests(
                _configuration.DataAccess.DataBases.Global.DatabaseType,
                _configuration.DataAccess.DataBases.Global.ConnectionString);
            _dataBasesManagerForTests.DatabaseTearDown();
       
        }

        [Test, Order(1)]
        public void Test_InstallationOfDatabase()
        {
            // Init Install
            IIdentityServiceInstallationDataAccessService installationDataAccessService =
                new
                    IdentityServiceInstallationDataAccessService();

            InstallationModel installationModel = new InstallationModel();

            installationModel.AdminUserName = "AdminPass";
            installationModel.AdminEmail = "AdminPass";
            installationModel.AdminPassword = "AddminPass";
            installationModel.AdminFirstName = "AddminPass";
            installationModel.AdminLastName = "AdminPass";
            installationModel.ConnectionString = _configuration.DataAccess.DataBases.Global.ConnectionString;
            var databaseType = _configuration.DataAccess.DataBases.Global.DatabaseTypeName;
            Enum.TryParse(databaseType, out DatabaseType myStatus);
            installationModel.DatabaseType = myStatus;

            var result = installationDataAccessService.Install(installationModel);
            
            Assert.IsNotNull(result);

        }
        
        // Add one time teardown
        [TearDown]
        public void TearDown()
        {
            _dataBasesManagerForTests.DatabaseTearDown();
        }     
    
    }
}