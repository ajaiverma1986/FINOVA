using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Masters
{
    public class CalculationMasterResponse
    {
        public int CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class ChargedeductionTypeListResponse
    {
        public int ChargeDeductionId { get; set; }
        public string ChargeDeductionType { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class PlanMasterListDataResponse
    {
        public int PlanId { get; set; }
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class SlabTypeListResponse
    {
        public int SlabTypId { get; set; }
        public string SlabTypeName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class CommissionDistributionResponse
    {
        public int MarginConfigrationID { get; set; }
        public int AgencyId { get; set; }
        public int ServiceId { get; set; }
        public int PlanId { get; set; }
        public decimal FromAmount { get; set; }
        public decimal Toamount { get; set; }
        public int CalculationTypeId { get; set; }
        public decimal CalculationValue { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string AgencyName { get; set; }
        public string ServiceName { get; set; }
        public string PlanName { get; set; }
        public string CalculationTypeName { get; set; }

    }

    public class TopupChargeResponse
    {
        public int TopupChargeId { get; set; }

        public decimal FromAmount { get; set; }
        public decimal Toamount { get; set; }
        public int SlabTypeId { get; set; }
        public int CalculationTypeId { get; set; }
        public decimal CalculationValue { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string SlabTypeName { get; set; }
        public string CalculationTypeName { get; set; }
    }
    public class TransactionslabResponse
    {
        public int SlabId { get; set; }
        public int PlanId { get; set; }
        public int AgencyID { get; set; }
        public int ServiceID { get; set; }
        public int SlabType { get; set; }
        public int CalculationType { get; set; }
        public decimal FromAmount { get; set; }
        public decimal Toamount { get; set; }
        public decimal CalculationValue { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string SlabTypeName { get; set; }
        public string CalculationTypeName { get; set; }
        public string AgencyName { get; set; }
        public string ServiceName { get; set; }
        public string PlanName { get; set; }
    }

    public class PaymentAccountsListResponse
    {
        public int PaymentAccountID { get; set; }
        public int BankID { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public string BranchName { get; set; }
        public string Branchcode { get; set; }
        public string Micrcode { get; set; }
        public string BranchAddress { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string BankName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }

    public class GetservicePolicyResponse
    {
        public int SysPolicyId { get; set; }
        public string PolicyKey { get; set; }
        public string PolicyValue { get; set; }

    }
    public class GetTopupChargeResponse
    {
        public int TopupChargeId { get; set; }

        public decimal? FromAmount { get; set; }

        public decimal? Toamount { get; set; }

        public int? SlabTypeId { get; set; }

        public string? SlabTypeName { get; set; }

        public int? CalculationTypeId { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? CreatedBy { get; set; }
    }
    public class GetCommissionDistributionResponse
    {
        public long MarginConfigrationID { get; set; }

        public int AgencyId { get; set; }
        public string? AgencyName { get; set; }

        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }

        public int? PlanId { get; set; }
        public string? PlanName { get; set; }

        public decimal? FromAmount { get; set; }
        public decimal? Toamount { get; set; }

        public int? CalculationTypeId { get; set; }
        public string? CalculationTypeName { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
    }
    public class GetTransactionSlabResponse
    {
        public long SlabId { get; set; }

        public int? PlanId { get; set; }
        public string? PlanName { get; set; }

        public int? AgencyID { get; set; }
        public string? AgencyName { get; set; }

        public int? ServiceID { get; set; }
        public string? ServiceName { get; set; }

        public decimal? FromAmount { get; set; }
        public decimal? ToAmount { get; set; }

        public int? SlabType { get; set; }
        public string? SlabTypeName { get; set; }

        public int? CalculationType { get; set; }
        public string? CalculationTypeName { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
    }
    
    public class GetCodePrefixResponse
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public string? CodePrefix { get; set; }
        public string? CodeLngth { get; set; }
        public int Status { get; set; }
        public string? StatusName { get; set; }
    }

    public class UpdateCodePrefixResponse
    {
        public int Id { get; set; }
        public bool IsUpdated { get; set; }
        public string? Message { get; set; }
    }
    public class DeleteCodePrefixResponse
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string? Message { get; set; }
    }
    public class GetServiceAgencyChargeResponse
    {
        public long MappingId { get; set; }

        // Agency
        public int? AgencyID { get; set; }
        public string? AgencyName { get; set; }

        // Service
        public int? ServiceID { get; set; }
        public string? ServiceName { get; set; }

        // Slab / Service Type
        public int? SlabTypeId { get; set; }
        public string? ServiceTypeName { get; set; }

        // Calculation Type
        public int? CalculationTypeId { get; set; }
        public string? CalculationTypeName { get; set; }
        public string? CreatedByName { get; set; }
        public string? UpdatedByName { get; set; }

        // Amount / Calculation
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public decimal CalculationValue { get; set; }

        // Status
        public int Status { get; set; }
        public string? StatusName { get; set; }

        // Audit
        public DateTime? CreratedOn { get; set; }
        public long CreratedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }

    public class UpdateServiceAgencyChargeResponse
    {
        public long MappingId { get; set; }
        public bool IsUpdated { get; set; }
        public string? Message { get; set; }
    }

    public class DeleteServiceAgencyChargeResponse
    {
        public long MappingId { get; set; }
        public bool IsDeleted { get; set; }
        public string? Message { get; set; }
    }
    public class GetTdsMasterResponse
    {
        public int TdsRateId { get; set; }

        public bool IsPanAvailable { get; set; }

        public decimal TdsRate { get; set; }

        public string? Remarks { get; set; }

        public int Stratus { get; set; }

        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public string? CreatedByName { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public string? UpdatedByName { get; set; }
    }


    public class UpdateTdsMasterResponse
    {
        public int TdsRateId { get; set; }

        public bool IsUpdated { get; set; }

        public string? Message { get; set; }
    }


    public class DeleteTdsMasterResponse
    {
        public int TdsRateId { get; set; }

        public bool IsDeleted { get; set; }

        public string? Message { get; set; }
    }
    public class GetCommissionDistributionSetupResponse
    {
        public long DistributionId { get; set; }

        public int AgencyId { get; set; }
        public string? AgencyName { get; set; }

        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }

        public int PlanId { get; set; }
        public string? PlanName { get; set; }

        public int CalculationTypeId { get; set; }
        public string? CalculationTypeName { get; set; }

        public decimal AgancyValue { get; set; }
        public decimal OrgValue { get; set; }
        public decimal MdsValue { get; set; }
        public decimal DSValue { get; set; }
        public decimal AgentValue { get; set; }

        public int Status { get; set; }
        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public string? CreatedByName { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
        public string? UpdatedByName { get; set; }
    }


    public class UpdateCommissionDistributionSetupResponse
    {
        public long DistributionId { get; set; }

        public bool IsUpdated { get; set; }

        public string? Message { get; set; }
    }


    public class DeleteCommissionDistributionSetupResponse
    {
        public long DistributionId { get; set; }

        public bool IsDeleted { get; set; }

        public string? Message { get; set; }
    }

}
