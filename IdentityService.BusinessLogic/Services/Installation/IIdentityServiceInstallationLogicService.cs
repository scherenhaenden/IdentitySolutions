using IdentityService.DataAccess.Services.Installation;
using Newtonsoft.Json;

namespace IdentityService.BusinessLogic.Services.Installation
{
    public interface IIdentityServiceInstallationLogicService
    {
        object Install(InstallationModel model);
    }

    public class IdentityServiceInstallationLogicService : IIdentityServiceInstallationLogicService
    {
        /*private readonly IIdentityServiceDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
    
        public InstallationService(IIdentityServiceDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }
    
        public async Task InstallAsync()
        {
            await _dbContext.Database.MigrateAsync();
    
            if (!_dbContext.SystemUsers.Any())
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = "*/
        public object Install(InstallationModel model)
        {
            IIdentityServiceInstallationDataAccessService installationDataAccessService = new IdentityServiceInstallationDataAccessService();
            var value = installationDataAccessService.Install(model);
         
            // Obj to json
            var json = JsonConvert.SerializeObject(value);
            return json;

        }
   
    }
}
/*
public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }
    public string AdminEmail { get; set; }
    public string UserName { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPasswordConfirm { get; set; }
}

public enum DatabaseType
{
    MsSql,
    Sqlite,
    PostgreSql,
    MSSQlS,
}*/
                
                