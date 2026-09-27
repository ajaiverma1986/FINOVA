using FINOVA.DataModel.Entities.Notification;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;
using System.Net.Mail;
using System.Net;

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
        // ============================================================
        // CREATE OTP
        // ============================================================
        public async Task<SimpleResponse> CreateOTP(
            CreateOTPRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.MobileNo) ||
                string.IsNullOrWhiteSpace(request.OTP))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Normalize
            request.MobileNo = request.MobileNo.Trim();
            request.OTP = request.OTP.Trim();

            request.OTPSender =
                string.IsNullOrWhiteSpace(request.OTPSender)
                    ? null
                    : request.OTPSender.Trim();

            request.OTPMessage =
                string.IsNullOrWhiteSpace(request.OTPMessage)
                    ? null
                    : request.OTPMessage.Trim();

            // Validate mobile number
            if (request.MobileNo.Length != 10 ||
                !request.MobileNo.All(char.IsDigit))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // OTP max length based on VARCHAR(10)
            if (request.OTP.Length > 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Sender max length based on VARCHAR(10)
            if (!string.IsNullOrEmpty(request.OTPSender) &&
                request.OTPSender.Length > 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Default OTP validity
            if (request.Resettime <= 0)
            {
                request.Resettime = 5;
            }

            response.Result =
                await _repository.CreateOTP(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // VALIDATE OTP
        // ============================================================
        public async Task<SimpleResponse> ValidateOTP(
            ValidateOTPRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.MobileNo) ||
                string.IsNullOrWhiteSpace(request.OTP))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.MobileNo = request.MobileNo.Trim();
            request.OTP = request.OTP.Trim();

            // Validate mobile
            if (request.MobileNo.Length != 10 ||
                !request.MobileNo.All(char.IsDigit))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.OTP.Length > 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.ValidateOTP(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // EXPIRE OTP
        // ============================================================
        public async Task<SimpleResponse> ExpireOTP(
            long otpID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (otpID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.ExpireOTP(
                    otpID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // EXPIRE OLD OTPs
        // ============================================================
        public async Task<SimpleResponse> ExpireOldOTPs(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.ExpireOldOTPs(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET / SEARCH OTP LIST
        // ============================================================
        public async Task<SimpleResponse> GetAllOTPs(
            GetOTPRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // OTP ID
            // ========================================================
            if (request.OTPID.HasValue &&
                request.OTPID.Value <= 0)
            {
                request.OTPID = null;
            }


            // ========================================================
            // MOBILE NUMBER
            // ========================================================
            request.MobileNo =
                string.IsNullOrWhiteSpace(request.MobileNo)
                    ? null
                    : request.MobileNo.Trim();

            if (!string.IsNullOrEmpty(request.MobileNo))
            {
                if (request.MobileNo.Length != 10 ||
                    !request.MobileNo.All(char.IsDigit))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }
            }


            // ========================================================
            // OTP SENDER
            // ========================================================
            request.OTPSender =
                string.IsNullOrWhiteSpace(request.OTPSender)
                    ? null
                    : request.OTPSender.Trim();

            if (!string.IsNullOrEmpty(request.OTPSender) &&
                request.OTPSender.Length > 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // DATE RANGE
            // ========================================================
            if (request.FromDate.HasValue)
            {
                request.FromDate =
                    request.FromDate.Value.Date;
            }

            if (request.ToDate.HasValue)
            {
                request.ToDate =
                    request.ToDate.Value.Date;
            }

            if (request.FromDate.HasValue &&
                request.ToDate.HasValue &&
                request.FromDate.Value >
                request.ToDate.Value)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // PAGING
            // ========================================================
            if (request.PageNumber <= 0)
            {
                request.PageNumber = 1;
            }

            if (request.PageSize <= 0)
            {
                request.PageSize = 20;
            }

            if (request.PageSize > 500)
            {
                request.PageSize = 500;
            }


            // ========================================================
            // CALL REPOSITORY
            // ========================================================
            response.Result =
                await _repository.GetAllOTPs(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE OTP BY MOBILE NUMBER
        // ============================================================
        public async Task<SimpleResponse> GetActiveOTPByMobile(
            string mobileNo,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (string.IsNullOrWhiteSpace(mobileNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            mobileNo = mobileNo.Trim();

            if (mobileNo.Length != 10 ||
                !mobileNo.All(char.IsDigit))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveOTPByMobile(
                    mobileNo,
                    serviceUser);

            return response;
        }
        // ============================================================
        // GENERIC EMAIL SENDER
        // ============================================================
        public async Task<SimpleResponse> SendEmail(
            string toEmail,
            string templateName,
            Dictionary<string, string>? templateInputs,
            IFINOVAServiceUser serviceUser,
            List<string>? ccEmails = null,
            List<string>? bccEmails = null,
            List<Attachment>? attachments = null)
        {
            SimpleResponse response = new SimpleResponse();

            try
            {
                // ====================================================
                // 1. VALIDATE REQUIRED INPUT
                // ====================================================
                if (string.IsNullOrWhiteSpace(toEmail))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (string.IsNullOrWhiteSpace(templateName))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                toEmail = toEmail.Trim();
                templateName = templateName.Trim();


                // ====================================================
                // 2. VALIDATE TO EMAIL
                // ====================================================
                if (!IsValidEmail(toEmail))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                // ====================================================
                // 3. VALIDATE CC EMAILS
                // ====================================================
                if (ccEmails != null)
                {
                    foreach (var email in ccEmails)
                    {
                        if (string.IsNullOrWhiteSpace(email) ||
                            !IsValidEmail(email.Trim()))
                        {
                            response.SetError(ErrorCodes.SP_133);
                            return response;
                        }
                    }
                }


                // ====================================================
                // 4. VALIDATE BCC EMAILS
                // ====================================================
                if (bccEmails != null)
                {
                    foreach (var email in bccEmails)
                    {
                        if (string.IsNullOrWhiteSpace(email) ||
                            !IsValidEmail(email.Trim()))
                        {
                            response.SetError(ErrorCodes.SP_133);
                            return response;
                        }
                    }
                }


                // ====================================================
                // 5. GET ACTIVE EMAIL GATEWAY
                // ====================================================
                var emailGateway =
                    await _repository.GetActiveEmailGateway(
                        serviceUser);


                // ====================================================
                // 6. ACTIVE EMAIL GATEWAY MUST EXIST
                // ====================================================
                if (emailGateway == null)
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                // ====================================================
                // 7. VALIDATE ACTIVE EMAIL GATEWAY CONFIGURATION
                // ====================================================
                if (string.IsNullOrWhiteSpace(
                        emailGateway.SMTPServer))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (emailGateway.SMTPPort <= 0)
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (string.IsNullOrWhiteSpace(
                        emailGateway.SMTPUsername))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (string.IsNullOrWhiteSpace(
                        emailGateway.SMTPPassword))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (string.IsNullOrWhiteSpace(
                        emailGateway.SMTPSenderEmail))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (!IsValidEmail(
                        emailGateway.SMTPSenderEmail))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                if (string.IsNullOrWhiteSpace(
                        emailGateway.SMTPSenderName))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                // ====================================================
                // 8. GET ONLY ACTIVE TEMPLATE
                // ====================================================
                GetActiveTemplateRequest templateRequest =
                    new GetActiveTemplateRequest
                    {
                        TemplateName = templateName
                    };


                var templates =
                    await _repository.GetActiveTemplates(
                        templateRequest,
                        serviceUser);


                // ====================================================
                // 9. ACTIVE TEMPLATE MUST EXIST
                // ====================================================
                if (templates == null ||
                    templates.Count == 0)
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                // ====================================================
                // 10. GET TEMPLATE
                // ====================================================
                var template =
                    templates.FirstOrDefault(x =>
                        !string.IsNullOrWhiteSpace(
                            x.TemplateName) &&
                        x.TemplateName.Equals(
                            templateName,
                            StringComparison.OrdinalIgnoreCase));


                if (template == null)
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                if (string.IsNullOrWhiteSpace(
                        template.TemplateMsg))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }


                // ====================================================
                // 11. PREPARE EMAIL SUBJECT
                // ====================================================
                // Currently TemplateMaster does not have separate
                // Subject column, therefore TemplateName is used.
                string subject =
                    template.TemplateName ?? templateName;


                // ====================================================
                // 12. PREPARE HTML BODY
                // ====================================================
                string emailBody =
                    template.TemplateMsg;


                // ====================================================
                // 13. REPLACE TEMPLATE INPUTS
                //
                // Example:
                // {{UserName}} -> Ajai
                // {{OTP}} -> 458921
                // {{Amount}} -> 5000
                // ====================================================
                if (templateInputs != null)
                {
                    foreach (var item in templateInputs)
                    {
                        string key =
                            "{{" + item.Key + "}}";

                        string value =
                            item.Value ?? string.Empty;


                        emailBody =
                            emailBody.Replace(
                                key,
                                value,
                                StringComparison.OrdinalIgnoreCase);


                        subject =
                            subject.Replace(
                                key,
                                value,
                                StringComparison.OrdinalIgnoreCase);
                    }
                }


                // ====================================================
                // 14. CREATE MAIL MESSAGE
                // ====================================================
                using MailMessage mailMessage =
                    new MailMessage();


                // ====================================================
                // FROM
                // ====================================================
                mailMessage.From =
                    new MailAddress(
                        emailGateway.SMTPSenderEmail,
                        emailGateway.SMTPSenderName);


                // ====================================================
                // TO
                // ====================================================
                mailMessage.To.Add(
                    new MailAddress(toEmail));


                // ====================================================
                // CC - OPTIONAL
                // ====================================================
                if (ccEmails != null)
                {
                    foreach (var cc in ccEmails)
                    {
                        if (!string.IsNullOrWhiteSpace(cc))
                        {
                            mailMessage.CC.Add(
                                new MailAddress(
                                    cc.Trim()));
                        }
                    }
                }


                // ====================================================
                // BCC - OPTIONAL
                // ====================================================
                if (bccEmails != null)
                {
                    foreach (var bcc in bccEmails)
                    {
                        if (!string.IsNullOrWhiteSpace(bcc))
                        {
                            mailMessage.Bcc.Add(
                                new MailAddress(
                                    bcc.Trim()));
                        }
                    }
                }


                // ====================================================
                // SUBJECT
                // ====================================================
                mailMessage.Subject = subject;


                // ====================================================
                // HTML BODY
                // ====================================================
                mailMessage.Body = emailBody;

                mailMessage.IsBodyHtml = true;


                // ====================================================
                // 15. ATTACHMENTS - OPTIONAL
                // ====================================================
                if (attachments != null &&
                    attachments.Count > 0)
                {
                    foreach (var attachment in attachments)
                    {
                        if (attachment != null)
                        {
                            mailMessage.Attachments.Add(
                                attachment);
                        }
                    }
                }


                // ====================================================
                // 16. SMTP CLIENT
                // ====================================================
                using SmtpClient smtpClient =
                    new SmtpClient(
                        emailGateway.SMTPServer,
                        emailGateway.SMTPPort);


                smtpClient.UseDefaultCredentials = false;


                smtpClient.Credentials =
                    new NetworkCredential(
                        emailGateway.SMTPUsername,
                        emailGateway.SMTPPassword);


                smtpClient.EnableSsl =
                    emailGateway.SMTPEnableSSL;


                // ====================================================
                // 17. SEND EMAIL
                // ====================================================
                await smtpClient.SendMailAsync(
                    mailMessage);


                // ====================================================
                // 18. SUCCESS
                // ====================================================
                response.Result = true;

                return response;
            }
            catch
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
        }


        // ============================================================
        // EMAIL VALIDATION
        // ============================================================
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                MailAddress mailAddress =
                    new MailAddress(email);

                return mailAddress.Address.Equals(
                    email,
                    StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}