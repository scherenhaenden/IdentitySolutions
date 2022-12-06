using IdentityService.DataAccess.Database.ContextManagement;
using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Unities;
using IdentityService.DataAccess.Database.Tests._Setup;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Tests.ContextManagement;

[TestFixture]
public class ContextManager_Test
{
   
    IUnityOfWorkGlobal _unityOfWorkGlobal;
    [SetUp]
    public void SetUp()
    {
        /*string databaseName="ContextManager_Test.db";
        //var connectionString = CreateString(CreateString());
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite(databaseName);
        _unityOfWorkGlobal = new UnitOfWorkGlobal(getDbConnection.GetConnectionGlobal());
        DeleteDatabase
    
    
        CreateString();*/
        DeleteDatabase();
    }
    
    private string CreateString(string databaseName="ContextManager_Test.db")
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        // Get Path to Database
        var path = Path.Combine(currentDirectory, databaseName);
        
       return $"Data Source={path};";
        
    }
    
    //Delete database after test
    private void DeleteDatabase(string databaseName="ContextManager_Test.db")
    {

        // Get Path to Database
        var path = GetStringSqlite_path(databaseName);
        
        // if file exists, delete it
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
    
    private string GetStringSqlite_path(string databaseName="ContextManager_Test.db")
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        
        // Get Path to Database
        var path = Path.Combine(currentDirectory, databaseName);

        return path;
    }
    
    

    
    
    // Write First Test
    [Test, Order(1)]
    public void ContextManagement_01_GenerateContextInSqlite()
    {
        IContextManager contextManager = new ContextManager();
        
        var result =contextManager.GenerateGlobalContext("sqlite", CreateString());
        
        Assert.IsNotNull(result);
        
        var currentDirectory = Directory.GetCurrentDirectory();
        
        var path = GetStringSqlite_path();
        
        Assert.IsTrue(File.Exists(path));

    }
}