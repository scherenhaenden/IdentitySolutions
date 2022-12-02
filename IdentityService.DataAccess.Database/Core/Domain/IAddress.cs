using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domain;

public interface IAddress : IBaseEntity
{
    string ExtraInformation { get; set; }
    string Level { get; set; }
    string NameOrNumberOfBuilding { get; set; }
    string Street { get; set; }
    string City { get; set; }
    string State { get; set; }
    string Zip { get; set; }
    string Country { get; set; }
}