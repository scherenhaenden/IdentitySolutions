namespace IdentityService.DataAccess.Services.Login.System.Models;

public class GlobalRoleDataAccessModel
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public List<GlobalClaimsDataAccessModel> SystemClaims { get; set; }
}