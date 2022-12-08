using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Global
{
    [TestFixture]
    public class RulesGlobalUser:BaseSetup
    {

        private new string _database = "RulesGlobalUser.db";
        private new IUnityOfWorkGlobal _unityOfWorkGlobal;

        public RulesGlobalUser()
        {
            base._database = _database;
        
        }
    
        // Setup
        [SetUp]
        public void Setup()
        {
            base.TearDown_v(_database);
            _unityOfWorkGlobal = base.GetUnitOfWorkGlobal(_database);
        }
    
        // Write First Test
        [Test, Order(1)]
        public void DDD_01_Global_Global_AddNewUser_shouldPass()
        {
            //_unitOfWork = base.GetUnitOfWork(_database);
            var globalUser = new SystemlUser();
            globalUser.Email = "testl@test.com";
            globalUser.Password = "test-test-test-test";
            globalUser.Username = "test";
            globalUser.FirstName = "test";
            globalUser.LastName = "Lastname";
            var validations =globalUser.ValidateWithMessage();
        
            var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
            _unityOfWorkGlobal.Save();
            Assert.IsNotNull(result);
        
            Assert.AreEqual(validations.Count(),0);
            var users = _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == "test");
        
            Assert.IsNotNull(users);
            PropertiesTester.AssertProperties(globalUser, users);
        }
    
        [Test, Order(2)]
        public void DDD_02_Role_AddSameUser_shouldNotPass()
        {

            //_unitOfWork = base.GetUnitOfWork(_database);
            var globalUser = new SystemlUser();
            globalUser.Email = "testl@test.com";
            globalUser.Password = "test-test-test-test";
            globalUser.Username = "test";
            var validations =globalUser.ValidateWithMessage();
        
            var falue = _unityOfWorkGlobal.GlobalUsers.Where(x => x.Username == "test").ToList();
            var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
            Assert.Throws<DbUpdateException>(()=>_unityOfWorkGlobal.Save());

        }
    
        [Test, Order(3)]
        public void DDD_03_Role_AddUSerWithWrongValidation_shouldNotPass()
        {

            //_unitOfWork = base.GetUnitOfWork(_database);
            var globalUser = new SystemlUser();
            globalUser.Email = "testasa.com";
            globalUser.Password = "tes";
            globalUser.Username = "t";
            var validations =globalUser.ValidateWithMessage();
            Assert.IsTrue(validations.Count() == 3);

        }
        
        [Test, Order(4)]
        public void DDD_04_Role_FindUserAndUpdateIt_shouldPass()
        {
            
            //_unitOfWork = base.GetUnitOfWork(_database);
            var globalUser = new SystemlUser();
            globalUser.Email = "testl-1@test.com";
            globalUser.Password = "test-test-test-test";
            globalUser.Username = "test-2";
            globalUser.FirstName = "test";
            globalUser.LastName = "Lastname";
            
            var doExistsTest = _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == globalUser.Username);
            Assert.IsNull(doExistsTest);
            
            
            var validations =globalUser.ValidateWithMessage();
        
            var result = _unityOfWorkGlobal.GlobalUsers.Add(globalUser);
            _unityOfWorkGlobal.Save();
            Assert.IsNotNull(result);
        
            Assert.AreEqual(validations.Count(),0);
            var insertedUser = _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == globalUser.Username);
            _unityOfWorkGlobal.Save();
        
            Assert.IsNotNull(insertedUser);
            PropertiesTester.AssertProperties(globalUser, insertedUser);
            
            PropertiesTester.AssertAfterNew(insertedUser);

            insertedUser.Email = "email.new@email.com";
            _unityOfWorkGlobal.GlobalUsers.Update(insertedUser);
            _unityOfWorkGlobal.Save();
            Thread.Sleep(1000);
            
            var userUpdated = _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == globalUser.Username);
            
            PropertiesTester.AssertAfterNew(userUpdated);
            PropertiesTester.AssertAfterUpdate(insertedUser, userUpdated);

        }
        
        [TearDown]
        public void TearDown()
        {
            _unityOfWorkGlobal.Dispose();
        }
    
        [OneTimeTearDown]
        public void TearDownOnce()
        {
            _unityOfWorkGlobal.Dispose();
            base.TearDown_v(_database);
        }

    
    }
}