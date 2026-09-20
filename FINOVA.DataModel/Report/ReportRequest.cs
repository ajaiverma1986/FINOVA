using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Report
{
    public class TransactionReportRequest
    {
        public long? OrganizationId { get; set; }
        public long? UserMasterId { get; set; }
        public string? UserName { get; set; }

        public long? TransactionId { get; set; }
        public string? TransactionCode { get; set; }

        public int? ServiceId { get; set; }
        public int? AgencyId { get; set; }

        public string? PartnerTxnId { get; set; }
        public string? PartnerRetailorId { get; set; }

        public string? RefNo { get; set; }

        public string? TxnType { get; set; }
        public int? Status { get; set; }
        public string? TxnPlateform { get; set; }

        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string SortColumn { get; set; } = "TransactionId";
        public string SortDirection { get; set; } = "DESC";
    }
    public class AdminDashboardRequest
    {
        // NULL = All Users
        // Value = Selected User
        public long? UserMasterId { get; set; }

        public DateTime? ReportDate { get; set; }
    }
    public class UserDetailsReportRequest
    {
        // User filters
        public long? UserMasterId { get; set; }
        public long? ParentId { get; set; }
        public int? OrganizationId { get; set; }
        public int? UserTypeId { get; set; }

        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? MobileNo { get; set; }

        public byte? GenderId { get; set; }
        public byte? Status { get; set; }

        public bool? IsLocked { get; set; }
        public bool? IsPasswordExpired { get; set; }

        // Other details
        public string? PANCard { get; set; }
        public string? AadharCard { get; set; }
        public string? GSTNo { get; set; }

        // Configuration
        public int? PlanId { get; set; }

        // Balance
        public decimal? MinAvailableLimit { get; set; }
        public decimal? MaxAvailableLimit { get; set; }

        // Registration date
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // Completion filters
        public bool? HasKYC { get; set; }
        public bool? HasBankAccount { get; set; }
        public bool? HasAddress { get; set; }

        // Paging
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        // Sorting
        public string SortColumn { get; set; } = "CreatedOn";
        public string SortDirection { get; set; } = "DESC";
    }
}
