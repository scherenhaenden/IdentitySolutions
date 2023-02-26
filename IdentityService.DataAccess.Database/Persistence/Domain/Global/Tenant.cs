using System.ComponentModel.DataAnnotations;
using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

public class Tenant:  BaseEntity, ITenant
{
    [Required]
    public string Name { get; set; } = null!;
        
    [Required]
    public string Description { get; set; } = null!;
        
    [Required]
    public string Domain { get; set; } = null!;
    public string? Configuration { get; set; }
}