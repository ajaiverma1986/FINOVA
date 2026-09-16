using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.OrgMgr;
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
    public class OrgMgrController: BaseApiController
    {
        public readonly OrgMgrProvider _Provider;

        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;
        public OrgMgrController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new OrgMgrProvider();
            _callValidator = new AuthenticationHelper();
        }
        // ============================================================
        // ORGANIZATION - CREATE
        // ============================================================
        [HttpPost("CreateOrganization")]
        public async Task<IActionResult> CreateOrganization(
            [FromBody] CreateOrganizationRequest request)
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
                await _Provider.CreateOrganization(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - UPDATE
        // ============================================================
        [HttpPost("UpdateOrganization")]
        public async Task<IActionResult> UpdateOrganization(
            [FromBody] UpdateOrganizationRequest request)
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
                await _Provider.UpdateOrganization(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - DELETE
        // ============================================================
        [HttpDelete("DeleteOrganization/{organizationID}")]
        public async Task<IActionResult> DeleteOrganization(
            long organizationID)
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
                await _Provider.DeleteOrganization(
                    organizationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET BY ID
        // ============================================================
        [HttpGet("GetOrganizationByID")]
        public async Task<IActionResult> GetOrganizationByID(
            long organizationID)
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
                await _Provider.GetOrganizationByID(
                    organizationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET BY UID
        // ============================================================
        [HttpGet("GetOrganizationByUID")]
        public async Task<IActionResult> GetOrganizationByUID(
            Guid organizationUID)
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
                await _Provider.GetOrganizationByUID(
                    organizationUID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET BY CODE
        // ============================================================
        [HttpGet("GetOrganizationByCode")]
        public async Task<IActionResult> GetOrganizationByCode(
            string organizationCode)
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
                await _Provider.GetOrganizationByCode(
                    organizationCode,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET ALL
        // ============================================================
        [HttpGet("GetAllOrganizations")]
        public async Task<IActionResult> GetAllOrganizations()
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
                await _Provider.GetAllOrganizations(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveOrganizations")]
        public async Task<IActionResult> GetActiveOrganizations()
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
                await _Provider.GetActiveOrganizations(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ORGANIZATION - GET BY ORGANIZATION TYPE ID
        // ============================================================
        [HttpGet("GetOrganizationsByOrganizationTypeID")]
        public async Task<IActionResult> GetOrganizationsByOrganizationTypeID(
            int organizationTypeID)
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
                await _Provider.GetOrganizationsByOrganizationTypeID(
                    organizationTypeID,
                    CallerUser);

            return Json(response);
        }
    }
}
