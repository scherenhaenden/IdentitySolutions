using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global;

[TestFixture]
public class RulesGlobalRole:BaseSetup
{

    private new string _database = "RulesGlobalRole.db";
    private new IUnityOfWorkGlobal _unityOfWorkGlobal;

    public RulesGlobalRole()
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
    public void DDD_01_Global_Global_AddNewRole_shouldPass()
    {
        var role = new GlobalRole();
        role.Name = "Test Role";
        role.Description = "Test Role Description";
        
        _unityOfWorkGlobal.GlobalRoles.Add(role);
        _unityOfWorkGlobal.Save();

        var roleResult = _unityOfWorkGlobal.GlobalRoles.Where(x => x.Name == role.Name).SingleOrDefault();
        
        Assert.IsNotNull(roleResult);
        PropertiesTester.AssertProperties(role, roleResult);
    }
    
    // Write First Test
    [Test, Order(2)]
    public void DDD_02_Global_Global_AddNewRole_shouldNotPass()
    {
        var role = new GlobalRole();
        role.Name = "Test Role";
        role.Description = "Test Role Description";
        
        _unityOfWorkGlobal.GlobalRoles.Add(role);        
        Assert.Throws<DbUpdateException>(()=>_unityOfWorkGlobal.Save());

    }

    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }

}