using FINOVA.DataModel.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Report
{
    public class TransactionReportResponse
    {
        public List<TransactionReportRow> Records { get; set; }
            = new List<TransactionReportRow>();

        public PagingInfo Paging { get; set; }
            = new PagingInfo();
    }

    public class TransactionReportRow
    {
        public long TransactionId { get; set; }
        public string? TransactionCode { get; set; }

        public long? OrganizationId { get; set; }

        public long? UserMasterId { get; set; }
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? ServiceId { get; set; }
        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }

        public int? AgencyId { get; set; }
        public string? AgencyCode { get; set; }
        public string? AgencyName { get; set; }

        public string? PartnerTxnId { get; set; }
        public string? PartnerRetailorId { get; set; }

        public string? RefNo { get; set; }
        public string? RelatedReference { get; set; }

        public string? Description { get; set; }
        public string? BankTxnDatetime { get; set; }

        public string? TxnType { get; set; }

        public decimal Amount { get; set; }
        public decimal TxnFee { get; set; }
        public decimal MarginComm { get; set; }

        public string? FailureReason { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public string? TxnPlateform { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }

        public DateTime? CanceledDate { get; set; }
        public long? CanceledBy { get; set; }
        public string? CancelReason { get; set; }
    }
    public class UserDashboardResponse
    {
        public DashboardSummary Summary { get; set; }
            = new DashboardSummary();

        public List<DashboardTrend> TransactionTrend { get; set; }
            = new List<DashboardTrend>();

        public List<DashboardTopTransaction> TopTransactions { get; set; }
            = new List<DashboardTopTransaction>();

        public List<DashboardDaybook> Daybook { get; set; }
            = new List<DashboardDaybook>();

        public List<DashboardStatusDistribution> StatusDistribution { get; set; }
            = new List<DashboardStatusDistribution>();

        public List<DashboardServicePerformance> ServicePerformance { get; set; }
            = new List<DashboardServicePerformance>();

        public List<DashboardPlatformDistribution> PlatformDistribution { get; set; }
            = new List<DashboardPlatformDistribution>();
    }
    public class DashboardSummary
    {
        public DateTime ReportDate { get; set; }

        public long TotalTransactions { get; set; }

        public decimal? TransactionAmount { get; set; }

        public decimal? TotalCommissionEarned { get; set; }

        public decimal? TotalTransactionFee { get; set; }

        public decimal? AverageTransactionAmount { get; set; }
    }
    public class DashboardTrend
    {
        public DateTime ReportDate { get; set; }

        public long? TransactionCount { get; set; }

        public decimal? TransactionAmount { get; set; }

        public decimal? CommissionAmount { get; set; }
    }
    public class DashboardTopTransaction
    {
        public long TransactionId { get; set; }

        public string? TransactionCode { get; set; }

        public long? UserMasterId { get; set; }

        public string? UserName { get; set; }

        public int? ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public int? AgencyId { get; set; }

        public string? AgencyName { get; set; }

        public string? PartnerTxnId { get; set; }

        public string? TxnType { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TxnFee { get; set; }

        public decimal? MarginComm { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public string? TxnPlateform { get; set; }

        public DateTime CreatedOn { get; set; }
    }
    public class DashboardDaybook
    {
        public int? ServiceId { get; set; }

        public string? ServiceCode { get; set; }

        public string? ServiceName { get; set; }

        public long? TransactionCount { get; set; }

        public decimal? TransactionAmount { get; set; }

        public decimal? TransactionFee { get; set; }

        public decimal? CommissionAmount { get; set; }

        public decimal? TotalDebitAmount { get; set; }
    }
    public class DashboardStatusDistribution
    {
        public int Status { get; set; }

        public string? StatusName { get; set; }

        public long? TransactionCount { get; set; }

        public decimal? TransactionAmount { get; set; }
    }
    public class DashboardServicePerformance
    {
        public int? ServiceId { get; set; }

        public string? ServiceName { get; set; }

        public long? TransactionCount { get; set; }

        public decimal? TransactionAmount { get; set; }

        public decimal? CommissionAmount { get; set; }
    }
    public class DashboardPlatformDistribution
    {
        public string? TxnPlateform { get; set; }

        public long? TransactionCount { get; set; }

        public decimal? TransactionAmount { get; set; }
    }
    public class UserDetailsReportResponse
    {
        public List<UserDetailsReportRow> Records { get; set; }
            = new List<UserDetailsReportRow>();

        public PagingInfo Paging { get; set; }
            = new PagingInfo();
    }
    public class UserDetailsReportRow
    {
        // ========================================================
        // USER MASTER
        // ========================================================

        public long UserMasterID { get; set; }

        public long? ParentId { get; set; }

        public string? ParentUserName { get; set; }
        public string? ParentDisplayName { get; set; }

        public int? UserTypeId { get; set; }
        public int OrganizationID { get; set; }

        public string? DomainUserName { get; set; }
        public string? UserName { get; set; }

        public string? Title { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }

        public byte GenderID { get; set; }

        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }

        public bool IsPasswordExpired { get; set; }
        public bool IsLocked { get; set; }

        public DateTimeOffset? LockedTill { get; set; }

        public long UserId { get; set; }

        public string? UserRemarkReason { get; set; }

        public byte Status { get; set; }
        public string? StatusName { get; set; }


        // ========================================================
        // USER DETAILS / BALANCE
        // ========================================================

        public long? UserDetailId { get; set; }

        public decimal AvailableLimit { get; set; }
        public decimal ThresoldLimit { get; set; }

        public int? UserDetailStatus { get; set; }

        public string? UserDetailRemarkReason { get; set; }


        // ========================================================
        // CONFIGURATION
        // ========================================================

        public long? ConfigurationId { get; set; }

        public decimal MinTxn { get; set; }
        public decimal MaxTxn { get; set; }

        public int? ChargeTypeOn { get; set; }

        public int? PlanId { get; set; }

        public decimal MaxPayinAmount { get; set; }

        public int? MaxNoofcountPayin { get; set; }

        public int? SameAmountPayinAllowed { get; set; }


        // ========================================================
        // OTHER DETAILS
        // ========================================================

        public long? OtherDetailId { get; set; }

        public string? Pancard { get; set; }
        public string? AadharCard { get; set; }
        public string? GSTNo { get; set; }

        public int? OtherDetailStatus { get; set; }


        // ========================================================
        // KYC SUMMARY
        // ========================================================

        public long KYCCount { get; set; }
        public long ActiveKYCCount { get; set; }

        public bool HasKYC { get; set; }


        // ========================================================
        // BANK ACCOUNT SUMMARY
        // ========================================================

        public long BankAccountCount { get; set; }
        public long ActiveBankAccountCount { get; set; }

        public bool HasBankAccount { get; set; }


        // ========================================================
        // ADDRESS SUMMARY
        // ========================================================

        public long AddressCount { get; set; }
        public long ActiveAddressCount { get; set; }

        public bool HasAddress { get; set; }


        // ========================================================
        // AUDIT
        // ========================================================

        public DateTimeOffset CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public string? CreatedByName { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public string? UpdatedByName { get; set; }
    }
}
