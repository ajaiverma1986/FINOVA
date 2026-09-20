using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Wallet
{
    public class CreateCompanyAccountRequest
    {
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public int BankId { get; set; }

        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }

        public string? Ifsccode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchAddress { get; set; }
        public string? FileURL { get; set; }
        public string? Remarks { get; set; }

        public int Status { get; set; } = 1;
    }
    public class UpdateCompanyAccountRequest
    {
        public long CompanyAccountId { get; set; }

        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public int BankId { get; set; }

        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }

        public string? Ifsccode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchAddress { get; set; }
        public string? FileURL { get; set; }
        public string? Remarks { get; set; }

        public int Status { get; set; }
    }
    public class CreateCompanyAccountUploadRequest
    {
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public int BankId { get; set; }

        public string AccountType { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;

        public string? Ifsccode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchAddress { get; set; }

        public string? Remarks { get; set; }

        public IFormFile? File { get; set; }

        public int Status { get; set; } = 1;
    }
    public class UpdateCompanyAccountUploadRequest
    {
        public long CompanyAccountId { get; set; }

        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public int BankId { get; set; }

        public string AccountType { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountNo { get; set; } = string.Empty;

        public string? Ifsccode { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchAddress { get; set; }

        public string? Remarks { get; set; }

        // Optional during update
        public IFormFile? File { get; set; }

        public int Status { get; set; } = 1;
    }
    public class CreatePayinRequestRequest
    {
        public long UserMasterId { get; set; }
        public int PaymentChanelID { get; set; }
        public int PaymentModeId { get; set; }
        public decimal Amount { get; set; }
        public decimal Charge { get; set; } = 0;

        public long? OriginatorAccountId { get; set; }
        public long? BenficiaryAccountId { get; set; }

        public DateTime? DepositDate { get; set; }

        public string? RefNo1 { get; set; }
        public string? RefNo2 { get; set; }
        public string? Remarks { get; set; }
        public string? RecieptFileurl { get; set; }

        public int Status { get; set; } = 1;
    }
    public class CreatePayinRequestUploadRequest
    {
        public long UserMasterId { get; set; }

        public int PaymentChanelID { get; set; }

        public int PaymentModeId { get; set; }

        public decimal Amount { get; set; }

        public decimal Charge { get; set; }

        public long? OriginatorAccountId { get; set; }

        public long? BenficiaryAccountId { get; set; }

        public DateTime? DepositDate { get; set; }

        public string? RefNo1 { get; set; }

        public string? RefNo2 { get; set; }

        public string? Remarks { get; set; }

        // Receipt / payment proof uploaded from React
        public IFormFile? File { get; set; }

        public int Status { get; set; } = 1;
    }

    public class ApproveRejectPayinRequest
    {
        public long RequestID { get; set; }

        // APPROVE / REJECT
        public string Action { get; set; }

        public string? RejectedReason { get; set; }
    }
    public class SearchPayinRequest
    {
        public long? UserMasterId { get; set; }

        public string? UserName { get; set; }

        public int? Status { get; set; }

        public int? PaymentChanelID { get; set; }

        public int? PaymentModeId { get; set; }

        public long? RequestID { get; set; }

        public string? RefNo { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;
    }
}
