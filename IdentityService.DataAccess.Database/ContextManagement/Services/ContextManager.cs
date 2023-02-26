using EFCoreDataContextManager.Core;
using IdentityService.DataAccess.Database.ContextManagement.Models;
using IdentityService.DataAccess.Database.Persistence.Configuration;

namespace IdentityService.DataAccess.Database.ContextManagement.Services
{
    public class ContextManager: IContextManager
    {
        public IdentityContextGlobal GenerateGlobalContext(string type, string connection)
        {
             
            IContextGenerator contextGenerator = new ContextGenerator(connection);

            DataBaseTypeAvailable dataBaseTypeAvailable = Map(type);

            return contextGenerator.GenerateContext<IdentityContextGlobal>(dataBaseTypeAvailable);
        }

        public IdentityContextGlobal GenerateGlobalContext(DataBaseType dataBaseType, string connection)
        {
             
             IContextGenerator contextGenerator = new ContextGenerator(connection);

             var name = Enum.GetName(typeof(DataBaseType), dataBaseType);
             var mapped = Map(name);

             
             return contextGenerator.GenerateContext<IdentityContextGlobal>(mapped);
        }

        private DataBaseTypeAvailable Map(string type)
        { 
             DataBaseTypeAvailable dataBaseTypeAvailable = DataBaseTypeAvailable.Sqlite;
             
             if(type.ToLower() == "sqlite")
            {
                 dataBaseTypeAvailable = DataBaseTypeAvailable.Sqlite;
            }
            else if(type.ToLower() == "sqlserver")
            {
                 dataBaseTypeAvailable = DataBaseTypeAvailable.SqlServer;
            }
            else if(type.ToLower() == "mysql")
            {
                 dataBaseTypeAvailable = DataBaseTypeAvailable.MySql;
            }
            else if(type.ToLower() == "postgresql")
            {
                 dataBaseTypeAvailable = DataBaseTypeAvailable.PostgreSql;
            }
            else if(type.ToLower() == "oracle")
            {
                 dataBaseTypeAvailable = DataBaseTypeAvailable.Oracle;
            }
            /*else if(type.ToLower() == "firebird")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.Firebird;
            }
            else if(type.ToLower() == "db2")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.DB2;
            }
            else if(type.ToLower() == "sybase")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.Sybase;
            }
            else if(type.ToLower() == "access")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.Access;
            }
            else if(type.ToLower() == "sqlce")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SqlCe;
            }
            else if(type.ToLower() == "informix")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.Informix;
            }
            else if(type.ToLower() == "sybasease")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseAse;
            }
            else if(type.ToLower() == "sybaseiq")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseIQ;
            }
            else if(type.ToLower() == "sybaseanywhere")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseAnywhere;
            }
            else if(type.ToLower() == "sybaseasa")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseASA;
            }
            else if(type.ToLower() == "sybaseadaptive")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseAdaptive;
            }
            else if(type.ToLower() == "sybaseaseoledb")
            {
                 dataBaseType = EFCoreDataContextManager.Core.DataBaseType.SybaseAseOleDb;
               }*/
            return dataBaseTypeAvailable;
        }
    }
}