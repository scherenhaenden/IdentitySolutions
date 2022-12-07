using IdentityService.DataAccess.Database.ContextManagement.Models;
using IdentityService.DataAccess.Database.ContextManagement.Services;
using IdentityService.DataAccess.Database.Persistence.Configuration;

namespace IdentityService.DataAccess.Database.ContextManagement
{
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

        public IdentityContextGlobal GenerateGlobalContext(DataBaseType dataBaseType, string connection)
        {
            _contextGenerator = new ContextGenerator(connection);
            if (dataBaseType == DataBaseType.Sqlite)
            {
                return _contextGenerator.GenerateGlobalContextSqlite();
            }
        
            return _contextGenerator.GenerateGlobalContextSqlite();
        }
    }
}