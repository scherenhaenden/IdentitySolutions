using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Tenant;
using IdentityService.DataAccess.Database.Tests._Setup;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Tenant;

[TestFixture]
public class RuleLoginType:BaseSetup
{

    private new string _database = "LoginType.db";
    private new IUnitOfWorkTenant _unitOfWorkTenant;

    public RuleLoginType()
    {
        base._database = _database;
        
    }
    
    // Setup
    [OneTimeSetUp]
    public void Setup()
    {
        _unitOfWorkTenant = base.GetUnitOfWork(_database);
    }
    
    // Write First Test
    [Test, Order(1)]
    public void DDD_01_LoginType_BasicEmailAndPassword_shouldPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var loginType = new LoginType();
        loginType.LoginTypeName = LoginTypes.BasicEmailAndPassword;
        
        
        var result = _unitOfWorkTenant.LoginType.Add(loginType);
        _unitOfWorkTenant.Save();
        Assert.IsNotNull(result);
    }
    
    [Test, Order(2)]
    public void DDD_02_LoginType_BasicUserAndPassword_shouldPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var loginType = new LoginType();
        loginType.LoginTypeName = LoginTypes.BasicUserAndPassword;
        
        
        var result = _unitOfWorkTenant.LoginType.Add(loginType);
        _unitOfWorkTenant.Save();
        Assert.IsNotNull(result);
    }
    
    // Write First Test
    [Test, Order(3)]
    public void DDD_03_LoginType_BasicEmailAndPassword_shouldNotPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var loginType = new LoginType();
        loginType.LoginTypeName = LoginTypes.BasicEmailAndPassword;
        
        
        var result = _unitOfWorkTenant.LoginType.Add(loginType);
        Assert.Throws<DbUpdateException>(()=>_unitOfWorkTenant.Save());
        
    }
    
    [Test, Order(4)]
    public void DDD_04_LoginType_BasicUserAndPassword_shouldNotPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var loginType = new LoginType();
        loginType.LoginTypeName = LoginTypes.BasicUserAndPassword;
        
        
        var result = _unitOfWorkTenant.LoginType.Add(loginType);
        Assert.Throws<DbUpdateException>(()=>_unitOfWorkTenant.Save());
    }

    
       
    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }

}