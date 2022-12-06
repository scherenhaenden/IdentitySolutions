using IdentityService.DataAccess.Database.Core.Unities;
using IdentityService.DataAccess.Database.Persistence.Unities;

namespace IdentityService.DataAccess.Database.Tests._Setup;

[Parallelizable(scope: ParallelScope.None)]
[NonParallelizable]
[TestFixture]
[FixtureLifeCycle(LifeCycle.SingleInstance)]
public class BaseSetup
{
    
    protected IUnitOfWorkTenant _unitOfWorkTenant;
    private IGetDbConnection _getDbConnection;
    public string? _database = null;
    
    [SetUp]
    public void Setup()
    {
        CreateConnection();
    }
    
    public IUnitOfWorkTenant GetUnitOfWork(string database)

    {
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Init();
        return new UnitOfWorkTenant(getDbConnection.GetConnection());
    }
    
    public IUnityOfWorkGlobal GetUnitOfWorkGlobal(string database)

    {
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Init();
        return new UnitOfWorkGlobal(getDbConnection.GetConnectionGlobal());
    }

    private void CreateConnection()
    {
        if(_getDbConnection == null)
        {
            if(_database == null)
            {
                _getDbConnection = new GetDbConnectionSqlite();
            }
            else
            {
                
                _getDbConnection = new GetDbConnectionSqlite(_database);
            }
            _getDbConnection.Init();
            _unitOfWorkTenant = new UnitOfWorkTenant(_getDbConnection.GetConnection());
        }
    }
    [TearDown]
    public void TearDown()
    {
        _getDbConnection.Destroy();

        // Tear down code goes here
    }
    
    public void TearDown_v(string database)
    {
        var getDbConnection = new GetDbConnectionSqlite(database);
        getDbConnection.Destroy();
    }
}




