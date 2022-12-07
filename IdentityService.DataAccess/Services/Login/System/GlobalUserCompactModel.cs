namespace IdentityService.DataAccess.Services.Login.System;

public class GlobalUserCompactModel
{
    public Guid Guid { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<GlobalRoleDataAccessModel> SystemRoles { get; set; } 
    public List<GlobalClaimsDataAccessModel> SystemClaims { get; set; }
    
}