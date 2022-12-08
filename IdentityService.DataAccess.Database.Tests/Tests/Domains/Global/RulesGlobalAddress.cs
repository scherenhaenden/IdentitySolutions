using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global
{
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
            var globalAddress = new SystemAddress();
            globalAddress.City = "City";
            globalAddress.Country = "Country";
            globalAddress.State = "State";
            globalAddress.Street = "Street";
            globalAddress.ZipCode = "ZipCode";
            globalAddress.NameOrNumberOfBuilding = "NameOrNumberOfBuilding";
            globalAddress.Level = "Level";
            globalAddress.ExtraInformation = "ExtraInformation";
        
            _unityOfWorkGlobal.GlobalAddresses.Add(globalAddress);
            _unityOfWorkGlobal.Save();

            var resultAddress = (_unityOfWorkGlobal.GlobalAddresses.Where(
                x => x.City == "City" &&
                     x.Country == "Country" &&
                     x.State == "State" &&
                     x.Street == "Street" &&
                     x.ZipCode == "ZipCode" &&
                     x.NameOrNumberOfBuilding == "NameOrNumberOfBuilding" &&
                     x.Level == "Level" &&
                     x.ExtraInformation == "ExtraInformation"
            ) ?? Array.Empty<SystemAddress>()).ToList();
            Assert.IsNotNull(resultAddress);
        
            PropertiesTester.AssertProperties(globalAddress, resultAddress[0]);
        }

        [TearDown]
        public void TearDown()
        {
            base.TearDown_v(_database);
            // Tear down code goes here
        }

    }
}