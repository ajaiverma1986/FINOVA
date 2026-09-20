using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Report;
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
    public class ReportController: BaseApiController
    {
        public readonly ReportProvider _Provider;
        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;
        public ReportController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new ReportProvider();
            _callValidator = new AuthenticationHelper();
        }
        // ============================================================
        // TRANSACTION DETAILS REPORT
        // ============================================================
        [HttpPost("TransactionDetailsReport")]
        public async Task<IActionResult> TransactionDetailsReport(
            [FromBody] TransactionReportRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetTransactionDetailsReport(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADMIN DASHBOARD
        // ============================================================
        [HttpPost("AdminDashboard")]
        public async Task<IActionResult> AdminDashboard(
            [FromBody] AdminDashboardRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAdminDashboard(
                    request,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // USER DETAILS REPORT
        // ============================================================
        [HttpPost("GetUserDetailsReport")]
        public async Task<IActionResult> GetUserDetailsReport(
            [FromBody] UserDetailsReportRequest request)
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
                await _Provider.GetUserDetailsReport(
                    request,
                    CallerUser);

            return Json(response);
        }
    }
}
