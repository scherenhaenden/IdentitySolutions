using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
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
        
        Assert.Pass();
        
    }

}