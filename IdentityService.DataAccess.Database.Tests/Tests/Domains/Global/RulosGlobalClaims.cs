using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global;

[TestFixture]
public class RulosGlobalClaims:BaseSetup
{
    private new string _database = "RulesGlobalRole.db";
    private new IUnityOfWorkGlobal _unityOfWorkGlobal;

    public RulosGlobalClaims()
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
    public void DDD_01_Global_Claims_AddNew_shouldPass()
    {
        var globalClaim = new GlobalClaim();
        globalClaim.Name = "Test";
        globalClaim.Description = "Test";
        globalClaim.Code = "Test";
        
        
        _unityOfWorkGlobal.GlobalUserClaims.Add(globalClaim);
        _unityOfWorkGlobal.Save();
        
        var result =_unityOfWorkGlobal.GlobalUserClaims.SingleOrDefault(x=>x.Name == globalClaim.Name);
        
        Assert.IsNotNull(result);
        
        PropertiesTester.AssertAfterNew(result);
        
        globalClaim.Description = "Test2";
        
        var resultUpdated =_unityOfWorkGlobal.GlobalUserClaims.Update(result);
        
        PropertiesTester.AssertAfterUpdate(result,resultUpdated);
        
    }
    
    [Test, Order(2)]
    public void DDD_02_Global_Claims_AddNew_shouldNotPass()
    {
        var globalClaim = new GlobalClaim();
        globalClaim.Name = "Test";
        globalClaim.Description = "Test";
        globalClaim.Code = "Test";
        
        
        _unityOfWorkGlobal.GlobalUserClaims.Add(globalClaim);
        Assert.Throws<DbUpdateException>(()=>_unityOfWorkGlobal.Save());
        Assert.Pass();
    }

}