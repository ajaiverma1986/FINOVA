using FINOVA.DataModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Masters
{
    public class GetPlanResponse
    {
        public int PlanID { get; set; }

        public string? PlanName { get; set; }

        public int? Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetCompanyTypeResponse
    {
        public int CompnayTypeId { get; set; }

        public string CompanyTypeName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
    public class GetAgencyResponse
    {
        public int AgencyId { get; set; }

        public string? AgencyCode { get; set; }

        public string? AgencyName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetAddressTypeResponse
    {
        public int AddressTypeId { get; set; }

        public string AddressTypeName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
    public class GetBankResponse
    {
        public int BankID { get; set; }

        public string? BankName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetStateResponse
    {
        public int StateID { get; set; }

        public Guid StateUID { get; set; }

        public long? StateFlagID { get; set; }

        public int CountryID { get; set; }

        public string? CountryName { get; set; }

        public int RegionID { get; set; }

        public string? RegionName { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public string Abbreviation { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetDistrictResponse
    {
        public long DistrictID { get; set; }

        public Guid DistrictUID { get; set; }

        public int StateID { get; set; }

        public string? StateName { get; set; }

        public string DistrictCode { get; set; }

        public string? DistrictCodeOld { get; set; }

        public string DistrictName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetKycTypeResponse
    {
        public int KycTypeID { get; set; }

        public int UserTypeID { get; set; }

        public int? CompanyTypeId { get; set; }

        public string KycTypeName { get; set; }
        public string UserTypeName { get; set; }
        public string CompanyTypeName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }

    public class ServiceListResponse
    {
        public int ServiceId { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string ServiceAccountNo { get; set; }
        public string ServcieIfsccode { get; set; }
        public string ServiceAccName { get; set; }
        public string ServiceMobileNo { get; set; }

    }
   
    public class GenderResponse
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
    public class MaritalStatusResponse
    {
        public int MaritalStatusID { get; set; }
        public string MaritalStatusName { get; set; }
    }
    public class GetUserTypeResponse
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class GetLedgerTypeResponse
    {
        public int LedgerTypeId { get; set; }

        public string? LedgerTypeName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class BankListResponse
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
    public class PincodeDataResponse
    {
        public int PincodeDataId { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public string AreaName { get; set; }
        public string Pincode { get; set; }
        public string SubDistrictName { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }

    }
    public class GetServiceTypeResponsemdm
    {
        public int ServiceTypeId { get; set; }

        public int? AgencyId { get; set; }

        public string? ServiceTypeName { get; set; }
        public string? AgencyName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetPaymentChanelResponse
    {
        public int PaymentChanelID { get; set; }

        public string PaymentChanelName { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
    public class GetPaymentModeResponse
    {
        public int PaymentModeID { get; set; }

        public int? PaymentChanelID { get; set; }

        public string? PaymentChanelName { get; set; }

        public string? PaymentModeName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetServiceResponse
    {
        public int ServiceId { get; set; }

        public int? ServiceTypeId { get; set; }

        public string? ServiceTypeName { get; set; }

        public string? ServiceCode { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceAccountNo { get; set; }

        public string? ServcieIfsccode { get; set; }

        public string? ServiceAccName { get; set; }

        public string? ServiceMobileNo { get; set; }
    }
    public class PincodeDataRequest : ListRequest
    {
        public string Pincode { get; set; }

    }
    public class GetChargeDeductionTypeResponse
    {
        public int ChargeDeductionId { get; set; }

        public string ChargeDeductionType { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetSlabTypeResponse
    {
        public int SlabTypId { get; set; }

        public string SlabTypeName { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
    }
    public class GetPaymentAccountResponse
    {
        public int PaymentAccountID { get; set; }

        public int? BankID { get; set; }

        public string? BankName { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNo { get; set; }

        public string? Ifsccode { get; set; }

        public string? BranchName { get; set; }

        public string? Branchcode { get; set; }

        public string? Micrcode { get; set; }

        public string? BranchAddress { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }

        public string? Remarks { get; set; }
    }
    public class GetCalculationTypeResponse
    {
        public int CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
        public int Status { get; set; }
        public string? StatusName { get; set; }
    }
}
