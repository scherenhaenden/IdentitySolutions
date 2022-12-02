using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests._Setup;

public class ContextCreator
{
    
    // Create Database of type in Memory
    public IdentityContext CreateInMemory()
    {
        var options = new DbContextOptionsBuilder<IdentityContext>()
            .UseInMemoryDatabase(databaseName: "Test").Options;

        var context = new IdentityContext(options);
            
            
                

        return context;
        //return CreateInMysql();
    }
    
    // Create Database of type Sqlite
    public IdentityContext CreateInSqlite()
    {
        // Get Current Directory
        var currentDirectory = Directory.GetCurrentDirectory();
        
        // Get Path to Database
        var path = Path.Combine(currentDirectory, "Test.db");
        
        
        var options = new DbContextOptionsBuilder<IdentityContext>()
            .UseSqlite($"Data Source={path}").Options;

        var context = new IdentityContext(options);

        return context;
    }
    
}