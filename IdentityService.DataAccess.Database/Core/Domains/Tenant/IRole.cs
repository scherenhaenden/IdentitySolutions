using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant
{
    public interface IRole: IBaseEntity
    {
        public string CodeName { get; set; }
        public string NormalizedName { get; set; }
    }
}