using IdentityService.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.ContextManagment;

public interface IContextGenerator
{
    // Generate Global Context for the current thread in sqlite
    IdentityContextGlobal GenerateGlobalContextSqlite();
}

public class ContextGenerator : IContextGenerator
{
    private readonly string _connectionString;


    public ContextGenerator(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    
    private DbContextOptionsBuilder<IdentityContextGlobal> BeginGeneration()
    {
        
        var options = new DbContextOptionsBuilder<IdentityContextGlobal>();
        return options;
    }

    public IdentityContextGlobal GenerateGlobalContextSqlite()
    {
        
    
            // Get Path to Database
            /*var path = Path.Combine(_currentDirectory,_databaseName);
        
        
            var options = new DbContextOptionsBuilder<IdentityContextGlobal>()
                .UseSqlite($"Data Source={path}").Options;

            var context = new IdentityContextGlobal(options);

            return context;*/

            

            var options =BeginGeneration()
            //    .UseSqlite("Data Source=IdentityService.db");
            .UseSqlite(_connectionString).Options;
            
            /*.UseLazyLoadingProxies()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .EnableSensitiveDataLogging()
            .UseInternalServiceProvider(_contextFactory.GetServiceProvider());*/

            try
            {
                var context = new IdentityContextGlobal(options);
                return context;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            var contexdt = new IdentityContextGlobal(options);
            return contexdt;
            
       


    }
}