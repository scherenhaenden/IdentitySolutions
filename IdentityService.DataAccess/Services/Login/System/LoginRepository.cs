using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Services.Login.System;

public class LoginRepository : ILoginRepository
{
    private readonly IUnityOfWorkGlobal _unityOfWorkGlobal;

    public LoginRepository(IUnityOfWorkGlobal unityOfWorkGlobal)
    {
        _unityOfWorkGlobal = unityOfWorkGlobal;
    }

    public SystemUser? GetGlobalUserCompactModel(string usernameOrEemail, string password)
    {
        return _unityOfWorkGlobal.GlobalUsers.SingleOrDefault(x => (x.Username == usernameOrEemail || x.Email == usernameOrEemail) && x.Password == password);
    }
}