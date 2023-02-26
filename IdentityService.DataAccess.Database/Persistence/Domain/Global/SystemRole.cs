using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global
{
    [Index(nameof(Name), IsUnique = true)]
    public class SystemRole:  BaseEntity, ISystemRole
    {
        
        public SystemRole()
        {
            SystemClaims = new HashSet<SystemClaim>();
            SystemUsers = new HashSet<SystemUser>();
        }
        
        public virtual ICollection<SystemClaim> SystemClaims { get; set; }
        public virtual ICollection<SystemUser> SystemUsers { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

    }
}