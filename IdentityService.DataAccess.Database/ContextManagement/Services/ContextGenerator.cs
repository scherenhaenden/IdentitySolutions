using IdentityService.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.ContextManagement.Services
{
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
    
        private IdentityContextGlobal CreateContext(DbContextOptions<IdentityContextGlobal> options)
        {
            var context = new IdentityContextGlobal(options);
            return context;
        }
    
        private IdentityContextGlobal CreateContext(DbContextOptionsBuilder<IdentityContextGlobal> dbContextOptionsBuilder)
        {
            var context = new IdentityContextGlobal(dbContextOptionsBuilder.Options);
            return context;
        }

        public IdentityContextGlobal GenerateGlobalContextSqlite()
        {
        
    
            // Get Path to Database
            /*var path = Path.Combine(_currentDirectory,_databaseName);
            
            
                var options = new DbContextOptionsBuilder<IdentityContextGlobal>()
                    .UseSqlite($"Data Source={path}").Options;
    
                var context = new IdentityContextGlobal(options);
    
                return context;*/

            

            var dbContextOptionsBuilder =BeginGeneration()
                //    .UseSqlite("Data Source=IdentityService.db");
                .UseSqlite(_connectionString);
            
            /*.UseLazyLoadingProxies()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .EnableSensitiveDataLogging()
                .UseInternalServiceProvider(_contextFactory.GetServiceProvider());*/
        
            return CreateContext(dbContextOptionsBuilder);

        }

        /*public IdentityContextGlobal GenerateGlobalContextPostgres()
        {
        
            var dbContextOptionsBuilder =BeginGeneration()
                .UseNpgsql(_connectionString);
            return CreateContext(dbContextOptionsBuilder);
        }

        public IdentityContextGlobal GenerateGlobalContextMysql()
        {
            var dbContextOptionsBuilder =BeginGeneration()
                .UseMySQL(_connectionString);

            return CreateContext(dbContextOptionsBuilder);
        }

        public IdentityContextGlobal GenerateGlobalContextMssql()
        {
            var dbContextOptionsBuilder =BeginGeneration()
                .UseSqlServer(_connectionString);

            return CreateContext(dbContextOptionsBuilder);
        }

        public IdentityContextGlobal GenerateGlobalContextOracle()
        {
            var dbContextOptionsBuilder =BeginGeneration()
                .UseOracle(_connectionString);

            return CreateContext(dbContextOptionsBuilder);
        }

        public IdentityContextGlobal GenerateGlobalContextDb2()
        {
            /*
             *
             * DB2Connection connection = new DB2Connection(connectionString);
    connection.SystemNaming = true;
    optionsBuilder.UseDb2(connection,
        p =>
        {
            p.SetServerInfo(IBMDBServerType.AS400, IBMDBServerVersion.AS400_07_01);
            p.UseRowNumberForPaging();
            p.MaxBatchSize(1);
        });
             * /
        
            var dbContextOptionsBuilder =BeginGeneration()
                .UseDb2(_connectionString, p =>
                {
                    p.SetServerInfo(IBMDBServerType.LUW, IBMDBServerVersion.None);
                    p.UseRowNumberForPaging();
                    p.MaxBatchSize(1);
                });

            return CreateContext(dbContextOptionsBuilder);
        }

        public IdentityContextGlobal GenerateGlobalContextFirebird()
        {
            var dbContextOptionsBuilder =BeginGeneration()
                .UseFirebird(_connectionString);

            return CreateContext(dbContextOptionsBuilder);
        }*/
    }
}