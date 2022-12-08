using System.Diagnostics.CodeAnalysis;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Tests._Setup
{
    [ExcludeFromCodeCoverage]
    public class GetDbConnectionSqlite: IGetDbConnection
    {
        private readonly string _databaseName;
        private string _currentDirectory = Directory.GetCurrentDirectory();
    

        public GetDbConnectionSqlite()
        {
            _databaseName = "Test.db";
        }
    
        public GetDbConnectionSqlite(string databaseName)
        {
            _databaseName = databaseName;
        }

        public void Init()
        {
            // check if file exists and if exists delete it
            var path = Path.Combine(_currentDirectory, _databaseName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public IdentityContext GetConnection()
        {
            // Get Path to Database
            var path = Path.Combine(_currentDirectory,_databaseName);
        
        
            var options = new DbContextOptionsBuilder<IdentityContext>()
                .UseSqlite($"Data Source={path}").Options;

            var context = new IdentityContext(options);

            return context;
        }

        public IdentityContextGlobal GetConnectionGlobal()
        {
            // Get Path to Database
            var path = Path.Combine(_currentDirectory,_databaseName);
        
        
            var options = new DbContextOptionsBuilder<IdentityContextGlobal>()
                .UseSqlite($"Data Source={path}").Options;

            var context = new IdentityContextGlobal(options);

            return context;
        }

        public void Destroy()
        {
            var path = Path.Combine(_currentDirectory, _databaseName);
        
            // delete the database
            File.Delete(path);
        
        }
    }
}