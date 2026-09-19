using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.Wallet;
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
    public class WalletController:BaseApiController
    {
        public readonly WalletProvider _Provider;
        private readonly AuthenticationHelper _callValidator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public WalletController(IWebHostEnvironment webHostEnvironment)
        {
            _Provider = new WalletProvider();
            _callValidator = new AuthenticationHelper();
            _webHostEnvironment = webHostEnvironment;
        }
        // ============================================================
        // CREATE COMPANY ACCOUNT
        // ============================================================
        [HttpPost("CreateCompanyAccount")]
        public async Task<IActionResult> CreateCompanyAccount(
            [FromForm] CreateCompanyAccountUploadRequest request)
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

            string? fileUrl = null;

            // --------------------------------------------------------
            // 3. Upload File
            // --------------------------------------------------------
            if (request.File != null &&
                request.File.Length > 0)
            {
                string extension = Path
                    .GetExtension(request.File.FileName)
                    .ToLowerInvariant();

                // ----------------------------------------------------
                // Allowed Extensions
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
                // Maximum File Size = 5 MB
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
                // wwwroot/uploads/company-account/{OrganizationId}
                // ----------------------------------------------------
                string uploadFolder = Path.Combine(
                    webRootPath,
                    "uploads",
                    "company-account",
                    request.OrganizationId.ToString());

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
                // Generate File URL
                // ----------------------------------------------------
                fileUrl =
                    $"/uploads/company-account/" +
                    $"{request.OrganizationId}/" +
                    $"{uniqueFileName}";
            }

            // --------------------------------------------------------
            // 4. Create Provider Request
            // --------------------------------------------------------
            CreateCompanyAccountRequest providerRequest =
                new CreateCompanyAccountRequest
                {
                    OrganizationId = request.OrganizationId,
                    ApplicationId = request.ApplicationId,
                    BankId = request.BankId,

                    AccountType = request.AccountType,
                    AccountName = request.AccountName,
                    AccountNo = request.AccountNo,

                    Ifsccode = request.Ifsccode,

                    BranchName = request.BranchName,
                    BranchCode = request.BranchCode,
                    BranchAddress = request.BranchAddress,

                    FileURL = fileUrl,

                    Remarks = request.Remarks,
                    Status = request.Status
                };

            // --------------------------------------------------------
            // 5. Call Provider
            // --------------------------------------------------------
            response =
                await _Provider.CreateCompanyAccount(
                    providerRequest,
                    CallerUser);

            return Json(response);
        }

        // ============================================================
        // UPDATE COMPANY ACCOUNT
        // ============================================================
        [HttpPost("UpdateCompanyAccount")]
        public async Task<IActionResult> UpdateCompanyAccount(
            [FromForm] UpdateCompanyAccountUploadRequest request)
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

            string? fileUrl = null;

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

                // ----------------------------------------------------
                // Maximum File Size = 5 MB
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
                // Create Upload Folder
                // ----------------------------------------------------
                string uploadFolder = Path.Combine(
                    webRootPath,
                    "uploads",
                    "company-account",
                    request.OrganizationId.ToString());

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
                    $"/uploads/company-account/" +
                    $"{request.OrganizationId}/" +
                    $"{uniqueFileName}";
            }

            // --------------------------------------------------------
            // 4. Create Provider Request
            // --------------------------------------------------------
            UpdateCompanyAccountRequest providerRequest =
                new UpdateCompanyAccountRequest
                {
                    CompanyAccountId =
                        request.CompanyAccountId,

                    OrganizationId =
                        request.OrganizationId,

                    ApplicationId =
                        request.ApplicationId,

                    BankId =
                        request.BankId,

                    AccountType =
                        request.AccountType,

                    AccountName =
                        request.AccountName,

                    AccountNo =
                        request.AccountNo,

                    Ifsccode =
                        request.Ifsccode,

                    BranchName =
                        request.BranchName,

                    BranchCode =
                        request.BranchCode,

                    BranchAddress =
                        request.BranchAddress,

                    FileURL =
                        fileUrl,

                    Remarks =
                        request.Remarks,

                    Status =
                        request.Status
                };

            // --------------------------------------------------------
            // 5. Call Provider
            // --------------------------------------------------------
            response =
                await _Provider.UpdateCompanyAccount(
                    providerRequest,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE COMPANY ACCOUNT
        // ============================================================
        [HttpDelete("DeleteCompanyAccount/{companyAccountId}")]
        public async Task<IActionResult> DeleteCompanyAccount(
            long companyAccountId)
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
                await _Provider.DeleteCompanyAccount(
                    companyAccountId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET COMPANY ACCOUNT BY ID
        // ============================================================
        [HttpGet("GetCompanyAccountByID")]
        public async Task<IActionResult> GetCompanyAccountByID(
            long companyAccountId)
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
                await _Provider.GetCompanyAccountByID(
                    companyAccountId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL COMPANY ACCOUNTS
        // ============================================================
        [HttpGet("GetAllCompanyAccounts")]
        public async Task<IActionResult> GetAllCompanyAccounts()
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
                await _Provider.GetAllCompanyAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE COMPANY ACCOUNTS
        // ============================================================
        [HttpGet("GetActiveCompanyAccounts")]
        public async Task<IActionResult> GetActiveCompanyAccounts()
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
                await _Provider.GetActiveCompanyAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION ID
        // ============================================================
        [HttpGet("GetCompanyAccountsByOrganizationId")]
        public async Task<IActionResult> GetCompanyAccountsByOrganizationId(
            int organizationId)
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
                await _Provider.GetCompanyAccountsByOrganizationId(
                    organizationId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY APPLICATION ID
        // ============================================================
        [HttpGet("GetCompanyAccountsByApplicationId")]
        public async Task<IActionResult> GetCompanyAccountsByApplicationId(
            int applicationId)
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
                await _Provider.GetCompanyAccountsByApplicationId(
                    applicationId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION + APPLICATION
        // ============================================================
        [HttpGet("GetCompanyAccountsByOrganizationApplication")]
        public async Task<IActionResult>
            GetCompanyAccountsByOrganizationApplication(
                int organizationId,
                int applicationId)
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
                await _Provider.GetCompanyAccountsByOrganizationApplication(
                    organizationId,
                    applicationId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE PAYIN REQUEST
        // ============================================================
        [HttpPost("CreatePayinRequest")]
        public async Task<IActionResult> CreatePayinRequest(
            [FromBody] CreatePayinRequestRequest request)
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
                await _Provider.CreatePayinRequest(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPROVE / REJECT PAYIN REQUEST
        // ============================================================
        [HttpPost("ApproveRejectPayinRequest")]
        public async Task<IActionResult> ApproveRejectPayinRequest(
            [FromBody] ApproveRejectPayinRequest request)
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
                await _Provider.ApproveRejectPayinRequest(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET PAYIN REQUEST BY ID
        // ============================================================
        [HttpGet("GetPayinRequestByID")]
        public async Task<IActionResult> GetPayinRequestByID(
            long requestID)
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
                await _Provider.GetPayinRequestByID(
                    requestID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL PAYIN REQUESTS
        // ============================================================
        [HttpGet("GetAllPayinRequests")]
        public async Task<IActionResult> GetAllPayinRequests()
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
                await _Provider.GetAllPayinRequests(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET PAYIN REQUESTS BY USER MASTER ID
        // ============================================================
        [HttpGet("GetPayinRequestsByUserMasterID")]
        public async Task<IActionResult> GetPayinRequestsByUserMasterID(
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
                await _Provider.GetPayinRequestsByUserMasterID(
                    userMasterId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET PAYIN REQUESTS BY STATUS
        // ============================================================
        [HttpGet("GetPayinRequestsByStatus")]
        public async Task<IActionResult> GetPayinRequestsByStatus(
            int status)
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
                await _Provider.GetPayinRequestsByStatus(
                    status,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // SEARCH PAYIN REQUESTS WITH FILTERS + PAGING
        // ============================================================
        [HttpPost("SearchPayinRequests")]
        public async Task<IActionResult> SearchPayinRequests(
            [FromBody] SearchPayinRequest request)
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
                await _Provider.SearchPayinRequests(
                    request,
                    CallerUser);

            return Json(response);
        }
    }
}
