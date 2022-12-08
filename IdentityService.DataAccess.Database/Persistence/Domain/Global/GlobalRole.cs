using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global
{
    [Index(nameof(Name), IsUnique = true)]
    public class GlobalRole:  BaseEntity, IGlobalRole
    {
        
        public GlobalRole()
        {
            SystemClaims = new HashSet<GlobalClaim>();
            SystemUsers = new HashSet<SystemlUser>();
        }
        
        public virtual ICollection<GlobalClaim> SystemClaims { get; set; }
        public virtual ICollection<SystemlUser> SystemUsers { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

    }
}