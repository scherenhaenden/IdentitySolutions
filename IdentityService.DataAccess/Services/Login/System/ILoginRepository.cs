using IdentityService.DataAccess.Database.Persistence.Domain.Global;

namespace IdentityService.DataAccess.Services.Login.System;

public interface ILoginRepository
{ SystemlUser? GetGlobalUserCompactModel(string usernameOrEemail, string password);
}