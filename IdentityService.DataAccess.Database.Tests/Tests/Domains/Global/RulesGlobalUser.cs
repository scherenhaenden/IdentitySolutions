using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global;

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
        globalUser.Password = "test-test-test-test";
        globalUser.Username = "test";
        var validations =globalUser.ValidateWithMessage();
        
        var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
        _unityOfWorkGlobal.Save();
        Assert.IsNotNull(result);
        
        Assert.AreEqual(validations.Count(),0);
        var users = _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == "test");
        
        Assert.IsNotNull(users);
        PropertiesTester.AssertProperties(globalUser, users);
    }
    
    [Test, Order(2)]
    public void DDD_02_Role_AddSameUser_shouldNotPass()
    {

        //_unitOfWork = base.GetUnitOfWork(_database);
        var globalUser = new GlobalUser();
        globalUser.Email = "testl@test.com";
        globalUser.Password = "test-test-test-test";
        globalUser.Username = "test";
        var validations =globalUser.ValidateWithMessage();
        
        var falue = _unityOfWorkGlobal.GlobalUsers.Where(x => x.Username == "test").ToList();
        var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
        Assert.Throws<DbUpdateException>(()=>_unityOfWorkGlobal.Save());

    }
    
    [Test, Order(3)]
    public void DDD_03_Role_AddUSerWithWrongValidation_shouldNotPass()
    {

        //_unitOfWork = base.GetUnitOfWork(_database);
        var globalUser = new GlobalUser();
        globalUser.Email = "testasa.com";
        globalUser.Password = "tes";
        globalUser.Username = "t";
        var validations =globalUser.ValidateWithMessage();
        
        Assert.IsTrue(validations.Count() > 0);
        Assert.IsTrue(validations.Count() == 3);
        


    }
    
    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }

    
}