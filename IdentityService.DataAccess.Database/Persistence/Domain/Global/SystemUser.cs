using System.ComponentModel.DataAnnotations;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class SystemUser: BaseEntity, ISystemUser
    {
        
        public SystemUser()
        {
            DirectlyAssignClaims = new HashSet<SystemClaim>();
            Roles = new HashSet<SystemRole>();
        }
        
        
        [Required]
        public string Email { get; set; } = null!;
    
        [Required]
        public string Username { get; set; } = null!;
        
        [Required]
        public string FirstName { get; set; } = null!;
        
        [Required]
        public string LastName { get; set; } = null!;
        
        [Required]
        public string Password { get; set; } = null!;
        public Guid AddressGuid { get; set; }

        public virtual ICollection<SystemClaim>? DirectlyAssignClaims{ get; set; }
        public virtual ICollection<SystemRole>? Roles { get; set; }

        public List<string> ValidateWithMessage()
        {
            return this.GlobalUserValidation();
        }
    }
}