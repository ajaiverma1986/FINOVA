using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.UserMgr;
using FINOVA.Provider;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ResponseCache(
        Duration = -1,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    [ServiceFilter(typeof(FINOVExceptionFilterService))]
    public class UserMgrController: BaseApiController
    {
        public readonly UserMgrProvider _Provider;
        private readonly AuthenticationHelper _callValidator;
        public UserMgrController() 
        {
            _Provider = new UserMgrProvider();
            _callValidator = new AuthenticationHelper();
        }
        // ============================================================
        // USER MASTER - CREATE
        // ============================================================
        [HttpPost("CreateUserMaster")]
        public async Task<IActionResult> CreateUserMaster(
            [FromBody] CreateUserMasterRequest request)
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
                await _Provider.CreateUserMaster(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateUserMaster")]
        public async Task<IActionResult> UpdateUserMaster(
            [FromBody] UpdateUserMasterRequest request)
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
                await _Provider.UpdateUserMaster(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteUserMaster/{userMasterID}")]
        public async Task<IActionResult> DeleteUserMaster(
            long userMasterID)
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
                await _Provider.DeleteUserMaster(
                    userMasterID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetUserMasterByID")]
        public async Task<IActionResult> GetUserMasterByID(
            long userMasterID)
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
                await _Provider.GetUserMasterByID(
                    userMasterID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllUserMasters")]
        public async Task<IActionResult> GetAllUserMasters()
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
                await _Provider.GetAllUserMasters(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveUserMasters")]
        public async Task<IActionResult> GetActiveUserMasters()
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
                await _Provider.GetActiveUserMasters(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET BY ORGANIZATION ID
        // ============================================================
        [HttpGet("GetUserMastersByOrganizationID")]
        public async Task<IActionResult> GetUserMastersByOrganizationID(
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
                await _Provider.GetUserMastersByOrganizationID(
                    organizationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET BY USER TYPE ID
        // ============================================================
        [HttpGet("GetUserMastersByUserTypeID")]
        public async Task<IActionResult> GetUserMastersByUserTypeID(
            int userTypeID)
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
                await _Provider.GetUserMastersByUserTypeID(
                    userTypeID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - GET BY USER NAME
        // ============================================================
        [HttpGet("GetUserMasterByUserName")]
        public async Task<IActionResult> GetUserMasterByUserName(
            string userName)
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
                await _Provider.GetUserMasterByUserName(
                    userName,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - CHANGE PASSWORD
        // ============================================================
        [HttpPost("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword(
            [FromBody] ChangeUserPasswordRequest request)
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
                await _Provider.ChangeUserPassword(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - LOCK USER
        // ============================================================
        [HttpPost("LockUserMaster")]
        public async Task<IActionResult> LockUserMaster(
            [FromBody] LockUserMasterRequest request)
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
                await _Provider.LockUserMaster(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER MASTER - UNLOCK USER
        // ============================================================
        [HttpPost("UnlockUserMaster/{userMasterID}")]
        public async Task<IActionResult> UnlockUserMaster(
            long userMasterID)
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
                await _Provider.UnlockUserMaster(
                    userMasterID,
                    CallerUser);

            return Json(response);
        }
    }
}
