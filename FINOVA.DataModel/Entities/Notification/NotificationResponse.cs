using FINOVA.DataModel.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Entities.Notification
{
    public class GetEmailGatewayResponse
    {
        public int EmailGatewayID { get; set; }

        public string SMTPServer { get; set; }

        public int SMTPPort { get; set; }

        public bool SMTPEnableSSL { get; set; }

        public string SMTPUsername { get; set; }

        // Do not expose SMTPPassword in normal GET APIs

        public string SMTPSenderEmail { get; set; }

        public string SMTPSenderName { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetActiveEmailGatewayResponse
    {
        public int EmailGatewayID { get; set; }

        public string SMTPServer { get; set; }

        public int SMTPPort { get; set; }

        public bool SMTPEnableSSL { get; set; }

        public string SMTPUsername { get; set; }

        public string SMTPPassword { get; set; }

        public string SMTPSenderEmail { get; set; }

        public string SMTPSenderName { get; set; }
    }
    public class GetSMSGatewayResponse
    {
        public int SMSGatewayID { get; set; }
        public string SMSGatewayName { get; set; }
        public string GatewayURL { get; set; }
        public string UserName { get; set; }
        public string SenderID { get; set; }
        public string ReponseSuccess { get; set; }
        public string ReponseError { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }

    public class GetActiveSMSGatewayResponse
    {
        public int SMSGatewayID { get; set; }
        public string SMSGatewayName { get; set; }
        public string GatewayURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderID { get; set; }
        public string ReponseSuccess { get; set; }
        public string ReponseError { get; set; }
    }
    public class GetTemplateResponse
    {
        public long TemplateID { get; set; }

        public int? TemplateTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? TemplateName { get; set; }

        public string? TemplateMsg { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetTemplateTypeResponse
    {
        public int TemplateTypeID { get; set; }

        public string TemplateTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetServiceTypeResponse
    {
        public int ServiceTypeID { get; set; }

        public string ServiceTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }


    public class GetActiveServiceTypeResponse
    {
        public int ServiceTypeID { get; set; }

        public string ServiceTypeName { get; set; }

        public string? Description { get; set; }
    }
    public class ValidateOTPResponse
    {
        public bool IsValid { get; set; }
        public long? OTPID { get; set; }
        public string? ResultCode { get; set; }
        public string? Message { get; set; }
    }


    public class ExpireOTPResponse
    {
        public long OTPID { get; set; }
        public bool IsExpired { get; set; }
        public string? Message { get; set; }
    }
    public class ExpireOldOTPResponse
    {
        public int ExpiredOTPCount { get; set; }
    }
    public class GetOTPResponse
    {
        public long OTPID { get; set; }
        public string? MobileNo { get; set; }
        public string? OTPSender { get; set; }
        public string? OTPMessage { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime CreatedOn { get; set; }
        public int Resettime { get; set; }

        public DateTime ExpiryTime { get; set; }

        public bool IsActive { get; set; }
    }
    public class GetOTPListResponse
    {
        public List<GetOTPResponse> Records { get; set; }
            = new List<GetOTPResponse>();

        public OTPPagingInfo Paging { get; set; }
            = new OTPPagingInfo();
    }
    public class OTPPagingInfo
    {
        public long TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }
    }
}
