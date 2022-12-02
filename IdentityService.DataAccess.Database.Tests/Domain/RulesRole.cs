using IdentityService.DataAccess.Database.Persistence.Domain;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using NUnit.Framework;

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
        _unitOfWork = base.GetUnitOfWork(_database);
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

        var result = _unitOfWork.Role.Add(role);
        _unitOfWork.Save();
        PropertiesTester.AssertProperties(result, role);
        Assert.IsNotNull(result);
    }
    
    [Test, Order(2)]
    public void DDD_02_Role_UpdateRole_shouldPass()
    {

        var result1 =_unitOfWork.Role.GetAll().ToList();
        var updateMe = _unitOfWork.Role.SingleOrDefault(x => x.CodeName == "test");
        updateMe.NormalizedName = "test2";
        _unitOfWork.Role.Update(updateMe);
        
        var result = _unitOfWork.Role.SingleOrDefault(x => x.CodeName == "test");

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