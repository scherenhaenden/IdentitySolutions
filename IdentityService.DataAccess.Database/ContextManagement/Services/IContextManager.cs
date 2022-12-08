using IdentityService.DataAccess.Database.ContextManagement.Models;
using IdentityService.DataAccess.Database.Persistence.Configuration;

namespace IdentityService.DataAccess.Database.ContextManagement.Services
{
    public interface IContextManager
    {
        /// <summary>
        /// GenerateGlobalContext generates a global context for the application.
        /// it can be generated for different databases
        /// <para name="type"> type: string value for sqlite, mysql, mssql, etc</para>
        /// <param name="connection"> raw connectionstring</param>
        /// </summary>
        IdentityContextGlobal GenerateGlobalContext(string type, string connection);
    
        /// <summary>
        /// GenerateGlobalContext generates a global context for the application.
        /// it can be generated for different databases
        /// <para name="type"> type: string value for sqlite, mysql, mssql, etc</para>
        /// <param name="connection"> raw connectionstring</param>
        /// </summary>
        IdentityContextGlobal GenerateGlobalContext(DataBaseType dataBaseType, string connection);
    }
}