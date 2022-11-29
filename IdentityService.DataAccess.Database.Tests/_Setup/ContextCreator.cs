using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests._Setup;

public class ContextCreator
{
    public IdentityContext CreateInMemory()
    {
        var options = new DbContextOptionsBuilder<IdentityContext>()
            .UseInMemoryDatabase(databaseName: "Test").Options;

        var context = new IdentityContext(options);
            
            
                

        return context;
        //return CreateInMysql();
    }
    
}