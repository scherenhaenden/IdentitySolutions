using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistance.Unities;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests._Setup;


public class BaseSetup
{
    
    protected IUnitOfWork _unitOfWork;
    private IGetDbConnection _getDbConnection;
    [OneTimeSetUp]
    public void Setup()
    {
        // Setup code goes here
        _getDbConnection = new GetDbConnectionSqlite();
        _getDbConnection.Init();
        
        
        _unitOfWork = new UnitOfWork(_getDbConnection.GetConnection());
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _getDbConnection.Destroy();
        // Tear down code goes here
    }
}