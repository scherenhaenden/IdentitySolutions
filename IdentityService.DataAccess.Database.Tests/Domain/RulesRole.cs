using IdentityService.DataAccess.Database.Persistence.Domain;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;

namespace IdentityService.DataAccess.Database.Tests.Domain;

[TestFixture]
public class RulesRole:BaseSetup
{
    private new string _database = $"RulesUser.db";

    public RulesRole()
    {
        base._database = _database;
        
    }
    // Setup
    [OneTimeSetUp]
    public void Setup()
    {
        UnitOfWorkTenant = base.GetUnitOfWork(_database);
    }
    
    [Test, Order(1)]
    public void DDD_01_Role_AddRole_shouldPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var role = new Role();
        role.Scope = "test";
        role.CodeName = "test";
        role.NormalizedName = "test";
        role.IsActive = true;

        var result = UnitOfWorkTenant.Role.Add(role);
        UnitOfWorkTenant.Save();
        PropertiesTester.AssertProperties(result, role);
        Assert.IsNotNull(result);
    }
    
    [Test, Order(2)]
    public void DDD_02_Role_UpdateRole_shouldPass()
    {

        var result1 =UnitOfWorkTenant.Role.GetAll().ToList();
        var updateMe = UnitOfWorkTenant.Role.SingleOrDefault(x => x.CodeName == "test");
        updateMe.NormalizedName = "test2";
        UnitOfWorkTenant.Role.Update(updateMe);
        
        var result = UnitOfWorkTenant.Role.SingleOrDefault(x => x.CodeName == "test");

        PropertiesTester.AssertProperties(result, updateMe);
        
        
        Assert.IsNotNull(result);
    }

    [Test, Order(3)]
    public void DDD_03_Role_TestOnNew_shouldPass()
    {
        var role = new Role();
        PropertiesTester.AssertOnNewAndOnUpdate(role);
        
    }
}