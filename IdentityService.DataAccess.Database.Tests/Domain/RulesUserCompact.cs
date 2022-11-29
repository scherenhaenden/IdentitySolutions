using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistance.Domain;
using IdentityService.DataAccess.Database.Persistance.Unities;
using IdentityService.DataAccess.Database.Tests._Setup;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Domain;

[TestFixture]
public class RulesUserCompact
{
    private IUnitOfWork _unitOfWork;
    
    // Write Setup
    [SetUp]
    public void Setup()
    {

        var contextCreator = new ContextCreator();
        
        
        _unitOfWork = new UnitOfWork(contextCreator.CreateInMemory());
    }
    
    // Write First Test
    [Test]
    public void DDD_UserCompact_shouldPass()
    {
        var userCompact = new UserCompact();
        userCompact.Guid = Guid.NewGuid();
        userCompact.Username = "Test";
        userCompact.Email = "";
        userCompact.Password = "";

        var result = _unitOfWork.UserCompact.Add(userCompact);
        
        
        Assert.IsNotNull(result);
        
        
    }
    
}