using IdentityService.DataAccess.Database.Persistence.Configuration;

namespace IdentityService.DataAccess.Database.ContextManagement;

public interface IContextGenerator
{
    // Generate Global Context for the current thread in sqlite
    IdentityContextGlobal GenerateGlobalContextSqlite();
    
    // Generate Global Context for the current thread in postgres
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
    IdentityContextGlobal GenerateGlobalContextFirebird();
    
    
    
    
    
    
    // Generate Tenant Context for the current thread in sqlite
    
    //IdentityContextTenant GenerateTenantContextSqlite(string tenantId);
}