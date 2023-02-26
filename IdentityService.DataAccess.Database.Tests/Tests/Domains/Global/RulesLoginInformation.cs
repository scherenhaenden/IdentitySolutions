using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global
{
    [TestFixture]
    public class RulesLoginInformation:BaseSetup
    {
        private new string _database = "RulesLoginInformation.db";
        private new IUnityOfWorkGlobal _unityOfWorkGlobal;

        public RulesLoginInformation()
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
        public void DDD_01_Global_Global_AddNewTenant_shouldPass()
        {
            //_unitOfWork = base.GetUnitOfWork(_database);
            var globalUser = new SystemUser();
            globalUser.Email = "testl@test.com";
            globalUser.Password = "test";
            globalUser.Username = "test";
            globalUser.FirstName = "test";
            globalUser.LastName = "Lastname";
        
            var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
            _unityOfWorkGlobal.Save();
            Assert.IsNotNull(result);
        }
    
        [TearDown]
        public void TearDown()
        {
            base.TearDown_v(_database);
            // Tear down code goes here
        }
    
    }
}