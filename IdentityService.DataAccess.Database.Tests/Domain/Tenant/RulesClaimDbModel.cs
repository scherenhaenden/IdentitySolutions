using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Domain;

[NonParallelizable]
[TestFixture, Order(7)]
public class RulesClaimDbModel :BaseSetup
{

    private new string _database = "Claim.db";
    private new IUnitOfWorkTenant _unitOfWorkTenant;

    public RulesClaimDbModel()
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
    public void DDD_01_ClaimDbModel_shouldPass()
    {
        //_unitOfWork = base.GetUnitOfWork(_database);
        var claimDbModel = new UserClaim();
        
        claimDbModel.Guid = Guid.NewGuid();
        claimDbModel.ClaimType = "ClaimType";
        claimDbModel.ClaimValue = "ClaimValue.type";
        
        var result = _unitOfWorkTenant.Claims.Add(claimDbModel);
        _unitOfWorkTenant.Save();
        Assert.IsNotNull(result);
        PropertiesTester.AssertProperties(result, claimDbModel);
        
    }
    
    [Test, Order(2)]
    public void DDD_02_ClaimDbModel_shouldFail()
    {
        var claimDbModel = new UserClaim();
        claimDbModel.Guid = Guid.NewGuid();
        claimDbModel.ClaimType = "ClaimType";
        claimDbModel.ClaimValue = "ClaimValue.type";
        
        var result = _unitOfWorkTenant.Claims.Add(claimDbModel);
        Assert.Throws<DbUpdateException>(()=>_unitOfWorkTenant.Save());
        
    }
    
    
    [Test, Order(2)]
    public void DDD_02_ClaimDbModel_shouldPass()
    {
        var claimDbModel = new UserClaim();
        claimDbModel.ClaimType = "ClaimType";
        claimDbModel.ClaimValue = "ClaimValue.type";

        var result = _unitOfWorkTenant.Claims.SingleOrDefault(x =>
            x.ClaimType == claimDbModel.ClaimType && x.ClaimValue == claimDbModel.ClaimValue);
        Assert.NotNull(result);
    }
    
     
    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }

    
    
}