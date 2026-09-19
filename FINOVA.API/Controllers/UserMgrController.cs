using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.UserMgr;
using FINOVA.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserMgrController(IWebHostEnvironment webHostEnvironment) 
        {
            _Provider = new UserMgrProvider();
            _callValidator = new AuthenticationHelper();
            _webHostEnvironment = webHostEnvironment;
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

        [HttpPost]
        [Route("CreateUserKyc")]
        public async Task<IActionResult> CreateUserKyc(
    [FromForm] CreateUserKycUploadRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            if (request.File == null || request.File.Length == 0)
            {
                return BadRequest("Please select a file.");
            }

            // --------------------------------------------------------
            // 1. Validate file extension
            // --------------------------------------------------------
            string extension = Path
                .GetExtension(request.File.FileName)
                .ToLowerInvariant();

            string[] allowedExtensions =
            {
        ".pdf",
        ".jpg",
        ".jpeg",
        ".png"
    };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest(
                    "Only PDF, JPG, JPEG and PNG files are allowed.");
            }

            // --------------------------------------------------------
            // 2. Validate file size - Example: Maximum 5 MB
            // --------------------------------------------------------
            const long maxFileSize = 5 * 1024 * 1024;

            if (request.File.Length > maxFileSize)
            {
                return BadRequest(
                    "File size cannot be greater than 5 MB.");
            }

            // --------------------------------------------------------
            // 3. Create upload directory
            // wwwroot/uploads/kyc/{UserMasterId}
            // --------------------------------------------------------
            string uploadFolder = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "uploads",
                "kyc",
                request.UserMasterId.ToString());

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // --------------------------------------------------------
            // 4. Generate unique file name
            // --------------------------------------------------------
            string uniqueFileName =
                $"{Guid.NewGuid():N}{extension}";

            string physicalFilePath = Path.Combine(
                uploadFolder,
                uniqueFileName);

            // --------------------------------------------------------
            // 5. Save file
            // --------------------------------------------------------
            await using (var stream = new FileStream(
                physicalFilePath,
                FileMode.Create))
            {
                await request.File.CopyToAsync(stream);
            }

            // --------------------------------------------------------
            // 6. Generate URL/path to store in database
            // --------------------------------------------------------
            string fileUrl =
                $"/uploads/kyc/{request.UserMasterId}/{uniqueFileName}";

            // --------------------------------------------------------
            // 7. Get Content Type
            // --------------------------------------------------------
            var contentTypeProvider =
                new FileExtensionContentTypeProvider();

            if (!contentTypeProvider.TryGetContentType(
                    uniqueFileName,
                    out string? contentType))
            {
                contentType = "application/octet-stream";
            }

            // --------------------------------------------------------
            // 8. Prepare Provider request
            // --------------------------------------------------------
            CreateUserKycRequest providerRequest =
                new CreateUserKycRequest
                {
                    UserMasterId = request.UserMasterId,
                    KycID = request.KycID,
                    DocumentNo = request.DocumentNo,

                    FileUrl = fileUrl,
                    MediaExtension = extension,
                    MediaContentType = contentType,

                    RejectedReason = request.RejectedReason,
                    Status = request.Status
                };

            // --------------------------------------------------------
            // 9. Call Provider
            // --------------------------------------------------------
            var response =
                await _Provider.CreateUserKyc(
                    providerRequest,
                    CallerUser);

            return Ok(response);
        }


        // ============================================================
        // UPDATE USER KYC
        // ============================================================
        [HttpPost("UpdateUserKyc")]
        public async Task<IActionResult> UpdateUserKyc(
            [FromForm] UpdateUserKycUploadRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            // --------------------------------------------------------
            // 1. Authentication / Authorization
            // --------------------------------------------------------
            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            // --------------------------------------------------------
            // 2. Validate Request
            // --------------------------------------------------------
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            if (request.UserKycMasterId <= 0 ||
                request.UserMasterId <= 0 ||
                request.KycID <= 0)
            {
                return BadRequest("Invalid KYC information.");
            }

            // --------------------------------------------------------
            // 3. File variables
            // --------------------------------------------------------
            string? fileUrl = null;
            string? mediaExtension = null;
            string? mediaContentType = null;

            // --------------------------------------------------------
            // 4. Check if user uploaded a NEW file
            // --------------------------------------------------------
            if (request.File != null &&
                request.File.Length > 0)
            {
                // ----------------------------------------------------
                // Get Extension
                // ----------------------------------------------------
                string extension = Path
                    .GetExtension(request.File.FileName)
                    .ToLowerInvariant();

                // ----------------------------------------------------
                // Validate Extension
                // ----------------------------------------------------
                string[] allowedExtensions =
                {
            ".pdf",
            ".jpg",
            ".jpeg",
            ".png"
        };

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest(
                        "Only PDF, JPG, JPEG and PNG files are allowed.");
                }

                // ----------------------------------------------------
                // Validate File Size - Maximum 5 MB
                // ----------------------------------------------------
                const long maxFileSize = 5 * 1024 * 1024;

                if (request.File.Length > maxFileSize)
                {
                    return BadRequest(
                        "File size cannot be greater than 5 MB.");
                }

                // ----------------------------------------------------
                // 5. Create Upload Folder
                // ----------------------------------------------------
                string webRootPath =
                    _webHostEnvironment.WebRootPath;

                // Handle case where wwwroot does not exist
                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot");
                }

                string uploadFolder = Path.Combine(
                    webRootPath,
                    "uploads",
                    "kyc",
                    request.UserMasterId.ToString());

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // ----------------------------------------------------
                // 6. Generate Unique File Name
                // ----------------------------------------------------
                string uniqueFileName =
                    $"{Guid.NewGuid():N}{extension}";

                string physicalFilePath = Path.Combine(
                    uploadFolder,
                    uniqueFileName);

                // ----------------------------------------------------
                // 7. Save File
                // ----------------------------------------------------
                await using (FileStream stream = new FileStream(
                    physicalFilePath,
                    FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                // ----------------------------------------------------
                // 8. Prepare File Information
                // ----------------------------------------------------
                fileUrl =
                    $"/uploads/kyc/{request.UserMasterId}/{uniqueFileName}";

                mediaExtension = extension;

                // ----------------------------------------------------
                // 9. Get Content Type
                // ----------------------------------------------------
                var contentTypeProvider =
                    new FileExtensionContentTypeProvider();

                if (!contentTypeProvider.TryGetContentType(
                        uniqueFileName,
                        out string? contentType))
                {
                    contentType = "application/octet-stream";
                }

                mediaContentType = contentType;
            }

            // --------------------------------------------------------
            // 10. Create Provider Request
            // --------------------------------------------------------
            UpdateUserKycRequest providerRequest =
                new UpdateUserKycRequest
                {
                    UserKYCID =
                        request.UserKycMasterId,

                    UserMasterId =
                        request.UserMasterId,

                    KycID =
                        request.KycID,

                    DocumentNo =
                        request.DocumentNo,

                    FileUrl =
                        fileUrl,

                    MediaExtension =
                        mediaExtension,

                    MediaContentType =
                        mediaContentType,

                    RejectedReason =
                        request.RejectedReason,

                    Status =
                        request.Status
                };

            // --------------------------------------------------------
            // 11. Call Provider
            // --------------------------------------------------------
            response =
                await _Provider.UpdateUserKyc(
                    providerRequest,
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
            [FromForm] CreateUserBankAccountUploadRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            // --------------------------------------------------------
            // 1. Authentication / Authorization
            // --------------------------------------------------------
            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            // --------------------------------------------------------
            // 2. Validate Request
            // --------------------------------------------------------
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            if (request.UserMasterID <= 0 ||
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo) ||
                string.IsNullOrWhiteSpace(request.Ifsccode))
            {
                return BadRequest("Invalid bank account information.");
            }

            // --------------------------------------------------------
            // 3. File Variables
            // --------------------------------------------------------
            string? fileUrl = null;
            string? mediaExtension = null;
            string? mediaContentType = null;

            // --------------------------------------------------------
            // 4. Upload File
            // --------------------------------------------------------
            if (request.File != null &&
                request.File.Length > 0)
            {
                string extension = Path
                    .GetExtension(request.File.FileName)
                    .ToLowerInvariant();

                // ----------------------------------------------------
                // Validate Extension
                // ----------------------------------------------------
                string[] allowedExtensions =
                {
            ".pdf",
            ".jpg",
            ".jpeg",
            ".png"
        };

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest(
                        "Only PDF, JPG, JPEG and PNG files are allowed.");
                }

                // ----------------------------------------------------
                // Maximum 5 MB
                // ----------------------------------------------------
                const long maxFileSize =
                    5 * 1024 * 1024;

                if (request.File.Length > maxFileSize)
                {
                    return BadRequest(
                        "File size cannot be greater than 5 MB.");
                }

                // ----------------------------------------------------
                // Get wwwroot
                // ----------------------------------------------------
                string webRootPath =
                    _webHostEnvironment.WebRootPath;

                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot");
                }

                // ----------------------------------------------------
                // Create Folder
                //
                // wwwroot/uploads/bank/{UserMasterID}
                // ----------------------------------------------------
                string uploadFolder = Path.Combine(
                    webRootPath,
                    "uploads",
                    "bank",
                    request.UserMasterID.ToString());

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // ----------------------------------------------------
                // Generate Unique File Name
                // ----------------------------------------------------
                string uniqueFileName =
                    $"{Guid.NewGuid():N}{extension}";

                string physicalFilePath =
                    Path.Combine(
                        uploadFolder,
                        uniqueFileName);

                // ----------------------------------------------------
                // Save File
                // ----------------------------------------------------
                await using (FileStream stream =
                    new FileStream(
                        physicalFilePath,
                        FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                // ----------------------------------------------------
                // Generate URL
                // ----------------------------------------------------
                fileUrl =
                    $"/uploads/bank/{request.UserMasterID}/{uniqueFileName}";

                mediaExtension = extension;

                // ----------------------------------------------------
                // Get Content Type
                // ----------------------------------------------------
                var contentTypeProvider =
                    new FileExtensionContentTypeProvider();

                if (!contentTypeProvider.TryGetContentType(
                        uniqueFileName,
                        out string? contentType))
                {
                    contentType =
                        "application/octet-stream";
                }

                mediaContentType = contentType;
            }

            // --------------------------------------------------------
            // 5. Create Provider Request
            // --------------------------------------------------------
            CreateUserBankAccountRequest providerRequest =
                new CreateUserBankAccountRequest
                {
                    UserMasterID = request.UserMasterID,
                    BankId = request.BankId,

                    AccountName = request.AccountName,
                    AccountNo = request.AccountNo,
                    Ifsccode = request.Ifsccode,

                    FileUrl = fileUrl,
                    MediaExtension = mediaExtension,
                    MediaContentType = mediaContentType,

                    Status = request.Status
                };

            // --------------------------------------------------------
            // 6. Call Provider
            // --------------------------------------------------------
            response =
                await _Provider.CreateUserBankAccount(
                    providerRequest,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE USER BANK ACCOUNT
        // ============================================================
        [HttpPost("UpdateUserBankAccount")]
        public async Task<IActionResult> UpdateUserBankAccount(
            [FromForm] UpdateUserBankAccountUploadRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            // --------------------------------------------------------
            // 1. Authentication / Authorization
            // --------------------------------------------------------
            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            // --------------------------------------------------------
            // 2. Validate Request
            // --------------------------------------------------------
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            if (request.OriginatorAccountID <= 0 ||
                request.UserMasterID <= 0 ||
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo) ||
                string.IsNullOrWhiteSpace(request.Ifsccode))
            {
                return BadRequest("Invalid bank account information.");
            }

            string? fileUrl = null;
            string? mediaExtension = null;
            string? mediaContentType = null;

            // --------------------------------------------------------
            // 3. Upload New File If Provided
            // --------------------------------------------------------
            if (request.File != null &&
                request.File.Length > 0)
            {
                string extension = Path
                    .GetExtension(request.File.FileName)
                    .ToLowerInvariant();

                string[] allowedExtensions =
                {
            ".pdf",
            ".jpg",
            ".jpeg",
            ".png"
        };

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest(
                        "Only PDF, JPG, JPEG and PNG files are allowed.");
                }

                // Maximum 5 MB
                const long maxFileSize =
                    5 * 1024 * 1024;

                if (request.File.Length > maxFileSize)
                {
                    return BadRequest(
                        "File size cannot be greater than 5 MB.");
                }

                string webRootPath =
                    _webHostEnvironment.WebRootPath;

                if (string.IsNullOrWhiteSpace(webRootPath))
                {
                    webRootPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot");
                }

                // ----------------------------------------------------
                // Folder
                // ----------------------------------------------------
                string uploadFolder = Path.Combine(
                    webRootPath,
                    "uploads",
                    "bank",
                    request.UserMasterID.ToString());

                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // ----------------------------------------------------
                // Generate File Name
                // ----------------------------------------------------
                string uniqueFileName =
                    $"{Guid.NewGuid():N}{extension}";

                string physicalFilePath =
                    Path.Combine(
                        uploadFolder,
                        uniqueFileName);

                // ----------------------------------------------------
                // Save File
                // ----------------------------------------------------
                await using (FileStream stream =
                    new FileStream(
                        physicalFilePath,
                        FileMode.Create))
                {
                    await request.File.CopyToAsync(stream);
                }

                // ----------------------------------------------------
                // URL
                // ----------------------------------------------------
                fileUrl =
                    $"/uploads/bank/{request.UserMasterID}/{uniqueFileName}";

                mediaExtension = extension;

                // ----------------------------------------------------
                // Content Type
                // ----------------------------------------------------
                var contentTypeProvider =
                    new FileExtensionContentTypeProvider();

                if (!contentTypeProvider.TryGetContentType(
                        uniqueFileName,
                        out string? contentType))
                {
                    contentType =
                        "application/octet-stream";
                }

                mediaContentType = contentType;
            }

            // --------------------------------------------------------
            // 4. Prepare Provider Request
            // --------------------------------------------------------
            UpdateUserBankAccountRequest providerRequest =
                new UpdateUserBankAccountRequest
                {
                    OriginatorAccountID =
                        request.OriginatorAccountID,

                    UserMasterID =
                        request.UserMasterID,

                    BankId =
                        request.BankId,

                    AccountName =
                        request.AccountName,

                    AccountNo =
                        request.AccountNo,

                    Ifsccode =
                        request.Ifsccode,

                    FileUrl =
                        fileUrl,

                    MediaExtension =
                        mediaExtension,

                    MediaContentType =
                        mediaContentType,

                    Status =
                        request.Status
                };

            // --------------------------------------------------------
            // 5. Call Provider
            // --------------------------------------------------------
            response =
                await _Provider.UpdateUserBankAccount(
                    providerRequest,
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
