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
}
