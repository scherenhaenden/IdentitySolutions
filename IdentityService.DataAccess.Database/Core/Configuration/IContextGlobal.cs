using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Core.Configuration;

public interface IContextGlobal
{
    // Add all the fields from the name space IdentityService.DataAccess.Database.Core.Domain
    public DbSet<GlobalUser> GlobalUsers { get; set; }
    
    public DbSet<GlobalAddress> GlobalAddresses { get; set; }

}