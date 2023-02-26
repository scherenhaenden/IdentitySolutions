using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Database.Core.Domains.Global
{
    public interface ISystemRole: IBaseEntity
    {
        
        
        public string Name { get; set; }
    
        public string Description { get; set; }
    
        /* public string? Description { get; set; }
     public bool IsSystem { get; set; }
     public bool IsDefault { get; set; }
     public bool IsPublic { get; set; }
     public bool IsEnabled { get; set; }
     public bool IsDeleted { get; set; }
     public bool IsLocked { get; set; }
     public bool IsArchived { get; set; }
     public bool IsHidden { get; set; }
     public bool IsProtected { get; set; }
     public bool IsReadOnly { get; set; }
     public bool IsTransient { get; set; }
     public bool IsImmutable { get; set; }
     public bool IsImmutableSystem { get; set; }
     public bool IsImmutableDefault { get; set; }
     public bool IsImmutablePublic { get; set; }
     public bool IsImmutableEnabled { get; set; }
     public bool IsImmutableDeleted { get; set; }
     public bool IsImmutableLocked { get; set; }
     public bool IsImmutableArchived { get; set; }
     public bool IsImmutableHidden { get; set; }
     public bool IsImmutableProtected { get; set; }
     public bool IsImmutableReadOnly { get; set; }
     public bool IsImmutableTransient { get; set; }
     public bool IsImmutableImmutable { get; set; }
     public bool IsImmutableImmutableSystem { get; set; }
     public bool IsImmutableImmutableDefault { get; set; }
     public bool IsImmutableImmutablePublic { get; set; }
     public bool IsImmutableImmutableEnabled { get; set; }
     public bool IsImmutableImmutableDeleted { get; set; }
     public bool IsImmutableImmutableLocked { get; set; }
     public bool IsImmutableImmutableArchived { get; set; }
     public bool IsImmutableImmutableHidden { get; set; }
     public bool IsImmutableImmutableProtected { get; set; }
     public bool IsImmutableImmutableReadOnly { get; set; }
     public bool IsImmutableImmutableTransient { get; set; }
     public bool IsImmutableImmutableImmutable { get; set; }
     public bool IsImmutableImmutableImmutableSystem { get
    {*/
    }
}