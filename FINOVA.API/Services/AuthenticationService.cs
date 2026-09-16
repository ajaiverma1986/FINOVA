using FINOVA.API.Interfaces;
using FINOVA.Commonlib.Cache;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;

namespace FINOVA.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private AuthenticationProvider _authenticationProvider;

        public AuthenticationService()
        {
            _authenticationProvider = new AuthenticationProvider();
        }

        public async Task<ErrorResponse> Validate(IFINOVAServiceUser APIUser, bool validateBothToken = true, bool slidingExpiration = true)
        {
            ErrorResponse error = await IsValidToken(APIUser, validateBothToken, slidingExpiration);
            if (error.HasError)
            {
                return error;
            }
            return error;
        }

        public async Task<ErrorResponse> IsValidToken(IFINOVAServiceUser APIUser, bool validateBothToken = true, bool slidingExpiration = true)
        {
            ErrorResponse error = new ErrorResponse();

            //If ValidateBothToken is false and still user token is received then it will be validated
            if (!validateBothToken && !string.IsNullOrEmpty(APIUser.UserToken))
            {
                validateBothToken = true;
            }
            if (string.IsNullOrEmpty(APIUser.ApiToken) || (validateBothToken && string.IsNullOrEmpty(APIUser.UserToken)))
            {
                error.SetError(ErrorCodes.AUTHENTICATION_FAILURE);
                this.ClearUserCache(APIUser.ApiToken, APIUser.UserToken);
                return error;
            }
            var isValid = await _authenticationProvider.IsValidToken(APIUser.ApiToken, APIUser.UserToken, validateBothToken, slidingExpiration);

            if (isValid)
            {
                error.NoError();
            }
            else
            {
                error.SetError(ErrorCodes.AUTHENTICATION_FAILURE);
                this.ClearUserCache(APIUser.ApiToken, APIUser.UserToken);
            }

            return error;
        }

        private void ClearUserCache(string apiToken, string userToken)
        {
            if (!string.IsNullOrEmpty(apiToken))
                MemoryCachingService.Clear(apiToken);

            if (!string.IsNullOrEmpty(userToken))
                MemoryCachingService.Clear(userToken);
        }

    }
}
