using IdentityService.DataAccess.Database.Core.BaseDomain;
using IdentityService.DataAccess.Database.Core.Domain;

namespace IdentityService.DataAccess.Database.Persistence.Domain;

public class LoginType :BaseEntity,  ILoginType
{
    public string Name { get; set; }
    public string NameCode { get; set; }
    public string Description { get; set; }
}