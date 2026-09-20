using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.Transactions;
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
    public class TransactionController: BaseApiController
    {

        public readonly TransactionProvider _Provider;

        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;
        public TransactionController() 
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new TransactionProvider();
            _callValidator = new AuthenticationHelper();
        }
        // ============================================================
        // CREATE NEW TRANSACTION
        // ============================================================
        [HttpPost("CreateNewTransaction")]
        public async Task<IActionResult> CreateNewTransaction(
            [FromBody] NewTransactionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // AUTHENTICATE AND AUTHORIZE
            // ========================================================
            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            // ========================================================
            // CALL PROVIDER
            // ========================================================
            response =
                await _Provider.CreateNewTransaction(
                    request,
                    CallerUser);

            return Json(response);
        }
    }
}
