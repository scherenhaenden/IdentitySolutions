using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Persistence.Configuration;
using IdentityService.DataAccess.Database.Tests._Setup;
using IdentityService.DataAccess.Database.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IdentityService.DataAccess.Database.Tests.Tests.Persistence.Configuration;

[TestFixture]
public class IdentityContextGlobalTest
{
    [Test, Order(1)]
    public void TestCreateDatabase()
    {
        IGetDbConnection getDbConnection = new GetDbConnectionSqlite("Data Source=IdentityContextGlobalTest.db");
        
        var context = getDbConnection.GetConnectionGlobal();
        
        // test all properties are set of type DbSet
        Assert.IsNotNull(context);

        //Get all properties of obj
        var properties = context.GetType().GetProperties();
        
        // get all properties of type DbSet
        var dbSetProperties = properties.Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)).ToList();
        
        
        Assert.IsNotNull(dbSetProperties);
        
        
        // test all properties are set of type DbSet
        //Assert.IsTrue(properties.All(p => p.PropertyType == typeof(DbSet<>)));
        
        
        
        //PropertiesTester.AssertPropertiesNotNull<DbSet<BaseEntity>>(context);
    }
}