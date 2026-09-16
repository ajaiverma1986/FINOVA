using FINOVA.Commonlib.Cache;
using FINOVA.DataModel.Common;
using FINOVA.DataModel.Entities.Authorization;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;

namespace FINOVA.API.Security
{
    public class AuthorizationHelper
    {
        public AuthorizationHelper()
        {
        }

        public async Task<ErrorResponse> Authorize(IFINOVAServiceUser serviceUser, Permissions permission)
        {
            ErrorResponse error = new ErrorResponse();

            if (permission == Permissions.NONE)
            {
                error.SetError(ErrorCodes.NO_ERROR);
            }
            else
            {
                List<UserApplicationAccessPermissions> userPermissions = await MemoryCachingService.Get<List<UserApplicationAccessPermissions>>(string.Format(CacheKeys.USER_ROLES_API, serviceUser.ApplicationID, serviceUser.UserToken));
                if (userPermissions == null || userPermissions.Count == 0)
                {
                    error.SetError(ErrorCodes.AUTHORIZATION_FAILURE);
                }
                else
                {
                    UserApplicationAccessPermissions userApplicationAccess = (from access in userPermissions where access.PermissionID == permission select access).FirstOrDefault();
                    if (userApplicationAccess == null)
                    {
                        error.SetError(ErrorCodes.AUTHORIZATION_FAILURE);
                    }
                }
            }
            return error;
        }
    }
}
