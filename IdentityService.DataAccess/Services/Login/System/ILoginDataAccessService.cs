using IdentityService.DataAccess.Services.Login.System.Models;

namespace IdentityService.DataAccess.Services.Login.System;

public interface ILoginDataAccessService
{
    GlobalUserCompactModel GetGlobalUserCompactModel(string usernameOrEmail, string password);
}

public class LoginDataAccessService : ILoginDataAccessService
{
    private readonly ILoginRepository _loginRepository;
    

    public LoginDataAccessService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
        
    }

    public GlobalUserCompactModel GetGlobalUserCompactModel(string usernameOrEmail, string password)
    {
        var user =_loginRepository.GetGlobalUserCompactModel(usernameOrEmail, password);
        if(user == null)
        {
            return null;
        }
        
        return user.MapFromRequest();
    }
}