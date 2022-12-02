using IdentityService.DataAccess.Database.Core.BaseDomain;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace IdentityService.DataAccess.Database.Tests.Helpers;

public class PropertiesTester
{
    public static void AssertProperties (object objA, object objB)
    {
        var type = objA.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var valueA = property.GetValue(objA);
            var valueB = property.GetValue(objB);
            Assert.AreEqual(valueA, valueB);
        }
    }
    
    public static void AssertOnNewAndOnUpdate (BaseEntity baseEntity)
    {
        Assert.IsTrue(baseEntity.Guid == Guid.Empty);
        Assert.IsTrue(baseEntity.InsertedDate < DateTime.MinValue.AddDays(1));
        Assert.IsTrue(baseEntity.UpdatedDate < DateTime.MinValue.AddDays(1));
        
        baseEntity.OnNew();
        Assert.IsTrue(baseEntity.Guid != Guid.Empty);
        Assert.IsTrue(baseEntity.InsertedDate > DateTime.Now.AddMinutes(-1));
        var onNewDate = baseEntity.UpdatedDate;
        Assert.IsTrue(baseEntity.UpdatedDate > DateTime.Now.AddMinutes(-1));
        baseEntity.OnUpdate();
        var onUpdateDate = baseEntity.UpdatedDate;
        Assert.IsTrue(baseEntity.UpdatedDate > DateTime.Now.AddMinutes(-1));
        Assert.AreNotEqual(onNewDate, onUpdateDate);
        
        //Assert.IsTrue(baseEntity.UpdatedAt > DateTime.MinValue);
        
        
    }
    
}