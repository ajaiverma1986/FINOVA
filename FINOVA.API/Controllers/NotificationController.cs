using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Entities.Notification;
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
    public class NotificationController : BaseApiController
    {
        public readonly NotificationProvider _Provider;

        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;

        public NotificationController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new NotificationProvider();
            _callValidator = new AuthenticationHelper();
        }

        /// <summary>
        /// Create new Email Gateway configuration.
        /// </summary>
        [HttpPost("CreateEmailGateway")]
        public async Task<IActionResult> CreateEmailGateway(
            [FromBody] CreateEmailGatewayRequest request)
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

            response = await _Provider.CreateEmailGateway(
                request,
                CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Update Email Gateway configuration.
        /// </summary>
        [HttpPost("UpdateEmailGateway")]
        public async Task<IActionResult> UpdateEmailGateway(
            [FromBody] UpdateEmailGatewayRequest request)
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

            response = await _Provider.UpdateEmailGateway(
                request,
                CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Delete Email Gateway configuration.
        /// </summary>
        [HttpDelete("DeleteEmailGateway/{emailGatewayID}")]
        public async Task<IActionResult> DeleteEmailGateway(
            int emailGatewayID)
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

            response = await _Provider.DeleteEmailGateway(
                emailGatewayID,
                CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Get Email Gateway configuration by ID.
        /// </summary>
        [HttpGet("GetEmailGatewayByID")]
        public async Task<IActionResult> GetEmailGatewayByID(
            int emailGatewayID)
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

            response = await _Provider.GetEmailGatewayByID(
                emailGatewayID,
                CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Get all Email Gateway configurations.
        /// </summary>
        [HttpGet("GetAllEmailGateways")]
        public async Task<IActionResult> GetAllEmailGateways()
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

            response = await _Provider.GetAllEmailGateways(
                CallerUser);

            return Json(response);
        }

        /// <summary>
        /// Get active Email Gateway configuration.
        /// Intended for internal use.
        /// </summary>
        [HttpGet("GetActiveEmailGateway")]
        public async Task<IActionResult> GetActiveEmailGateway()
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

            response = await _Provider.GetActiveEmailGateway(
                CallerUser);

            return Json(response);
        }
        /// <summary>
        /// Create new SMS Gateway configuration.
        /// </summary>
        [HttpPost("CreateSMSGateway")]
        public async Task<IActionResult> CreateSMSGateway(
            [FromBody] CreateSMSGatewayRequest request)
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

            response = await _Provider.CreateSMSGateway(
                request,
                CallerUser);

            return Json(response);
        }


        /// <summary>
        /// Update SMS Gateway configuration.
        /// </summary>
        [HttpPost("UpdateSMSGateway")]
        public async Task<IActionResult> UpdateSMSGateway(
            [FromBody] UpdateSMSGatewayRequest request)
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

            response = await _Provider.UpdateSMSGateway(
                request,
                CallerUser);

            return Json(response);
        }


        /// <summary>
        /// Delete SMS Gateway configuration.
        /// </summary>
        [HttpDelete("DeleteSMSGateway/{smsGatewayID}")]
        public async Task<IActionResult> DeleteSMSGateway(
            int smsGatewayID)
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

            response = await _Provider.DeleteSMSGateway(
                smsGatewayID,
                CallerUser);

            return Json(response);
        }


        /// <summary>
        /// Get SMS Gateway configuration by ID.
        /// </summary>
        [HttpGet("GetSMSGatewayByID")]
        public async Task<IActionResult> GetSMSGatewayByID(
            int smsGatewayID)
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

            response = await _Provider.GetSMSGatewayByID(
                smsGatewayID,
                CallerUser);

            return Json(response);
        }


        /// <summary>
        /// Get all SMS Gateway configurations.
        /// </summary>
        [HttpGet("GetAllSMSGateways")]
        public async Task<IActionResult> GetAllSMSGateways()
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

            response = await _Provider.GetAllSMSGateways(
                CallerUser);

            return Json(response);
        }


        /// <summary>
        /// Get active SMS Gateway configuration.
        /// Internal use is recommended.
        /// </summary>
        [HttpGet("GetActiveSMSGateway")]
        public async Task<IActionResult> GetActiveSMSGateway()
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

            response = await _Provider.GetActiveSMSGateway(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // TEMPLATE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateTemplate")]
        public async Task<IActionResult> CreateTemplate(
            [FromBody] CreateTemplateRequest request)
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

            response = await _Provider.CreateTemplate(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateTemplate")]
        public async Task<IActionResult> UpdateTemplate(
            [FromBody] UpdateTemplateRequest request)
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

            response = await _Provider.UpdateTemplate(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteTemplate/{templateID}")]
        public async Task<IActionResult> DeleteTemplate(
            long templateID)
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

            response = await _Provider.DeleteTemplate(
                templateID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetTemplateByID")]
        public async Task<IActionResult> GetTemplateByID(
            long templateID)
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

            response = await _Provider.GetTemplateByID(
                templateID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE MASTER - GET ALL
        // ============================================================
        [HttpPost("GetAllTemplates")]
        public async Task<IActionResult> GetAllTemplates(
            [FromBody] GetTemplateRequest request)
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

            response = await _Provider.GetAllTemplates(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE MASTER - GET ACTIVE
        // ============================================================
        [HttpPost("GetActiveTemplates")]
        public async Task<IActionResult> GetActiveTemplates(
            [FromBody] GetActiveTemplateRequest request)
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

            response = await _Provider.GetActiveTemplates(
                request,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // TEMPLATE TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateTemplateType")]
        public async Task<IActionResult> CreateTemplateType(
            [FromBody] CreateTemplateTypeRequest request)
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

            response = await _Provider.CreateTemplateType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateTemplateType")]
        public async Task<IActionResult> UpdateTemplateType(
            [FromBody] UpdateTemplateTypeRequest request)
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

            response = await _Provider.UpdateTemplateType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteTemplateType/{templateTypeID}")]
        public async Task<IActionResult> DeleteTemplateType(
            int templateTypeID)
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

            response = await _Provider.DeleteTemplateType(
                templateTypeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetTemplateTypeByID")]
        public async Task<IActionResult> GetTemplateTypeByID(
            int templateTypeID)
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

            response = await _Provider.GetTemplateTypeByID(
                templateTypeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllTemplateTypes")]
        public async Task<IActionResult> GetAllTemplateTypes()
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

            response = await _Provider.GetAllTemplateTypes(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateServiceType")]
        public async Task<IActionResult> CreateServiceType(
            [FromBody] CreateServiceTypeRequest request)
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

            response = await _Provider.CreateServiceType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateServiceType")]
        public async Task<IActionResult> UpdateServiceType(
            [FromBody] UpdateServiceTypeRequest request)
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

            response = await _Provider.UpdateServiceType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteServiceType/{serviceTypeID}")]
        public async Task<IActionResult> DeleteServiceType(
            int serviceTypeID)
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

            response = await _Provider.DeleteServiceType(
                serviceTypeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetServiceTypeByID")]
        public async Task<IActionResult> GetServiceTypeByID(
            int serviceTypeID)
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

            response = await _Provider.GetServiceTypeByID(
                serviceTypeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllServiceTypes")]
        public async Task<IActionResult> GetAllServiceTypes()
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

            response = await _Provider.GetAllServiceTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveServiceTypes")]
        public async Task<IActionResult> GetActiveServiceTypes()
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

            response = await _Provider.GetActiveServiceTypes(
                CallerUser);

            return Json(response);
        }
    }
}