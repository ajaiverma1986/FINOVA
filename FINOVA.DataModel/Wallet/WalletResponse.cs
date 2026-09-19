using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Wallet
{
    public class GetCompanyAccountResponse
    {
        public long CompanyAccountId { get; set; }

        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }

        public int BankId { get; set; }
        public string? BankName { get; set; }

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
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetPayinRequestResponse
    {
        public long RequestID { get; set; }
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

        public string? RecieptFileurl { get; set; }
        public string? RejectedReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
    public class GetPayinRequestResponseall
    {
        public long RequestID { get; set; }
        public long UserMasterId { get; set; }

        public string? UserName { get; set; }

        public int PaymentChanelID { get; set; }
        public string? PaymentChanelName { get; set; }

        public int PaymentModeId { get; set; }
        public string? PaymentModeName { get; set; }

        public decimal Amount { get; set; }
        public decimal Charge { get; set; }

        public long? OriginatorAccountId { get; set; }

        public string? UserAccountName { get; set; }
        public string? UserAccountNo { get; set; }
        public string? UserIfsccode { get; set; }

        public long? BenficiaryAccountId { get; set; }

        public string? CompanyAccountName { get; set; }
        public string? CompanyAccountNo { get; set; }
        public string? CompanyIfsccode { get; set; }

        public DateTime? DepositDate { get; set; }

        public string? RefNo1 { get; set; }
        public string? RefNo2 { get; set; }

        public string? Remarks { get; set; }
        public string? RecieptFileurl { get; set; }
        public string? RejectedReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedByID { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedByID { get; set; }
        public string? UpdatedBy { get; set; }
    }
    public class PagingInfo
    {
        public long TotalRecords { get; set; }
        public int TotalPages { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
    public class SearchPayinResponsemain
    {
        public List<GetPayinRequestResponseall> Records { get; set; }
            = new List<GetPayinRequestResponseall>();

        public PagingInfo Paging { get; set; }
            = new PagingInfo();
    }
}
