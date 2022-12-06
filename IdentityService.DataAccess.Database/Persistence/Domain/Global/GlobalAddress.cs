using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domains.Global;

namespace IdentityService.DataAccess.Database.Persistence.Domain.Global;

public class GlobalAddress: BaseEntity, IGlobalAddress
{
    public string? ExtraInformation { get; set; }
    public string? Level { get; set; }
    public string NameOrNumberOfBuilding { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string Country { get; set; } = null!;
}