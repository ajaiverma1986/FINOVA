using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.UserMgr;
using FINOVA.Provider;
using FINOVA.Provider.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers;

[ApiController]
[Route("UserMgr")]
[ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
[ServiceFilter(typeof(FINOVExceptionFilterService))]
public class UserMgrFilesController : BaseApiController
{
    public sealed class KycFileRequest
    {
        public long UserMasterID { get; set; }
        public IFormFile File { get; set; } = null!;
    }

    [HttpPost("UploadUserKycFile")]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(11 * 1024 * 1024)]
    public async Task<IActionResult> UploadUserKycFile([FromForm] KycFileRequest request)
    {
        var result = new SimpleResponse();
        var error = await new AuthenticationHelper().AuthenticateAndAuthorize(CallerUser, true);
        if (error.HasError) { result.SetError(error); return Json(result); }
        if (CallerUser.UserMasterID.GetValueOrDefault() <= 0 || string.IsNullOrWhiteSpace(CallerUser.UserToken))
            return Unauthorized();
        if (request.UserMasterID <= 0 || request.File == null || request.File.Length == 0 || request.File.Length > 10 * 1024 * 1024)
            return BadRequest(new { message = "Select a file up to 10 MB and a valid user." });
        var target = await new UserMgrProvider().GetUserMasterByID(request.UserMasterID, CallerUser);
        if (target.HasError) return Json(target);
        if (target.Result is not GetUserMasterResponse user) return NotFound();
        // The application organization may differ from the authenticated user's organization.
        var callerResponse = await new UserMgrProvider().GetUserMasterByID(
            CallerUser.UserMasterID.Value, CallerUser);
        if (callerResponse.HasError) return Json(callerResponse);
        if (callerResponse.Result is not GetUserMasterResponse caller) return StatusCode(403);
        var sameOrganization = user.OrganizationID.HasValue &&
            user.OrganizationID == caller.OrganizationID;
        if (user.UserMasterID != caller.UserMasterID && !sameOrganization)
        {
            var permission = await new AuthorizationHelper().Authorize(
                CallerUser, FINOVA.DataModel.Common.Permissions.UPLOAD_KYC);
            if (permission.HasError) return StatusCode(403);
        }
        var extension = Path.GetExtension(request.File.FileName).ToLowerInvariant();
        var contentType = extension switch {
            ".pdf" => "application/pdf", ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png", _ => null
        };
        if (contentType == null) return BadRequest(new { message = "Use a PDF, JPG, or PNG document." });
        using var buffer = new MemoryStream();
        await request.File.CopyToAsync(buffer, HttpContext.RequestAborted);
        var bytes = buffer.ToArray();
        var valid = extension == ".pdf" ? bytes.AsSpan().StartsWith("%PDF-"u8)
            : extension == ".png" ? bytes.AsSpan().StartsWith(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 })
            : bytes.Length >= 3 && bytes[0] == 255 && bytes[1] == 216 && bytes[2] == 255;
        if (!valid) return BadRequest(new { message = "The file does not match its document format." });
        // FileUrl uses the existing KYC storage convention: a filename under PartnerDocument/{user ID}.
        var filename = new FileManager().SaveKYCDocument(bytes, request.UserMasterID.ToString(),
            "document" + extension, request.UserMasterID + "_" + Guid.NewGuid().ToString("N"));
        result.Result = new { FileUrl = filename, MediaExtension = extension, MediaContentType = contentType };
        return Json(result);
    }
}
