using System.ComponentModel.DataAnnotations;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Tenant;
using IdentityService.DataAccess.Database.Persistence.Validation;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Tenant
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public class User : BaseEntity, IUser
    {
        [Required]
        [MinLength(14)]
        public string Password { get; set; } = null!;
    
        [Required]
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; }= null!;
        public string? Phone { get; set; }
        public string? Company { get; set; }
        public string? Website { get; set; }
        public string? ImageUrl { get; set; }
        public string? Bio { get; set; }
        public int AccessFailedCount { get; set; } = 0;
        public string? ConcurrencyStamp { get; set; }
    
        [Required]
        public string? Email { get; set; } = null;
    
        [Required]
        public string Username { get; set; } = null!;
        public bool NeedsEmailConfirmation { get; set; } = false;
        public bool EmailConfirmed { get; set; } = false;
        public bool PhoneNumberConfirmed { get; set; } = false;
        public bool NeedsPhoneConfirmation { get; set; } = false;
    
        public Guid AddressGuid { get; set; }
    
        public List<string> ValidateWithMessage()
        {
            return this.UserValidation();
        }
    }
}