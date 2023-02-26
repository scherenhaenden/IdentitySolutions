using Microsoft.EntityFrameworkCore;

namespace EFCoreDataContextManager.Core;

public class ContextGenerator: IContextGenerator
{
    private readonly string _connectionString;

    public ContextGenerator(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private IContextGenerator _contextGeneratorImplementation;
    public T GenerateContext<T>(DataBaseTypeAvailable dataBaseTypeAvailable) where T : DbContext
    {
        var dbContextOptionsBuilder = BeginGeneration<T>();

        if (dataBaseTypeAvailable == DataBaseTypeAvailable.Sqlite)
        {
            dbContextOptionsBuilder.UseSqlite(_connectionString);
        }
        else if(dataBaseTypeAvailable == DataBaseTypeAvailable.SqlServer)
        {
            //dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }
        else if(dataBaseTypeAvailable == DataBaseTypeAvailable.PostgreSql)
        {
            //dbContextOptionsBuilder.UseNpgsql(_connectionString);
        }
        else if (dataBaseTypeAvailable == DataBaseTypeAvailable.Oracle)
        {
            
        }
        else if (dataBaseTypeAvailable == DataBaseTypeAvailable.MySql)
        {
            dbContextOptionsBuilder.UseMySql(_connectionString,  ServerVersion.AutoDetect(_connectionString));
            
        }
        else if (dataBaseTypeAvailable == DataBaseTypeAvailable.InMemory)
        {
            //dbContextOptionsBuilder.UseInMemoryDatabase(_connectionString);
        }
        else
        {
            throw new Exception("DataBaseTypeAvailable not implemented");
        }
        
        
        
        //    .UseSqlite("Data Source=IdentityService.db");
        //.UseSqlite(_connectionString);
            
        /*.UseLazyLoadingProxies()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .EnableSensitiveDataLogging()
            .UseInternalServiceProvider(_contextFactory.GetServiceProvider());*/
        
        return CreateContext(dbContextOptionsBuilder);
    }
    
    private DbContextOptionsBuilder<T> BeginGeneration<T>() where T : DbContext
    {
        var options = new DbContextOptionsBuilder<T>();
        return options;
    }
    
    private T CreateContext<T>(DbContextOptionsBuilder<T> dbContextOptionsBuilder)where T : DbContext
    {
        var context = (T)Activator.CreateInstance(typeof(T), dbContextOptionsBuilder.Options);
        return context;
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
    
    /*// Generate Global Context for the current thread in postgres
       IdentityContextGlobal GenerateGlobalContextPostgres();
   
       // Generate Global Context for the current thread in Mysql
       IdentityContextGlobal GenerateGlobalContextMysql();
   
       // Generate Global Context for the current thread in Mssql
       IdentityContextGlobal GenerateGlobalContextMssql();
   
       // Generate Global Context for the current thread in Oracle
       IdentityContextGlobal GenerateGlobalContextOracle();
   
       // Generate Global Context for the current thread in Db2
       IdentityContextGlobal GenerateGlobalContextDb2();
   
       // Generate Global Context for the current thread in Firebird
       IdentityContextGlobal GenerateGlobalContextFirebird();*/
    
    
    
    
    
    
    // Generate Tenant Context for the current thread in sqlite
    
    //IdentityContextTenant GenerateTenantContextSqlite(string tenantId);
}