namespace IdentityService.Web.BusinessLogic.Services.Login;

public interface ILoginService
{
    bool Login(string username, string password);
    
    bool Logout();
    
    bool IsLoggedIn();
}

public class LoginService : ILoginService
{
    //private readonly ILoginRepository _loginRepository;
    
    /*public LoginService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }*/
    public bool _isLoggedIn = false;
    
    public bool Login(string username, string password)
    {
        //return _loginRepository.Login(username, password);
        
        if(username == "admin" && password == "admin")
        {
            _isLoggedIn = true;
            return true;
        }
      
        return false;
      


    }
    
    public bool Logout()
    {
        //return _loginRepository.Logout();
        return false;
    }
    
    public bool IsLoggedIn()
    {
        //return _loginRepository.IsLoggedIn();
        return false;
    }
}