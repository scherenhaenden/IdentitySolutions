using System.Diagnostics.CodeAnalysis;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IdentityService.DataAccess.Database.Tests.Helpers
{
    [ExcludeFromCodeCoverage]
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
        
        // Asset all properties of generic type
        public static void AssertProperties<T>(T objA, T objB)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var valueA = property.GetValue(objA);
                var valueB = property.GetValue(objB);
                Assert.AreEqual(valueA, valueB);
            }
        }
        
        // Asset all properties of generic type are not null
        public static void AssertPropertiesNotNull<T>(T objA)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var valueA = property.GetValue(objA);
                Assert.IsNotNull(valueA);
            }
        }
        
        // Asset all properties of generic type fields of object are not null
        public static void AssertPropertiesNotNull<T>(object objA)
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            
            
            
            // get properties of type T
            var propertiesOfType = properties
                .Where(x => x.GetType() == type);
          
            
            foreach (var property in properties)
            {
                var valueA = property.GetValue(objA);
                Assert.IsNotNull(valueA);
            }
        }
        
        public static void AssertProperties (object objA, object objB, params string[] ignoreProperties)
        {
            var type = objA.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (ignoreProperties.Contains(property.Name))
                    continue;
                
                var valueA = property.GetValue(objA);
                var valueB = property.GetValue(objB);
                Assert.AreEqual(valueA, valueB);
            }
        }

        public static void AssertAfterNew(BaseEntity baseEntity)
        {
            Assert.IsTrue(baseEntity.Guid != Guid.Empty);
            Assert.IsTrue(baseEntity.InsertedDate < DateTime.Now.AddHours(1));
            Assert.IsTrue(baseEntity.UpdatedDate < DateTime.Now.AddHours(1));
            
            Assert.IsTrue(baseEntity.InsertedDate > DateTime.Now.AddHours(-1));
            Assert.IsTrue(baseEntity.UpdatedDate > DateTime.Now.AddHours(-1));
        }
        
        public static void AssertAfterUpdate(BaseEntity baseEntity, BaseEntity Updated)
        {
            
            Assert.IsTrue(baseEntity.InsertedDate == Updated.InsertedDate);
            Assert.IsTrue(baseEntity.InsertedDate < Updated.UpdatedDate);
        }
    
        public static void AssertOnNewAndOnUpdate (BaseEntity baseEntity)
        {
            Assert.IsTrue(baseEntity.Guid == Guid.Empty);
            Assert.IsTrue(baseEntity.InsertedDate < DateTime.MinValue.AddDays(1));
            Assert.IsTrue(baseEntity.UpdatedDate < DateTime.MinValue.AddDays(1));
            Thread.Sleep(10);
            baseEntity.OnNew();
            Assert.IsTrue(baseEntity.Guid != Guid.Empty);
            Assert.IsTrue(baseEntity.InsertedDate > DateTime.Now.AddMinutes(-1));
            var onNewDate = baseEntity.UpdatedDate;
            Assert.IsTrue(baseEntity.UpdatedDate > DateTime.Now.AddMinutes(-1));
            Thread.Sleep(10);
            baseEntity.OnUpdate();
            var onUpdateDate = baseEntity.UpdatedDate;
            Assert.IsTrue(baseEntity.UpdatedDate > DateTime.Now.AddMinutes(-1));
            Assert.AreNotEqual(onNewDate, onUpdateDate);
        
            //Assert.IsTrue(baseEntity.UpdatedAt > DateTime.MinValue);
        
        
        }
    
    }
}