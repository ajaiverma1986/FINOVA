using Audit.WebApi;
using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.DTO.Request;
using FINOVA.DataModel.DTO.Response;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    [ResponseCache(
        Duration = -1,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    [ServiceFilter(typeof(FINOVExceptionFilterService))]
    public class AAController : BaseApiController
    {
        private readonly AuthenticationProvider _authenticationProvider;
        private readonly AuthenticationHelper _callValidator;

        public AAController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _callValidator = new AuthenticationHelper();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="userLoginRequest">User login request</param>
        /// <returns>User login response</returns>
        [HttpPost("Login")]
        [AuditApi(
            EventTypeName = "POST AAController/Login",
            IncludeHeaders = true,
            IncludeResponseBody = true,
            IncludeRequestBody = false,
            IncludeModelState = false)]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginRequest userLoginRequest)
        {
            UserLoginResponse response = new UserLoginResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    this.CallerUser,
                    false);

            if (error.HasError)
            {
                response.SetError(error);
                return Ok(response);
            }

            response = await _authenticationProvider.Login(
                userLoginRequest,
                this.CallerUser);

            return Ok(response);
        }
    }
}