using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Services.Login.System.Models;

namespace IdentityService.DataAccess.Services.Login.System;

public static class MapLoginServiceClaims 
{
    // Map Claims
    public static GlobalClaimsDataAccessModel MapFromRequest(this GlobalClaim requestModel)
    {
        return new GlobalClaimsDataAccessModel
        {
            Guid = requestModel.Guid,
            ClaimCode = requestModel.Code,
            Name = requestModel.Name
        };
    }

    public static GlobalClaim MapFromResponse(this GlobalClaimsDataAccessModel requestModel)
    {
        return new GlobalClaim
        {
            Guid = requestModel.Guid,
            Code = requestModel.ClaimCode,
            Name = requestModel.Name
        };
        
    }

    public static List<GlobalClaimsDataAccessModel> MapFromRequest(this List<GlobalClaim> requestModel)
    {

        // Cast to List<GlobalClaimsDataAccessModel>
        var globalClaimsDataAccessModel = new List<GlobalClaimsDataAccessModel>();
        
        foreach (var eachClaim in requestModel)
        {
            globalClaimsDataAccessModel.Add(eachClaim.MapFromRequest());
        }
        return globalClaimsDataAccessModel;
        
    }

    public static List<GlobalClaim> MapFromResponse(this List<GlobalClaimsDataAccessModel> requestModel)
    {
        // Cast to List<GlobalClaim>
        var globalClaimsDataAccessModel = new List<GlobalClaim>();
        
        foreach (var eachClaim in requestModel)
        {
            globalClaimsDataAccessModel.Add(eachClaim.MapFromResponse());
        }
        return globalClaimsDataAccessModel;
    }
    
    // Map Roles
    public static GlobalRoleDataAccessModel MapFromRequest(this GlobalRole requestModel)
    {
        return new GlobalRoleDataAccessModel
        {
            Guid = requestModel.Guid,
            Name = requestModel.Name,
            SystemClaims = requestModel.SystemClaims.ToList().MapFromRequest()
            
        };
    }
    
    public static GlobalRole MapFromResponse(this GlobalRoleDataAccessModel requestModel)
    {
        return new GlobalRole
        {
            Guid = requestModel.Guid,
            Name = requestModel.Name,
            SystemClaims = requestModel.SystemClaims.ToList().MapFromResponse()
        };
    }
    
    public static List<GlobalRoleDataAccessModel> MapFromRequest(this List<GlobalRole> requestModel)
    {
        // Cast to List<GlobalRoleDataAccessModel>
        var globalRoleDataAccessModel = new List<GlobalRoleDataAccessModel>();
        
        foreach (var eachRole in requestModel)
        {
            globalRoleDataAccessModel.Add(eachRole.MapFromRequest());
        }
        return globalRoleDataAccessModel;
    }
    
    public static List<GlobalRole> MapFromResponse(this List<GlobalRoleDataAccessModel> requestModel)
    {
        // Cast to List<GlobalRole>
        var globalRoleDataAccessModel = new List<GlobalRole>();
        
        foreach (var eachRole in requestModel)
        {
            globalRoleDataAccessModel.Add(eachRole.MapFromResponse());
        }
        return globalRoleDataAccessModel;
    }
    
    // Map Users
    
    public static GlobalUserCompactModel MapFromRequest(this GlobalUser requestModel)
    {
        return new GlobalUserCompactModel
        {
            Guid = requestModel.Guid,
            Email = requestModel.Email,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            SystemRoles = requestModel.Roles.ToList().MapFromRequest(),
            SystemClaims = requestModel.DirectlyAssignClaims.ToList().MapFromRequest()
        };
    }
    
    public static GlobalUser MapFromResponse(this GlobalUserCompactModel requestModel)
    {
        return new GlobalUser
        {
            Guid = requestModel.Guid,
            Email = requestModel.Email,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            Roles = requestModel.SystemRoles.ToList().MapFromResponse(),
            DirectlyAssignClaims = requestModel.SystemClaims.ToList().MapFromResponse()
        };
    }
    
    public static List<GlobalUserCompactModel> MapFromRequest(this List<GlobalUser> requestModel)
    {
        // Cast to List<GlobalUserCompactModel>
        var globalUserCompactModel = new List<GlobalUserCompactModel>();
        
        foreach (var eachUser in requestModel)
        {
            globalUserCompactModel.Add(eachUser.MapFromRequest());
        }
        return globalUserCompactModel;
    }
    
    public static List<GlobalUser> MapFromResponse(this List<GlobalUserCompactModel> requestModel)
    {
        // Cast to List<GlobalUser>
        var globalUserCompactModel = new List<GlobalUser>();
        
        foreach (var eachUser in requestModel)
        {
            globalUserCompactModel.Add(eachUser.MapFromResponse());
        }
        return globalUserCompactModel;
    }
}