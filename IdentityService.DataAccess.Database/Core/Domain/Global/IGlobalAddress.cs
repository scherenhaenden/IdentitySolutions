using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain.Global;

public interface IGlobalAddress : IBaseEntity
{
    string ExtraInformation { get; set; }
    string Level { get; set; }
    string NameOrNumberOfBuilding { get; set; }
    string Street { get; set; }
    string City { get; set; }
    string State { get; set; }
    string ZipCode { get; set; }
    string Country { get; set; }
}