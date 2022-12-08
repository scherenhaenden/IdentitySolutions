using Helpers.Configuration.Models;

namespace Helpers.Configuration.Core;

public interface IDataBasesManagerForTests
{
    void DatabaseTearDown();
}

public class DataBasesManagerForTests: IDataBasesManagerForTests
{
    private readonly DatabaseType _databaseType;
    private readonly string _connectionString;


    public DataBasesManagerForTests(DatabaseType databaseType,  string connectionString)
    {
        _databaseType = databaseType;
        _connectionString = connectionString;
    }
    
    // Find Out Type of Database and call the appropriate method
    public void DatabaseTearDown()
    {
        switch (_databaseType)
        {
            case DatabaseType.Sqlite:
                SqliteDatabaseTearDown();
                break;
            /*case DatabaseTypeName.PostgreSql:
                PostgreSqlDatabaseTearDown();
                break;*/
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    // Drop Database sqlite
    private void SqliteDatabaseTearDown()
    {
        var databaseName = _connectionString.Split('/').Last();
        var databasePath = _connectionString.Split(databaseName).First();
        var databaseFullPath = Path.Combine(databasePath, databaseName).Replace("Data Source=", "");;
        if (File.Exists(databaseFullPath))
        {
            File.Delete(databaseFullPath);
        }
    }
    
    // Drop Database
    /*private void SqlServerDatabaseTearDown()
    {
        var databaseName = new SqlConnectionStringBuilder(_connectionString).InitialCatalog;
        var masterConnectionString = _connectionString.Replace(databaseName, "master");
        using (var connection = new SqlConnection(masterConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                command.ExecuteNonQuery();
                command.CommandText = $"DROP DATABASE [{databaseName}]";
                command.ExecuteNonQuery();
            }
        }
    }*/
}