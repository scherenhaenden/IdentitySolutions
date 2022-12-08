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

        public DbSet<SystemlUser> GlobalUsers { get; set; }
    
        public DbSet<SystemAddress> GlobalAddresses { get; set; }
    
        public DbSet<GlobalRole> GlobalRoles { get; set; }

        public DbSet<GlobalClaim> GlobalUserClaims { get; set; }

        //GlobalUserClaim
    }
}