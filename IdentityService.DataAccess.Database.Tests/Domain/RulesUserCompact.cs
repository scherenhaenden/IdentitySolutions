using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistance.Domain;
using IdentityService.DataAccess.Database.Persistance.Unities;
using IdentityService.DataAccess.Database.Tests._Setup;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Domain;

[TestFixture]
public class RulesUserCompact:BaseSetup
{
    //private IUnitOfWork _unitOfWork;
    
 
    
    
    // Write First Test
    [Test, Order(1)]
    public void DDD_01_UserCompact_shouldPass()
    {
        var userCompact = new UserCompact();
        userCompact.Guid = Guid.NewGuid();
        userCompact.Username = "Test";
        userCompact.Email = "email@email.com";
        userCompact.Password = "fsdfsdfdsfdsfs";

        var result = _unitOfWork.UserCompact.Add(userCompact);
        _unitOfWork.Save();
        Assert.IsNotNull(result);
    }
    
    // Write Second Test DDD_USerCompact_shouldFail
    [Test, Order(2)]
    public void DDD_02_UserCompact_shouldFail()
    {
        var userCompact = new UserCompact();
        userCompact.Guid = Guid.NewGuid();
        userCompact.Username = "Test";
        userCompact.Email = "email2@email.com";
        userCompact.Password = "asfafasffa";

        var errors = userCompact.ValidateWithMessage();
        
        Assert.IsTrue(errors.Count < 1);


        _unitOfWork.UserCompact.Add(userCompact);
        Assert.Throws<DbUpdateException>(()=>_unitOfWork.Save());
    }
    
    // Write Third Test DDD_UserCompact_shouldFail
    [Test, Order(3)]
    public void DDD_03_UserCompact_shouldFail()
    {
        var userCompact = new UserCompact();
        userCompact.Guid = Guid.NewGuid();
        userCompact.Username = "Test2";
        userCompact.Email = "email@email.com";
        userCompact.Password = "dsfsdfsd";
        
        var errors = userCompact.ValidateWithMessage();
        Assert.IsTrue(errors.Count < 1);

        _unitOfWork.UserCompact.Add(userCompact);
        Assert.Throws<DbUpdateException>(() => _unitOfWork.Save());
    }
    
    // Write Fourth Test DDD_UserCompact_shouldFail
    [Test, Order(4)]
    public void DDD_04_UserCompact_shouldFail()
    {
        var userCompact = new UserCompact();
        userCompact.Guid = Guid.NewGuid();
        userCompact.Username = "";
        userCompact.Email = "";
        userCompact.Password = "";

        var errors = userCompact.ValidateWithMessage();
        Assert.IsTrue(errors.Count == 3);
    }


}