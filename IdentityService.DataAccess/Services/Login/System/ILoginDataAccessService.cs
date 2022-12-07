using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Services.Login.System;

public interface ILoginDataAccessService
{
    GlobalUserCompactModel GetGlobalUserCompactModel(string username, string email, string password);
}

public class LoginDataAccessService : ILoginDataAccessService
{
    private readonly ILoginRepository _loginRepository;
    

    public LoginDataAccessService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
        
    }
    public GlobalUserCompactModel GetGlobalUserCompactModel(string username, string email, string password)
    {
        var user =_loginRepository.GetGlobalUserCompactModel(username, email, password);
        if(user == null)
        {
            return null;
        }
        
        return user.MapFromRequest();
    }
}



public interface ILoginRepository
{
    GlobalUser? GetGlobalUserCompactModel(string username, string email, string password);
}

public class LoginRepository : ILoginRepository
{
    private readonly IUnityOfWorkGlobal _unityOfWorkGlobal;

    public LoginRepository(IUnityOfWorkGlobal unityOfWorkGlobal)
    {
        _unityOfWorkGlobal = unityOfWorkGlobal;
    }
    
    
    public GlobalUser? GetGlobalUserCompactModel(string username, string email, string password)
    {
        
        return  _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => x.Username == username && x.Email == email && x.Password == password);
        
    }
}