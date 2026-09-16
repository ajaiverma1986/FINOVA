using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;

namespace FINOVA.API.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ErrorResponse> IsValidToken(IFINOVAServiceUser FIAUser, bool IKnoeeAPIUser = true, bool slidingExpiration = true);
        Task<ErrorResponse> Validate(IFINOVAServiceUser FIAUser, bool validateBothToken = true, bool slidingExpiration = true);
    }
}
