using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant
{
    public interface ILoginInformation : IBaseEntity
    {
        public string JsonLoginData { get; set; }
        //public bool TwoFactorEnabled { get; set; }
    }
}