using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Services.Login.System;

public interface ILoginRepository
{ SystemUser? GetGlobalUserCompactModel(string usernameOrEemail, string password);
}