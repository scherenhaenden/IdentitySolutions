using System.ComponentModel.DataAnnotations;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class SystemlUser: BaseEntity, ISystemlUser
    {
        
        public SystemlUser()
        {
            DirectlyAssignClaims = new HashSet<GlobalClaim>();
            Roles = new HashSet<GlobalRole>();
        }
        
        
        [Required]
        public string Email { get; set; } = null!;
    
        [Required]
        public string Username { get; set; } = null!;
        
        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid AddressGuid { get; set; }
        public Guid Tenant { get; set; }

        public virtual ICollection<GlobalClaim>? DirectlyAssignClaims{ get; set; }
        public virtual ICollection<GlobalRole>? Roles { get; set; }

        public List<string> ValidateWithMessage()
        {
            return this.GlobalUserValidation();
        }
    }
}