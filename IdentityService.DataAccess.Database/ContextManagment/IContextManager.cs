using IdentityService.DataAccess.Database.Persistence.Configuration;

namespace IdentityService.DataAccess.Database.ContextManagment;

public interface IContextManager
{
    IdentityContextGlobal GenerateGlobalContext(string type, string connection);
}

public class ContextManager: IContextManager
{
    public IContextGenerator _contextGenerator;

    public ContextManager()
    {
        
    }
    
    
    public IdentityContextGlobal GenerateGlobalContext(string type, string connection)
    {
        _contextGenerator = new ContextGenerator(connection);
        if (type.ToLower() == "sqlite")
        {
            return _contextGenerator.GenerateGlobalContextSqlite();
        }
        
        return _contextGenerator.GenerateGlobalContextSqlite();
        
        
    }
}