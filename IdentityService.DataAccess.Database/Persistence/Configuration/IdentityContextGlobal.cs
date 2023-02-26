using System.Diagnostics.CodeAnalysis;
using IdentityService.DataAccess.Database.Core.Configuration;
using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.DataAccess.Database.Persistence.Configuration
{
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

        public DbSet<SystemUser> GlobalUsers { get; set; }
    
        public DbSet<SystemAddress> GlobalAddresses { get; set; }
    
        public DbSet<SystemRole> GlobalRoles { get; set; }

        public DbSet<SystemClaim> GlobalUserClaims { get; set; }

        //GlobalUserClaim
    }
}