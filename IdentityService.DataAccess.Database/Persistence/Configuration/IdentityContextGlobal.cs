using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Configuration;

public class IdentityContextGlobal : DbContext, IContextGlobal
{
    public IdentityContextGlobal(DbContextOptions<IdentityContextGlobal> options) : base(options)
    {
        try
        {
            base.Database.EnsureCreated();   
        }catch(Exception ex)
        {
            
        }
        finally{}
        
    }

    public DbSet<GlobalUser> GlobalUsers { get; set; }
}