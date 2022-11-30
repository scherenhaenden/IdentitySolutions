using IdentityService.DataAccess.Database.Persistance.Domain;
using IdentityService.DataAccess.Database.Tests._Setup;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Domain;

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
        _unitOfWork = base.GetUnitOfWork(_database);
    }
    
    // Write first test should pass
    [Test]
    public void DDD_01_User_shouldPass()
    {

        // TODO: Address should not be here
        var user = new User();
        user.Guid = Guid.NewGuid();
        user.FirstName = "Geronimo";
        user.LastName = "Tarzan";
        user.Phone = "1234567890";
        user.Address = "1234 Main St";
        user.City = "New York";
        user.State = "NY";
        user.Zip = "12345";
        user.Country = "USA";
        user.Company = "Company";
        user.Website = "www.company.com";
        user.ImageUrl = "www.company.com/image.jpg";
        user.Bio = "This is a bio";
        user.AccessFailedCount = 0;
        user.ConcurrencyStamp = "";
        user.Email = "email@email.com";
        user.NeedsEmailConfirmation = false;
        user.EmailConfirmed = false;
        // TODO: this is twice
        
        user.PhoneNumber = "123456789";
        user.PhoneNumberConfirmed = false;
        user.NeedsPhoneConfirmation = false;
        
        
        var result = _unitOfWork.User.Add(user);
        _unitOfWork.Save();
        Assert.IsNotNull(result);
            
        
        
        
        
        
        
    }
    
    [TearDown]
    public void TearDown()
    {
        base.TearDown_v(_database);
        // Tear down code goes here
    }
}