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
        // ============================================================
        // CREATE USER ADDRESS
        // ============================================================
        [HttpPost("CreateUserAddress")]
        public async Task<IActionResult> CreateUserAddress(
            [FromBody] CreateUserAddressRequest request)
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
                await _Provider.CreateUserAddress(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE USER ADDRESS
        // ============================================================
        [HttpPost("UpdateUserAddress")]
        public async Task<IActionResult> UpdateUserAddress(
            [FromBody] UpdateUserAddressRequest request)
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
                await _Provider.UpdateUserAddress(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE USER ADDRESS
        // ============================================================
        [HttpDelete("DeleteUserAddress/{userAddressID}")]
        public async Task<IActionResult> DeleteUserAddress(
            long userAddressID)
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
                await _Provider.DeleteUserAddress(
                    userAddressID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER ADDRESS BY ID
        // ============================================================
        [HttpGet("GetUserAddressByID")]
        public async Task<IActionResult> GetUserAddressByID(
            long userAddressID)
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
                await _Provider.GetUserAddressByID(
                    userAddressID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL USER ADDRESSES
        // ============================================================
        [HttpGet("GetAllUserAddresses")]
        public async Task<IActionResult> GetAllUserAddresses()
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
                await _Provider.GetAllUserAddresses(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE USER ADDRESSES
        // ============================================================
        [HttpGet("GetActiveUserAddresses")]
        public async Task<IActionResult> GetActiveUserAddresses()
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
                await _Provider.GetActiveUserAddresses(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER ADDRESSES BY USER MASTER ID
        // ============================================================
        [HttpGet("GetUserAddressesByUserMasterID")]
        public async Task<IActionResult> GetUserAddressesByUserMasterID(
            long userMasterId)
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
                await _Provider.GetUserAddressesByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE USER ADDRESSES BY USER MASTER ID
        // ============================================================
        [HttpGet("GetActiveUserAddressesByUserMasterID")]
        public async Task<IActionResult> GetActiveUserAddressesByUserMasterID(
            long userMasterId)
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
                await _Provider.GetActiveUserAddressesByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE USER KYC
        // ============================================================
        [HttpPost("CreateUserKyc")]
        public async Task<IActionResult> CreateUserKyc(
            [FromBody] CreateUserKycRequest request)
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
                await _Provider.CreateUserKyc(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE USER KYC
        // ============================================================
        [HttpPost("UpdateUserKyc")]
        public async Task<IActionResult> UpdateUserKyc(
            [FromBody] UpdateUserKycRequest request)
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
                await _Provider.UpdateUserKyc(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE USER KYC
        // ============================================================
        [HttpDelete("DeleteUserKyc/{userKYCID}")]
        public async Task<IActionResult> DeleteUserKyc(
            long userKYCID)
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
                await _Provider.DeleteUserKyc(
                    userKYCID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER KYC BY ID
        // ============================================================
        [HttpGet("GetUserKycByID")]
        public async Task<IActionResult> GetUserKycByID(
            long userKYCID)
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
                await _Provider.GetUserKycByID(
                    userKYCID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL USER KYC
        // ============================================================
        [HttpGet("GetAllUserKyc")]
        public async Task<IActionResult> GetAllUserKyc()
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
                await _Provider.GetAllUserKyc(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE USER KYC
        // ============================================================
        [HttpGet("GetActiveUserKyc")]
        public async Task<IActionResult> GetActiveUserKyc()
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
                await _Provider.GetActiveUserKyc(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER KYC BY USER MASTER ID
        // ============================================================
        [HttpGet("GetUserKycByUserMasterID")]
        public async Task<IActionResult> GetUserKycByUserMasterID(
            long userMasterId)
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
                await _Provider.GetUserKycByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE USER KYC BY USER MASTER ID
        // ============================================================
        [HttpGet("GetActiveUserKycByUserMasterID")]
        public async Task<IActionResult> GetActiveUserKycByUserMasterID(
            long userMasterId)
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
                await _Provider.GetActiveUserKycByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE USER BANK ACCOUNT
        // ============================================================
        [HttpPost("CreateUserBankAccount")]
        public async Task<IActionResult> CreateUserBankAccount(
            [FromBody] CreateUserBankAccountRequest request)
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
                await _Provider.CreateUserBankAccount(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE USER BANK ACCOUNT
        // ============================================================
        [HttpPost("UpdateUserBankAccount")]
        public async Task<IActionResult> UpdateUserBankAccount(
            [FromBody] UpdateUserBankAccountRequest request)
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
                await _Provider.UpdateUserBankAccount(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE USER BANK ACCOUNT
        // ============================================================
        [HttpDelete("DeleteUserBankAccount/{originatorAccountID}")]
        public async Task<IActionResult> DeleteUserBankAccount(
            long originatorAccountID)
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
                await _Provider.DeleteUserBankAccount(
                    originatorAccountID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER BANK ACCOUNT BY ID
        // ============================================================
        [HttpGet("GetUserBankAccountByID")]
        public async Task<IActionResult> GetUserBankAccountByID(
            long originatorAccountID)
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
                await _Provider.GetUserBankAccountByID(
                    originatorAccountID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL USER BANK ACCOUNTS
        // ============================================================
        [HttpGet("GetAllUserBankAccounts")]
        public async Task<IActionResult> GetAllUserBankAccounts()
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
                await _Provider.GetAllUserBankAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE USER BANK ACCOUNTS
        // ============================================================
        [HttpGet("GetActiveUserBankAccounts")]
        public async Task<IActionResult> GetActiveUserBankAccounts()
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
                await _Provider.GetActiveUserBankAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        [HttpGet("GetUserBankAccountsByUserMasterID")]
        public async Task<IActionResult> GetUserBankAccountsByUserMasterID(
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
                await _Provider.GetUserBankAccountsByUserMasterID(
                    userMasterID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        [HttpGet("GetActiveUserBankAccountsByUserMasterID")]
        public async Task<IActionResult> GetActiveUserBankAccountsByUserMasterID(
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
                await _Provider.GetActiveUserBankAccountsByUserMasterID(
                    userMasterID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE USER CONFIGURATION
        // ============================================================
        [HttpPost("CreateUserConfiguration")]
        public async Task<IActionResult> CreateUserConfiguration(
            [FromBody] CreateUserConfigurationRequest request)
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
                await _Provider.CreateUserConfiguration(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE USER CONFIGURATION
        // ============================================================
        [HttpPost("UpdateUserConfiguration")]
        public async Task<IActionResult> UpdateUserConfiguration(
            [FromBody] UpdateUserConfigurationRequest request)
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
                await _Provider.UpdateUserConfiguration(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE USER CONFIGURATION
        // ============================================================
        [HttpDelete("DeleteUserConfiguration/{configurationId}")]
        public async Task<IActionResult> DeleteUserConfiguration(
            long configurationId)
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
                await _Provider.DeleteUserConfiguration(
                    configurationId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER CONFIGURATION BY ID
        // ============================================================
        [HttpGet("GetUserConfigurationByID")]
        public async Task<IActionResult> GetUserConfigurationByID(
            long configurationId)
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
                await _Provider.GetUserConfigurationByID(
                    configurationId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL USER CONFIGURATIONS
        // ============================================================
        [HttpGet("GetAllUserConfigurations")]
        public async Task<IActionResult> GetAllUserConfigurations()
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
                await _Provider.GetAllUserConfigurations(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET USER CONFIGURATION BY USER MASTER ID
        // ============================================================
        [HttpGet("GetUserConfigurationByUserMasterID")]
        public async Task<IActionResult> GetUserConfigurationByUserMasterID(
            long userMasterId)
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
                await _Provider.GetUserConfigurationByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE OTHER DETAILS
        // ============================================================
        [HttpPost("CreateOtherDetails")]
        public async Task<IActionResult> CreateOtherDetails(
            [FromBody] CreateOtherDetailsRequest request)
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
                await _Provider.CreateOtherDetails(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE OTHER DETAILS
        // ============================================================
        [HttpPost("UpdateOtherDetails")]
        public async Task<IActionResult> UpdateOtherDetails(
            [FromBody] UpdateOtherDetailsRequest request)
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
                await _Provider.UpdateOtherDetails(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE OTHER DETAILS
        // ============================================================
        [HttpDelete("DeleteOtherDetails/{otherDetailId}")]
        public async Task<IActionResult> DeleteOtherDetails(
            long otherDetailId)
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
                await _Provider.DeleteOtherDetails(
                    otherDetailId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET OTHER DETAILS BY ID
        // ============================================================
        [HttpGet("GetOtherDetailsByID")]
        public async Task<IActionResult> GetOtherDetailsByID(
            long otherDetailId)
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
                await _Provider.GetOtherDetailsByID(
                    otherDetailId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL OTHER DETAILS
        // ============================================================
        [HttpGet("GetAllOtherDetails")]
        public async Task<IActionResult> GetAllOtherDetails()
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
                await _Provider.GetAllOtherDetails(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS
        // ============================================================
        [HttpGet("GetActiveOtherDetails")]
        public async Task<IActionResult> GetActiveOtherDetails()
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
                await _Provider.GetActiveOtherDetails(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET OTHER DETAILS BY USER MASTER ID
        // ============================================================
        [HttpGet("GetOtherDetailsByUserMasterID")]
        public async Task<IActionResult> GetOtherDetailsByUserMasterID(
            long userMasterId)
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
                await _Provider.GetOtherDetailsByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS BY USER MASTER ID
        // ============================================================
        [HttpGet("GetActiveOtherDetailsByUserMasterID")]
        public async Task<IActionResult> GetActiveOtherDetailsByUserMasterID(
            long userMasterId)
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
                await _Provider.GetActiveOtherDetailsByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }
    }
}
