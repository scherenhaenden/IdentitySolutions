using IdentityService.DataAccess.Database.Persistence.Domain.Tenant;
using IdentityService.DataAccess.Database.Persistence.Validation;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests.Tests.Domains.Tenant
{
    [TestFixture]
    public class RulesUser:BaseSetup
    {
        private new string _database = $"RulesUser.db";

        public RulesUser()
        {
            base._database = _database;
        
        }
        // Setup
        [OneTimeSetUp]
        public void Setup()
        {
            _unitOfWorkTenant = base.GetUnitOfWork(_database);
        }
    
        // Write first test should pass
        // Write First Testv
        [Test, Order(1)]
        public void DDD_01_UserCompact_SaveUserAndTestIt_shouldPass()
        {
            //_unitOfWork = base.GetUnitOfWork(_database);
            var user = new User();
            user.Username = "Test";
            user.Email = "email@email.com";
            user.Password = "fsdfsdfdsfdsfs";
            user.FirstName = "Test";
            user.LastName = "Test";
            user.Password = "fsdfsdfsfdsfsdfdsfdsfdsfds";

            var userAfterSaved = _unitOfWorkTenant.User.Add(user);
            _unitOfWorkTenant.Save();
            Assert.IsNotNull(userAfterSaved);

            var sameUser = _unitOfWorkTenant.User.Get(user.Guid);
        
            PropertiesTester.AssertProperties(user, sameUser);

        }
    
    
    
        // Write Second Test DDD_USerCompact_shouldFail
        [Test, Order(2)]
        public void DDD_02_UserCompact_shouldFail_UsernameIsBeingUsed()
        {
            var userCompact = new User();
            userCompact.Username = "Test";
            userCompact.Email = "email2@email.com";
            userCompact.Password = "asfafasffa";
            userCompact.FirstName = "Test";
            userCompact.LastName = "Test";

            var errors = userCompact.ValidateWithMessage();
        
            Assert.IsTrue(errors.Count < 1);


            _unitOfWorkTenant.User.Add(userCompact);
            Assert.Throws<DbUpdateException>(()=>_unitOfWorkTenant.Save());
        
        }
    
        // Write Third Test DDD_UserCompact_shouldFail
        [Test, Order(3)]
        public void DDD_03_UserCompact_shouldFail_email_is_registered()
        {
            var user = new User();
            user.Username = "Test2";
            user.Email = "email@email.com";
            user.Password = "dsfsdfsd";
        
            var errors = user.ValidateWithMessage();
            Assert.IsTrue(errors.Count < 1);

            _unitOfWorkTenant.User.Add(user);
            Assert.Throws<DbUpdateException>(() => _unitOfWorkTenant.Save());
        }
    
        // Write Fourth Test DDD_UserCompact_shouldFail
        [Test, Order(4)]
        public void DDD_04_UserCompact_shouldFail_Did_not_passed_validation()
        {
            var userCompact = new User();
            userCompact.Username = "";
            userCompact.Email = "";
            userCompact.Password = "";

            var errors = userCompact.ValidateWithMessage();
            Assert.IsTrue(errors.Count == 3);

            Assert.IsNotNull(errors.Any(X => X == ModelValidationMessages.PASSWORD_IS_NOT_VALID));
            Assert.IsNotNull(errors.Any(X => X == ModelValidationMessages.USERNAME_IS_NOT_VALID));
            Assert.IsNotNull(errors.Any(X => X == ModelValidationMessages.EMAIL_IS_NOT_VALID));
        }
    
        [Test, Order(5)]
        public void DDD_05_User_shouldPass()
        {
        
            _database ="Lola.db";
            Setup();

            var users = _unitOfWorkTenant.User.GetAll().ToList();
            // TODO: Address should not be here
            var user = new User();
            user.Username = "sTrrrest-1";
            user.FirstName = "sTrrrest-1";
            user.LastName = "sTrrrest-1";
            user.Email = "emailv2@email.com";
            user.Password = "fsdfsdfdsfdsfswerwerew";
            user.Phone = "1234567890";
            user.Company = "Company";
            user.Website = "www.company.com";
            user.ImageUrl = "www.company.com/image.jpg";
            user.Bio = "This is a bio";
            user.AccessFailedCount = 0;
            user.ConcurrencyStamp = "";
            user.NeedsEmailConfirmation = false;
            user.EmailConfirmed = false;
        
            // TODO: this is twice

            user.PhoneNumberConfirmed = false;
            user.NeedsPhoneConfirmation = false;
            user.OnNew();
        
            //user.Guid
            try
            {
                var result = _unitOfWorkTenant.User.Add(user);
                _unitOfWorkTenant.Save();
                Assert.IsNotNull(result);
            }
            catch (Exception e)
            {
                TearDown_v(_database);
            }
        }
    
        [TearDown]
        public void TearDown()
        {
            base.TearDown_v(_database);
            // Tear down code goes here
        }
    }
}