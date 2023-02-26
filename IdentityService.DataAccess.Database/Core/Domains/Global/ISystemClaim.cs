using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Global
{
    public interface ISystemClaim: IBaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}