using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Entities.Notification
{
    public class CreateEmailGatewayRequest
    {
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public bool SMTPEnableSSL { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPSenderEmail { get; set; }
        public string SMTPSenderName { get; set; }
        public int Status { get; set; }
    }
    public class UpdateEmailGatewayRequest
    {
        public int EmailGatewayID { get; set; }
        public string SMTPServer { get; set; }
        public int SMTPPort { get; set; }
        public bool SMTPEnableSSL { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPSenderEmail { get; set; }
        public string SMTPSenderName { get; set; }
        public int Status { get; set; }
    }
    public class CreateSMSGatewayRequest
    {
        public string SMSGatewayName { get; set; }
        public string GatewayURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderID { get; set; }
        public string ReponseSuccess { get; set; }
        public string ReponseError { get; set; }
        public int Status { get; set; }
    }

    public class UpdateSMSGatewayRequest
    {
        public int SMSGatewayID { get; set; }
        public string SMSGatewayName { get; set; }
        public string GatewayURL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SenderID { get; set; }
        public string ReponseSuccess { get; set; }
        public string ReponseError { get; set; }
        public int Status { get; set; }
    }

    public class CreateTemplateRequest
    {

        public int? TemplateTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? TemplateName { get; set; }

        public string? TemplateMsg { get; set; }

        public int Status { get; set; }
    }
    public class UpdateTemplateRequest
    {
        public long TemplateID { get; set; }

        public int? TemplateTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? TemplateName { get; set; }

        public string? TemplateMsg { get; set; }

        public int Status { get; set; }
    }
    public class GetTemplateRequest
    {
        public int? TemplateTypeId { get; set; }

        public string? ServiceType { get; set; }

        public int? Status { get; set; }
    }
    public class GetActiveTemplateRequest
    {
        public int? TemplateTypeId { get; set; }

        public string? ServiceType { get; set; }

        public string? TemplateName { get; set; }
    }
    public class CreateTemplateTypeRequest
    {
        public string TemplateTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }
    }

    public class UpdateTemplateTypeRequest
    {
        public int TemplateTypeID { get; set; }

        public string TemplateTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }
    }
    public class CreateServiceTypeRequest
    {
        public string ServiceTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }
    }


    public class UpdateServiceTypeRequest
    {
        public int ServiceTypeID { get; set; }

        public string ServiceTypeName { get; set; }

        public string? Description { get; set; }

        public int Status { get; set; }
    }
}
