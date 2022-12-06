using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;

namespace IdentityService.DataAccess.Database.Tests.Domain.Global;

[TestFixture]
public class RulesGlobalUser:BaseSetup
{

    private new string _database = "RulesGlobalUser.db";
    private new IUnityOfWorkGlobal _unityOfWorkGlobal;

    public RulesGlobalUser()
    {
        base._database = _database;
        
    }
    
    // Setup
    [OneTimeSetUp]
    public void Setup()
    {
        _unityOfWorkGlobal = base.GetUnitOfWorkGlobal(_database);
    }
    
    // Write First Test
    [Test, Order(1)]
    public void DDD_01_Global_Global_AddNewUser_shouldPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var globalUser = new GlobalUser();
        globalUser.Email = "testl@test.com";
        globalUser.Password = "test";
        globalUser.Username = "test";
        
        var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
        _unityOfWorkGlobal.Save();
        Assert.IsNotNull(result);
    }
    
}