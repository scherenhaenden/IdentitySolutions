using IdentityService.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests._Setup;

public interface IGetDbConnection
{
    public void Init();
    
    
    // Get a connection to the database
    public IdentityContext GetConnection();
    
    public IdentityContextGlobal GetConnectionGlobal();
    
    // Destroy the database
    public void Destroy();
    
}

public class GetDbConnectionInMemory : IGetDbConnection
{
    public void Init()
    {
        // nothing to do
    }

    public IdentityContext GetConnection()
    {
        var options = new DbContextOptionsBuilder<IdentityContext>()
            .UseInMemoryDatabase(databaseName: "IdentityService")
            .Options;

        return new IdentityContext(options);
    }

    public IdentityContextGlobal GetConnectionGlobal()
    {
        var options = new DbContextOptionsBuilder<IdentityContextGlobal>()
            .UseInMemoryDatabase(databaseName: "IdentityService")
            .Options;

        return new IdentityContextGlobal(options);
    }

    public void Destroy()
    {
        // No need to destroy the database
    }
}