using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Entities.Users;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;
using FINOVA.Provider.Shared;
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
    public class UserController : BaseApiController
    {
        public readonly UserDetailsProvider _Provider;
        private readonly AuthenticationHelper _callValidator;

        public UserController()
        {
            _Provider = new UserDetailsProvider();
            _callValidator = new AuthenticationHelper();
        }

       

        /// <summary>
        /// Upload Logo
        /// </summary>
        [HttpPost("UploadUserLogo")]
        public async Task<IActionResult> UploadUserLogo()
        {
            if (Request.Form.Files.Count == 0)
            {
                SimpleResponse response = new SimpleResponse();
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            IFormFile newfile = Request.Form.Files[0];

            SimpleResponse result = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                result.SetError(error);
                return Json(result);
            }

            FileManager obj = new FileManager();
            UploadOrgLogo logore = new UploadOrgLogo();

            byte[] fileBytes = GetStreamBytes(newfile.OpenReadStream());

            string filename = obj.SaveFile(
                fileBytes,
                CallerUser.UserID.ToString(),
                newfile.FileName);

            logore.FileName = filename;
            logore.UserId = CallerUser.UserID;
            logore.FileBytes = fileBytes;

            result.Result =
                await _Provider.UpdateUserOrgLogo(
                    logore,
                    filename,
                    CallerUser);

            return Json(result);
        }

        [NonAction]
        public byte[] GetStreamBytes(Stream inputStream)
        {
            using (inputStream)
            {
                if (inputStream is MemoryStream memoryStream)
                {
                    return memoryStream.ToArray();
                }

                using MemoryStream newMemoryStream = new MemoryStream();
                inputStream.CopyTo(newMemoryStream);

                return newMemoryStream.ToArray();
            }
        }

        [HttpPost("AddOriginatorAccounts")]
        public async Task<IActionResult> AddOriginatorAccounts(
            [FromBody] CreateOriginatorAccountRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.AddOriginatorAccounts(request, CallerUser);

            return Json(response);
        }

        [HttpPost("ApproveRejectOrigiAccounts")]
        public async Task<IActionResult> ApproveRejectOrigiAccounts(
            [FromBody] ApproveRejectOriAccountRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.ApproveRejectOriAccounts(request, CallerUser);

            return Json(response);
        }

        [HttpGet("ListOriginatorAccounts")]
        public async Task<IActionResult> ListOriginatorAccounts()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetallOriginatorsAccount(CallerUser);

            return Json(response);
        }

        [HttpGet("ListOriginatorAccountsByID")]
        public async Task<IActionResult> ListOriginatorAccountsByID(
            [FromQuery] long AccountID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.GetallOriginatorsAccountByID(
                    AccountID,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ListallOriginatorsAccounts")]
        public async Task<IActionResult> ListallOriginatorsAccounts(
            [FromBody] OriginatorListAccountRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.ListAllOriginatorsAccounts(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ListAllOriginatorsAccountsforAdmin")]
        public async Task<IActionResult> ListAllOriginatorsAccountsforAdmin(
            [FromBody] OriginatorListAccountforadminRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.ListAllOriginatorsAccountsforAdmin(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("AddUserAddress")]
        public async Task<IActionResult> AddUserAddress(
            [FromBody] CreateUserDetailAddressRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.AddUserAddress(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("ListUserAddresses")]
        public async Task<IActionResult> ListUserAddresses()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserAddress(CallerUser);

            return Json(response);
        }

        [HttpPost("AddUserDeatilKYC")]
        public async Task<IActionResult> AddUserDeatilKYC(
            [FromBody] CreateUserDetailKyc1 request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            FileManager obj = new FileManager();

            string filename =
                obj.SaveFile(
                    request.FileBytes,
                    request.DocumentNo,
                    request.FileName);

            response.Result =
                await _Provider.AddUserDeatilKYC(
                    request,
                    filename,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("ListUserKYC")]
        public async Task<IActionResult> ListUserKYC()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserKyc(CallerUser);

            return Json(response);
        }

        [HttpGet("ListUserKYCByUserId")]
        public async Task<IActionResult> ListUserKYCByUserId(
            [FromQuery] long UserId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserKycByUserId(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("CheckBalance")]
        public async Task<IActionResult> CheckBalance()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CheckBalalnce(CallerUser);

            return Json(response);
        }

        [HttpPost("CreateOrgAPIPartner")]
        public async Task<IActionResult> CreateOrgAPIPartner(
            [FromBody] CreateNewPartnerRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            if (request == null)
            {
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                response.SetError(ErrorCodes.SP_135);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.EmailId))
            {
                response.SetError(ErrorCodes.SP_135);
                return Json(response);
            }

            response.Result =
                await _Provider.CreateOrgAPIPartner(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("CreateNewAPIUser")]
        public async Task<IActionResult> CreateNewAPIUser(
            [FromBody] CreateNewUserRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            if (request == null)
            {
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                response.SetError(ErrorCodes.SP_135);
                return Json(response);
            }

            response.Result =
                await _Provider.CreateNewUser(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetAllapplication")]
        public async Task<IActionResult> GetAllapplication()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.Getallapplication(CallerUser);

            return Json(response);
        }

        [HttpGet("GetallUserByOrg")]
        public async Task<IActionResult> GetallUserByOrg()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.GetallUserByOrg(CallerUser);

            return Json(response);
        }

        [HttpPost("UploadUserKYC")]
        public async Task<IActionResult> UploadUserKYC(
            [FromQuery] int kycTypeId,
            [FromQuery] string DocumentNo)
        {
            if (Request.Form.Files.Count == 0)
            {
                SimpleResponse response = new SimpleResponse();
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            IFormFile newfile = Request.Form.Files[0];

            SimpleResponse result = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                result.SetError(error);
                return Json(result);
            }

            FileManager obj = new FileManager();

            UploadUserKYCFileRequest request1 =
                new UploadUserKYCFileRequest();

            request1.DocumentNo = DocumentNo;
            request1.KycID = kycTypeId;

            string Fullfilename;

            if (!string.IsNullOrEmpty(DocumentNo))
            {
                Fullfilename =
                    CallerUser.UserID +
                    "_" +
                    kycTypeId +
                    "_" +
                    DocumentNo;
            }
            else
            {
                Fullfilename =
                    CallerUser.UserID +
                    "_" +
                    kycTypeId;
            }

            string filename =
                obj.SaveKYCDocument(
                    GetStreamBytes(newfile.OpenReadStream()),
                    CallerUser.UserID.ToString(),
                    newfile.FileName,
                    Fullfilename);

            result.Result =
                await _Provider.UploadUserKYC(
                    request1,
                    filename,
                    CallerUser);

            return Json(result);
        }

        [HttpGet("ListUserKYCById")]
        public async Task<IActionResult> ListUserKYCById(
            [FromQuery] long KycId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserKycById(
                    KycId,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("DocumentView_Search")]
        public async Task<IActionResult> DocumentView_Search(
            [FromQuery] long KYCID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            if (KYCID == 0)
            {
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            response =
                await _Provider.DocumentView_Search(
                    KYCID,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("UpdateOriginatorChequeFile")]
        public async Task<IActionResult> UpdateOriginatorChequeFile(
            [FromQuery] long AccountID)
        {
            if (Request.Form.Files.Count == 0)
            {
                SimpleResponse response = new SimpleResponse();
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            IFormFile newfile = Request.Form.Files[0];

            SimpleResponse result = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                result.SetError(error);
                return Json(result);
            }

            FileManager obj = new FileManager();

            PayinAccountRegistrationChequeRequest request1 =
                new PayinAccountRegistrationChequeRequest();

            request1.AccountId = AccountID;

            string Fullfilename =
                AccountID +
                "_" +
                CallerUser.UserID;

            string filename =
                obj.SaveOtherDocument(
                    GetStreamBytes(newfile.OpenReadStream()),
                    "AccountCheque",
                    newfile.FileName,
                    Fullfilename,
                    AccountID.ToString());

            request1.Filename = filename;

            result =
                await _Provider.UpdateOriginatorChequeFile(
                    request1,
                    CallerUser);

            return Json(result);
        }

        [HttpGet("GetOriginatorChequePhoto")]
        public async Task<IActionResult> GetOriginatorChequePhoto(
            [FromQuery] long AccountID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            if (AccountID == 0)
            {
                response.SetError(ErrorCodes.INVALID_PARAMETERS);
                return Json(response);
            }

            response.Result =
                await _Provider.DocumentViewOriginatorAcc_Search(
                    AccountID,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetUserLogo")]
        public async Task<IActionResult> GetUserLogo(
            [FromQuery] long UserId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetUserLogo(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("ListAllMenu")]
        public async Task<IActionResult> ListAllMenu()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.GetallMenu(CallerUser);

            return Json(response);
        }

        [HttpGet("ListAllsubMenu")]
        public async Task<IActionResult> ListAllsubMenu(
            [FromQuery] int Menuid)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response.Result =
                await _Provider.GetallSubMenu(
                    Menuid,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetAllUserDetails")]
        public async Task<IActionResult> GetAllUserDetails()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserDetails(CallerUser);

            return Json(response);
        }

        [HttpPost("ApproveRejectUserDocument")]
        public async Task<IActionResult> ApproveRejectUserDocument(
            [FromBody] ApproveRejectUserDocumentRequest request)
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

            response.Result =
                await _Provider.ApproveRejectUserDocument(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetAllUserConfigration")]
        public async Task<IActionResult> GetAllUserConfigration(
            [FromQuery] long UserId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllUserConfigration(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("UpDateUserConfigrationDetails")]
        public async Task<IActionResult> UpDateUserConfigrationDetails(
            [FromBody] UserConfigrationRequest request)
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

            response.Result =
                await _Provider.UpDateUserConfigrationDetails(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ActivateDeactivateApiUser")]
        public async Task<IActionResult> ActivateDeactivateApiUser(
            [FromBody] ActivateAPIUserRequest request)
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

            response.Result =
                await _Provider.ActivateDeactivateApiUser(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ActivateDeactivateUserMaster")]
        public async Task<IActionResult> ActivateDeactivateUserMaster(
            [FromBody] ActivateAPIUserMasterRequest request)
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

            response.Result =
                await _Provider.ActivateDeactivateUserMaster(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("GetAllUserMasterList")]
        public async Task<IActionResult> GetAllUserMasterList(
            [FromBody] ListUserMasterRequest request)
        {
            ListResponse response = new ListResponse();

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
                await _Provider.GetAllUserMasterList(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetUserMasterDetailsforConfig")]
        public async Task<IActionResult> GetUserMasterDetailsforConfig(
            [FromQuery] string UserName)
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
                await _Provider.GetUserMasterDetailsforConfig(
                    UserName,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ListUserAddress")]
        public async Task<IActionResult> ListUserAddress(
            [FromBody] ListUserAddressRequest request)
        {
            ListResponse response = new ListResponse();

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
                await _Provider.ListUserAddress(
                    request,
                    CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Change Password
        /// </summary>
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(
            [FromBody] ChangePasswordRequest request)
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

            response.Result =
                await _Provider.ChangePassword(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("AddIPAddress")]
        public async Task<IActionResult> AddIPAddress(
            [FromBody] AddIPAddressRequest request)
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

            response.Result =
                await _Provider.AddIPAddress(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetallIPAdress")]
        public async Task<IActionResult> GetallIPAdress(
            [FromQuery] long UserId)
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
                await _Provider.GetallIPAdress(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("ApproveRejectIP")]
        public async Task<IActionResult> ApproveRejectIP(
            [FromBody] ApproveRejectIPAddressRequest request)
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
                await _Provider.ApproveRejectIP(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("GetAllIPAddressforAdmin")]
        public async Task<IActionResult> GetAllIPAddressforAdmin(
            [FromBody] IPAddressListDetail request)
        {
            ListResponse response = new ListResponse();

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
                await _Provider.GetAllIPAddressforAdmin(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetAllapplicationForAdmin")]
        public async Task<IActionResult> GetAllapplicationForAdmin(
            [FromQuery] long UserId)
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

            response.Result =
                await _Provider.GetallapplicationforAdmin(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("AddUserOtherDetails")]
        public async Task<IActionResult> AddUserOtherDetails(
            [FromBody] AddUserOtherDetailRequest request)
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
                await _Provider.AddUserOtherDetails(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpGet("GetUserOtherDetails")]
        public async Task<IActionResult> GetUserOtherDetails(
            [FromQuery] long UserId)
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
                await _Provider.GetUserOtherDetails(
                    UserId,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("AddNewOutLet")]
        public async Task<IActionResult> AddNewOutLet(
            [FromBody] CreateNewOutLetRequest request)
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

            if (request == null)
            {
                response.SetError(ErrorCodes.BAD_REQUEST);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.FirstName))
            {
                response.SetError(ErrorCodes.SP_154);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.EmailId))
            {
                response.SetError(ErrorCodes.SP_155);
                return Json(response);
            }

            if (string.IsNullOrEmpty(request.MobileNo))
            {
                response.SetError(ErrorCodes.SP_156);
                return Json(response);
            }

            response =
                await _Provider.AddNewOutLet(
                    request,
                    CallerUser);

            return Json(response);
        }

        [HttpPost("GetAllOutLetList")]
        public async Task<IActionResult> GetAllOutLetList(
            [FromBody] ListRetailorRequest request)
        {
            ListResponse response = new ListResponse();

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
                await _Provider.GetAllOutLetList(
                    request,
                    CallerUser);

            return Json(response);
        }
    }
}

