using FINOVA.Commonlib.Cache;
using FINOVA.DataModel.Common;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FINOVA.API.Common
{
    //[EnableCors("AllowAll")]
    [ResponseCache(Duration = -1, Location = ResponseCacheLocation.None, NoStore = true)]
    public class BaseApiController : Controller
    {
        protected T GetValueFromClaims<T>(string claimsType)
        {
            var claim = ((ClaimsIdentity)User.Identity).FindFirst(claimsType);
            if (claim != null)
            {
                object claimValue = claim.Value;
                return (T)Convert.ChangeType(claimValue, typeof(T));
            }
            return default(T);
        }

        public IFINOVAServiceUser CallerUser
        {
            get
            {
                return HttpContext.RequestServices.GetService(typeof(IFINOVAServiceUser)) as IFINOVAServiceUser;
            }
        }

        protected async void ClearUserCache(string apiToken, string userToken)
        {
            if (!string.IsNullOrEmpty(apiToken))
                await MemoryCachingService.Clear(string.Format(CacheKeys.APPLICATION_USER_DETAIL, apiToken));

            if (!string.IsNullOrEmpty(userToken))
            {
                await MemoryCachingService.Clear(string.Format(CacheKeys.USERMASTER_ID, userToken));
            }
        }
        protected ErrorResponse IsModelValidNew()
        {
            ErrorResponse errorResponse = new ErrorResponse();
            if (!ModelState.IsValid)
            {
                foreach (var vals in ModelState.Values)
                {
                    foreach (var err in vals.Errors)
                    {
                        errorResponse.SetError(new ErrorResponse(ErrorCodes.VALIDATION_ERROR, err.ErrorMessage));
                    }
                }
            }
            return errorResponse;
        }
    }
}
