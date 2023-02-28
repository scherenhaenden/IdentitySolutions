using IdentityService.DataAccess.Database.Core.BaseDomain;

namespace IdentityService.DataAccess.Database.Core.Domains.Tenant;

public interface IAuditLog: IBaseEntity
{
    public int UserId { get; set; } // TODO: change this to IUser
    public string EventType { get; set; }
    public DateTime Timestamp { get; set; }
    public string AdditionalInfo { get; set; }
}