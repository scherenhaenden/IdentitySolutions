using IdentityService.DataAccess.Database.Persistence.Domain.Tenant;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Tenant
{
    [TestFixture]
    public class RulesRole:BaseSetup
    {
        private new string _database = $"RulesUser.db";

        public RulesRole()
        {
            base._database = _database;
        
        }
        // Setup
        [SetUp]
        public void Setup()
        {
            _unitOfWorkTenant = base.GetUnitOfWork(_database);
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

            var result = _unitOfWorkTenant.Role.Add(role);
            _unitOfWorkTenant.Save();
            PropertiesTester.AssertProperties(result, role);
            Assert.IsNotNull(result);
        }
    
        [Test, Order(2)]
        public void DDD_02_Role_UpdateRole_shouldPass()
        {

            var result1 =_unitOfWorkTenant.Role.GetAll().ToList();
            var updateMe = _unitOfWorkTenant.Role.SingleOrDefault(x => x.CodeName == "test");
            updateMe.NormalizedName = "test2";
            _unitOfWorkTenant.Role.Update(updateMe);
        
            var result = _unitOfWorkTenant.Role.SingleOrDefault(x => x.CodeName == "test");

            PropertiesTester.AssertProperties(result, updateMe);
        
        
            Assert.IsNotNull(result);
        }

        [Test, Order(3)]
        public void DDD_03_Role_TestOnNew_shouldPass()
        {
            var role = new Role();
            PropertiesTester.AssertOnNewAndOnUpdate(role);
        
        }
        
        
        [Test, Order(4)]
        public void DDD_04_TestOnNew_shouldPass()
        {
            //_unitOfWork = base.GetUnitOfWork(_database);
            var role = new Role();
            role.Scope = "test-new";
            role.CodeName = "test-new";
            role.NormalizedName = "test-new";
            role.IsActive = true;
            
            //PropertiesTester.AssertOnNewAndOnUpdate();

            var result = _unitOfWorkTenant.Role.Add(role);
            _unitOfWorkTenant.Save();
            PropertiesTester.AssertProperties(result, role);
            Assert.IsNotNull(result);
        }
    
         
        [TearDown]
        public void TearDown()
        {
            _unitOfWorkTenant.Dispose();
        }
    
        [OneTimeTearDown]
        public void TearDownOnce()
        {
            _unitOfWorkTenant.Dispose();
            base.TearDown_v(_database);
        }

    }
}