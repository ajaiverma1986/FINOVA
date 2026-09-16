using FINOVA.DataModel.Entities.Notification;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;

namespace FINOVA.Provider
{
    public class NotificationProvider : BaseProvider
    {
        public readonly NotificationRepository _repository = null;

        public NotificationProvider()
        {
            _repository = new NotificationRepository();
        }

        /// <summary>
        /// Create new Email Gateway configuration.
        /// </summary>
        public async Task<SimpleResponse> CreateEmailGateway(
            CreateEmailGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPServer))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SMTPPort <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPUsername))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPPassword))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPSenderEmail))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPSenderName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateEmailGateway(
                    request,
                    serviceUser);

            return response;
        }

        /// <summary>
        /// Update existing Email Gateway configuration.
        /// </summary>
        public async Task<SimpleResponse> UpdateEmailGateway(
            UpdateEmailGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.EmailGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPServer))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SMTPPort <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPUsername))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPPassword))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPSenderEmail))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMTPSenderName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateEmailGateway(
                    request,
                    serviceUser);

            return response;
        }

        /// <summary>
        /// Delete Email Gateway.
        /// </summary>
        public async Task<SimpleResponse> DeleteEmailGateway(
            int emailGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (emailGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteEmailGateway(
                    emailGatewayID,
                    serviceUser);

            return response;
        }

        /// <summary>
        /// Get Email Gateway by ID.
        /// </summary>
        public async Task<SimpleResponse> GetEmailGatewayByID(
            int emailGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (emailGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetEmailGatewayByID(
                    emailGatewayID,
                    serviceUser);

            response.Result = result;

            return response;
        }

        /// <summary>
        /// Get all Email Gateway configurations.
        /// </summary>
        public async Task<SimpleResponse> GetAllEmailGateways(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllEmailGateways(
                    serviceUser);

            response.Result = result;

            return response;
        }

        /// <summary>
        /// Get active Email Gateway configuration.
        /// Intended for internal email sending service.
        /// </summary>
        public async Task<SimpleResponse> GetActiveEmailGateway(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActiveEmailGateway(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // SMS GATEWAY - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateSMSGateway(
            CreateSMSGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMSGatewayName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.GatewayURL))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SenderID))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateSMSGateway(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SMS GATEWAY - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateSMSGateway(
            UpdateSMSGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SMSGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SMSGatewayName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.GatewayURL))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.Password))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.SenderID))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateSMSGateway(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SMS GATEWAY - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteSMSGateway(
            int smsGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (smsGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteSMSGateway(
                    smsGatewayID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetSMSGatewayByID(
            int smsGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (smsGatewayID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetSMSGatewayByID(
                    smsGatewayID,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllSMSGateways(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllSMSGateways(
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveSMSGateway(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActiveSMSGateway(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // TEMPLATE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateTemplate(
            CreateTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

           

            if (string.IsNullOrWhiteSpace(request.TemplateName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TemplateMsg))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateTemplate(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTemplate(
            UpdateTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TemplateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TemplateName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TemplateMsg))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateTemplate(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTemplate(
            long templateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (templateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteTemplate(
                    templateID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTemplateByID(
            long templateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (templateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetTemplateByID(
                    templateID,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllTemplates(
            GetTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                request = new GetTemplateRequest();
            }

            var result =
                await _repository.GetAllTemplates(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveTemplates(
            GetActiveTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                request = new GetActiveTemplateRequest();
            }

            var result =
                await _repository.GetActiveTemplates(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // TEMPLATE TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateTemplateType(
            CreateTemplateTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TemplateTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateTemplateType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTemplateType(
            UpdateTemplateTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TemplateTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TemplateTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateTemplateType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTemplateType(
            int templateTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (templateTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteTemplateType(
                    templateTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTemplateTypeByID(
            int templateTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (templateTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetTemplateTypeByID(
                    templateTypeID,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllTemplateTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllTemplateTypes(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateServiceType(
            CreateServiceTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.ServiceTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateServiceType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateServiceType(
            UpdateServiceTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.ServiceTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateServiceType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteServiceType(
            int serviceTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteServiceType(
                    serviceTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetServiceTypeByID(
            int serviceTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetServiceTypeByID(
                    serviceTypeID,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllServiceTypes(
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActiveServiceTypes(
                    serviceUser);

            response.Result = result;

            return response;
        }
    }
}