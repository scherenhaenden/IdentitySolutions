using IdentityService.DataAccess.Database.Persistence.Domain.Global;
using IdentityService.DataAccess.Services.Login.System.Models;

namespace IdentityService.DataAccess.Services.Login.System;

public static class MapLoginServiceClaims 
{
    // Map Claims
    public static GlobalClaimsDataAccessModel MapFromRequest(this SystemClaim requestModel)
    {
        return new GlobalClaimsDataAccessModel
        {
            Guid = requestModel.Guid,
            ClaimCode = requestModel.Code,
            Name = requestModel.Name
        };
    }

    public static SystemClaim MapFromResponse(this GlobalClaimsDataAccessModel requestModel)
    {
        return new SystemClaim
        {
            Guid = requestModel.Guid,
            Code = requestModel.ClaimCode,
            Name = requestModel.Name
        };
        
    }

    public static List<GlobalClaimsDataAccessModel> MapFromRequest(this List<SystemClaim> requestModel)
    {

        // Cast to List<GlobalClaimsDataAccessModel>
        var globalClaimsDataAccessModel = new List<GlobalClaimsDataAccessModel>();
        
        foreach (var eachClaim in requestModel)
        {
            globalClaimsDataAccessModel.Add(eachClaim.MapFromRequest());
        }
        return globalClaimsDataAccessModel;
        
    }

    public static List<SystemClaim> MapFromResponse(this List<GlobalClaimsDataAccessModel> requestModel)
    {
        // Cast to List<SystemClaim>
        var globalClaimsDataAccessModel = new List<SystemClaim>();
        
        foreach (var eachClaim in requestModel)
        {
            globalClaimsDataAccessModel.Add(eachClaim.MapFromResponse());
        }
        return globalClaimsDataAccessModel;
    }
    
    // Map Roles
    public static GlobalRoleDataAccessModel MapFromRequest(this SystemRole requestModel)
    {
        return new GlobalRoleDataAccessModel
        {
            Guid = requestModel.Guid,
            Name = requestModel.Name,
            SystemClaims = requestModel.SystemClaims.ToList().MapFromRequest()
            
        };
    }
    
    public static SystemRole MapFromResponse(this GlobalRoleDataAccessModel requestModel)
    {
        return new SystemRole
        {
            Guid = requestModel.Guid,
            Name = requestModel.Name,
            SystemClaims = requestModel.SystemClaims.ToList().MapFromResponse()
        };
    }
    
    public static List<GlobalRoleDataAccessModel> MapFromRequest(this List<SystemRole> requestModel)
    {
        // Cast to List<GlobalRoleDataAccessModel>
        var globalRoleDataAccessModel = new List<GlobalRoleDataAccessModel>();
        
        foreach (var eachRole in requestModel)
        {
            globalRoleDataAccessModel.Add(eachRole.MapFromRequest());
        }
        return globalRoleDataAccessModel;
    }
    
    public static List<SystemRole> MapFromResponse(this List<GlobalRoleDataAccessModel> requestModel)
    {
        // Cast to List<SystemRole>
        var globalRoleDataAccessModel = new List<SystemRole>();
        
        foreach (var eachRole in requestModel)
        {
            globalRoleDataAccessModel.Add(eachRole.MapFromResponse());
        }
        return globalRoleDataAccessModel;
    }
    
    // Map Users
    
    public static GlobalUserCompactModel MapFromRequest(this SystemUser requestModel)
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
    
    public static SystemUser MapFromResponse(this GlobalUserCompactModel requestModel)
    {
        return new SystemUser
        {
            Guid = requestModel.Guid,
            Email = requestModel.Email,
            FirstName = requestModel.FirstName,
            LastName = requestModel.LastName,
            Roles = requestModel.SystemRoles.ToList().MapFromResponse(),
            DirectlyAssignClaims = requestModel.SystemClaims.ToList().MapFromResponse()
        };
    }
    
    public static List<GlobalUserCompactModel> MapFromRequest(this List<SystemUser> requestModel)
    {
        // Cast to List<GlobalUserCompactModel>
        var globalUserCompactModel = new List<GlobalUserCompactModel>();
        
        foreach (var eachUser in requestModel)
        {
            globalUserCompactModel.Add(eachUser.MapFromRequest());
        }
        return globalUserCompactModel;
    }
    
    public static List<SystemUser> MapFromResponse(this List<GlobalUserCompactModel> requestModel)
    {
        // Cast to List<SystemUser>
        var globalUserCompactModel = new List<SystemUser>();
        
        foreach (var eachUser in requestModel)
        {
            globalUserCompactModel.Add(eachUser.MapFromResponse());
        }
        return globalUserCompactModel;
    }
}