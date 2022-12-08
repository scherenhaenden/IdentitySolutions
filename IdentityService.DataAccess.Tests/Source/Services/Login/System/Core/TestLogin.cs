using Helpers.Configuration.Core;
using Helpers.Configuration.Models;
using IdentityService.DataAccess.Database.ContextManagement.Services;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Unities;
using IdentityService.DataAccess.Services.Installation;
using IdentityService.DataAccess.Services.Login.System;
using NUnit.Framework;
using DatabaseType = Helpers.Configuration.Models.DatabaseType;

namespace IdentityService.DataAccess.Tests.Source.Services.Login.System.Core;

[TestFixture]
public class TestLogin
{
    
    private ConfigurationOfApplication _configuration;
    private IDataBasesManagerForTests _dataBasesManagerForTests;
    
    [Test, Order(1)]
    public void TestLogin_Install_ThenLogin_ShouldPass()
    {
        IConfigurationLoad configurationLoad = new ConfigurationLoad();
        _configuration = configurationLoad.LoadAndGetConfiguration("sqlite");
        var globalDb = _configuration.DataAccess.DataBases.Global.First(x => x.ContextName == "TestLogin");
        _dataBasesManagerForTests = new DataBasesManagerForTests(
            globalDb.DatabaseType,
            globalDb.ConnectionString);
        _dataBasesManagerForTests.DatabaseTearDown();
        
        
        IContextManager contextManager = new ContextManager();
        
        var context = contextManager.GenerateGlobalContext(
            globalDb.DatabaseTypeName.ToLower(), 
            globalDb.ConnectionString);
        
        IUnityOfWorkGlobal unityOfWorkGlobal = new UnityOfWorkGlobal(context);
        
        ILoginRepository loginRepository = new LoginRepository(unityOfWorkGlobal);
        ILoginDataAccessService loginDataAccessService = new LoginDataAccessService(loginRepository);
        
        
        // Init Install
        IIdentityServiceInstallationDataAccessService installationDataAccessService =
            new
                IdentityServiceInstallationDataAccessService();

        InstallationModel installationModel = new InstallationModel();

        installationModel.AdminUserName = "AdminPass";
        installationModel.AdminEmail = "AdminPass@email.com";
        installationModel.AdminPassword = "AddminPass";
        installationModel.AdminPasswordConfirm = "AddminPass";
        installationModel.AdminFirstName = "AddminPass";
        installationModel.AdminLastName = "AdminPass";
        installationModel.ConnectionString = globalDb.ConnectionString;
        var databaseType = globalDb.DatabaseTypeName;
        Enum.TryParse(databaseType, out DataAccess.Services.Installation.DatabaseType myStatus);
        installationModel.DatabaseType = myStatus;

        var result = installationDataAccessService.Install(installationModel);
        
        Assert.IsNotNull(result);
        
        var compactModel = loginDataAccessService.GetGlobalUserCompactModel(installationModel.AdminUserName , installationModel.AdminPassword );
        
        Assert.IsNotNull(compactModel);
        
        var compactModel2 = loginDataAccessService.GetGlobalUserCompactModel(installationModel.AdminEmail , installationModel.AdminPassword );
        
        Assert.IsNotNull(compactModel2);
        _dataBasesManagerForTests.DatabaseTearDown();
        
        
    }
    
    // CleanUp
    [TearDown]
    public void TearDown()
    {
        _dataBasesManagerForTests.DatabaseTearDown();
    }
}