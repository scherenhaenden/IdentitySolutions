using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Domain.Global;

[TestFixture]
public class RulesGlobalAddress:BaseSetup
{

    private new string _database = "RulesGlobaAddresses.db";
    private new IUnityOfWorkGlobal _unityOfWorkGlobal;

    public RulesGlobalAddress()
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
        var globalUser = new GlobalAddress();
        globalUser.City = "City";
        globalUser.Country = "Country";
        globalUser.State = "State";
        globalUser.Street = "Street";
        globalUser.ZipCode = "ZipCode";
        globalUser.NameOrNumberOfBuilding = "NameOrNumberOfBuilding";
        globalUser.Level = "Level";
        globalUser.ExtraInformation = "ExtraInformation";
        
        _unityOfWorkGlobal.GlobalAddresses.Add(globalUser);
        _unityOfWorkGlobal.Save();

        var resultAddress = _unityOfWorkGlobal.GlobalAddresses.Where(
            x => x.City == "City" &&
                 x.Country == "Country" &&
                 x.State == "State" &&
                 x.Street == "Street" &&
                 x.ZipCode == "ZipCode" &&
                 x.NameOrNumberOfBuilding == "NameOrNumberOfBuilding" &&
                 x.Level == "Level" &&
                 x.ExtraInformation == "ExtraInformation"
        ).ToList();
        Assert.IsNotNull(resultAddress);
    }

    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }

}