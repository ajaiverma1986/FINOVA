

namespace FINOVA.DataModel.Masters
{
    public class CommissionDistributionRequest
    {
        public int? AgencyId { get; set; }
        public int? ServiceId { get; set; }
        public int? CalculationTypeId { get; set; }
        public double? amount { get; set; }
        public int? PlanId { get; set; }
    }
    public class TopupChargeRequest
    {
        public int? TopupChargeId { get; set; }
        public int? SlabTypeId { get; set; }
        public int? CalculationTypeId { get; set; }
        public double? Amount { get; set; }
    }
    public class TransactionslabRequest
    {
        public int? SlabId { get; set; }
        public int? PlanId { get; set; }
        public int? SlabType { get; set; }
        public int? CalculationType { get; set; }
        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public double? Amount { get; set; }
    }
    public class AddPaymentAccountMasterRequest
    {
        public int? BankID { get; set; }
        public string AccountName { get; set; }
        public string AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public string BranchName { get; set; }
        public string Branchcode { get; set; }
        public string Micrcode { get; set; }
        public string BranchAddress { get; set; }
        public long CreatedBy { get; set; }

    }
    public class CreateapplicationRequest
    {
        public string ApplicationName { get; set; }
        public string ApplicationDescription { get; set; }

    }
    public class ChangePaymentAccStatusRequest
    {
        public int? PaymentAccountID { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
    }
    public class GetServicePolicyRequest
    {
        public int ServiceId { get; set; }
        public int Agencyid { get; set; }
        public int PolicyId { get; set; }
        public string PolicyKey { get; set; }
    }
    public class AddTxnslabRequest
    {
        public int PlanId { get; set; }
        public int AgencyID { get; set; }
        public int ServiceID { get; set; }
        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public int SlabType { get; set; }
        public int CalculationType { get; set; }
        public decimal CalculationValue { get; set; }

    }
    public class CreateTopupChargeRequest
    {
        public decimal? FromAmount { get; set; }

        public decimal? Toamount { get; set; }

        public int? SlabTypeId { get; set; }

        public int? CalculationTypeId { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; } = 1;
    }


    public class UpdateTopupChargeRequest
    {
        public int TopupChargeId { get; set; }

        public decimal? FromAmount { get; set; }

        public decimal? Toamount { get; set; }

        public int? SlabTypeId { get; set; }

        public int? CalculationTypeId { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; }
    }
    public class CreateCommissionDistributionRequest
    {
        public int AgencyId { get; set; }

        public int ServiceId { get; set; }

        public int? PlanId { get; set; }

        public decimal? FromAmount { get; set; }

        public decimal? Toamount { get; set; }

        public int? CalculationTypeId { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; } = 1;
    }


    public class UpdateCommissionDistributionRequest
    {
        public long MarginConfigrationID { get; set; }

        public int AgencyId { get; set; }

        public int ServiceId { get; set; }

        public int? PlanId { get; set; }

        public decimal? FromAmount { get; set; }

        public decimal? Toamount { get; set; }

        public int? CalculationTypeId { get; set; }

        public decimal? CalculationValue { get; set; }

        public int Status { get; set; }
    }
    public class CreateTransactionSlabRequest
    {
        public int? PlanId { get; set; }
        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public decimal? FromAmount { get; set; }
        public decimal? ToAmount { get; set; }
        public int? SlabType { get; set; }
        public int? CalculationType { get; set; }
        public decimal? CalculationValue { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateTransactionSlabRequest
    {
        public long SlabId { get; set; }
        public int? PlanId { get; set; }
        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public decimal? FromAmount { get; set; }
        public decimal? ToAmount { get; set; }
        public int? SlabType { get; set; }
        public int? CalculationType { get; set; }
        public decimal? CalculationValue { get; set; }
        public int Status { get; set; }
    }
    public class CreateCodePrefixRequest
    {
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public string CodePrefix { get; set; }
        public string CodeLngth { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateCodePrefixRequest
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int ApplicationId { get; set; }
        public string CodePrefix { get; set; }
        public string CodeLngth { get; set; }
        public int Status { get; set; }
    }
    public class GetCodePrefixRequest
    {
        public int? Id { get; set; }
        public int? OrganizationId { get; set; }
        public int? ApplicationId { get; set; }
        public string? CodePrefix { get; set; }
        public int? Status { get; set; }
    }
    public class CreateServiceAgencyChargeRequest
    {
        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public int? SlabTypeId { get; set; }
        public int? CalculationTypeId { get; set; }

        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public decimal CalculationValue { get; set; }

        public int Status { get; set; } = 1;
    }

    public class UpdateServiceAgencyChargeRequest
    {
        public long MappingId { get; set; }

        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public int? SlabTypeId { get; set; }
        public int? CalculationTypeId { get; set; }

        public decimal FromAmount { get; set; }
        public decimal ToAmount { get; set; }
        public decimal CalculationValue { get; set; }

        public int Status { get; set; }
    }

    public class GetServiceAgencyChargeRequest
    {
        public int? AgencyID { get; set; }
        public int? ServiceID { get; set; }
        public int? SlabTypeId { get; set; }
        public int? CalculationTypeId { get; set; }
        public int? Status { get; set; }
    }


    public class CreateTdsMasterRequest
    {
        public bool IsPanAvailable { get; set; }

        public decimal TdsRate { get; set; }

        public string? Remarks { get; set; }

        public int Stratus { get; set; } = 1;
    }


    public class UpdateTdsMasterRequest
    {
        public int TdsRateId { get; set; }

        public bool IsPanAvailable { get; set; }

        public decimal TdsRate { get; set; }

        public string? Remarks { get; set; }

        public int Stratus { get; set; }
    }


    public class GetTdsMasterRequest
    {
        public bool? IsPanAvailable { get; set; }

        public int? Stratus { get; set; }
    }
    public class CreateCommissionDistributionSetupRequest
    {
        public int AgencyId { get; set; }
        public int ServiceId { get; set; }
        public int PlanId { get; set; }
        public int CalculationTypeId { get; set; }

        public decimal AgancyValue { get; set; }
        public decimal OrgValue { get; set; }
        public decimal MdsValue { get; set; }
        public decimal DSValue { get; set; }
        public decimal AgentValue { get; set; }

        public int Status { get; set; } = 1;
    }


    public class UpdateCommissionDistributionSetupRequest
    {
        public long DistributionId { get; set; }

        public int AgencyId { get; set; }
        public int ServiceId { get; set; }
        public int PlanId { get; set; }
        public int CalculationTypeId { get; set; }

        public decimal AgancyValue { get; set; }
        public decimal OrgValue { get; set; }
        public decimal MdsValue { get; set; }
        public decimal DSValue { get; set; }
        public decimal AgentValue { get; set; }

        public int Status { get; set; }
    }


    public class GetCommissionDistributionSetupRequest
    {
        public int? AgencyId { get; set; }
        public int? ServiceId { get; set; }
        public int? PlanId { get; set; }
        public int? CalculationTypeId { get; set; }
    }
}
