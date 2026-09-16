using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Masters
{
    public class CreatePlanRequest
    {
        public string? PlanName { get; set; }

        public int Status { get; set; }
    }


    public class UpdatePlanRequest
    {
        public int PlanID { get; set; }

        public string? PlanName { get; set; }

        public int Status { get; set; }
    }
    public class CreateCompanyTypeRequest
    {
        public string CompanyTypeName { get; set; }

        public int Status { get; set; }
    }


    public class UpdateCompanyTypeRequest
    {
        public int CompnayTypeId { get; set; }

        public string CompanyTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreateAgencyRequest
    {
        public string? AgencyCode { get; set; }

        public string? AgencyName { get; set; }

        public int Status { get; set; }
    }


    public class UpdateAgencyRequest
    {
        public int AgencyId { get; set; }

        public string? AgencyCode { get; set; }

        public string? AgencyName { get; set; }

        public int Status { get; set; }
    }
    public class CreateAddressTypeRequest
    {
        public string AddressTypeName { get; set; }

        public int Status { get; set; }
    }


    public class UpdateAddressTypeRequest
    {
        public int AddressTypeId { get; set; }

        public string AddressTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreateBankRequest
    {
        public string? BankName { get; set; }

        public int Status { get; set; }
    }
    public class UpdateBankRequest
    {
        public int BankID { get; set; }

        public string? BankName { get; set; }

        public int Status { get; set; }
    }
    public class CreateStateRequest
    {
        public long? StateFlagID { get; set; }

        public int CountryID { get; set; }

        public int RegionID { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public string Abbreviation { get; set; }

        public int Status { get; set; }
    }
    public class UpdateStateRequest
    {
        public int StateID { get; set; }

        public long? StateFlagID { get; set; }

        public int CountryID { get; set; }

        public int RegionID { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public string Abbreviation { get; set; }

        public int Status { get; set; }
    }
    public class CreateDistrictRequest
    {
        public int StateID { get; set; }

        public string DistrictCode { get; set; }

        public string? DistrictCodeOld { get; set; }

        public string DistrictName { get; set; }

        public int Status { get; set; }
    }


    public class UpdateDistrictRequest
    {
        public long DistrictID { get; set; }

        public int StateID { get; set; }

        public string DistrictCode { get; set; }

        public string? DistrictCodeOld { get; set; }

        public string DistrictName { get; set; }

        public int Status { get; set; }
    }
    public class CreateKycTypeRequest
    {
        public int UserTypeID { get; set; }

        public int? CompanyTypeId { get; set; }

        public string KycTypeName { get; set; }

        public int Status { get; set; }
    }
    public class UpdateKycTypeRequest
    {
        public int KycTypeID { get; set; }

        public int UserTypeID { get; set; }

        public int? CompanyTypeId { get; set; }

        public string KycTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreateUserTypeRequest
    {
        public string UserTypeName { get; set; }
        public int Status { get; set; }
    }

    public class UpdateUserTypeRequest
    {
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public int Status { get; set; }
    }
    public class CreateLedgerTypeRequest
    {
        public string? LedgerTypeName { get; set; }

        public int Status { get; set; }
    }


    public class UpdateLedgerTypeRequest
    {
        public int LedgerTypeId { get; set; }

        public string? LedgerTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreateServiceTypeRequestmdm
    {
        public int? AgencyId { get; set; }

        public string? ServiceTypeName { get; set; }

        public int Status { get; set; }
    }
    public class UpdateServiceTypeRequestmdm
    {
        public int ServiceTypeId { get; set; }

        public int? AgencyId { get; set; }

        public string? ServiceTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreatePaymentChanelRequest
    {
        public string PaymentChanelName { get; set; }

        public int Status { get; set; }
    }
    public class UpdatePaymentChanelRequest
    {
        public int PaymentChanelID { get; set; }

        public string PaymentChanelName { get; set; }

        public int Status { get; set; }
    }
    public class CreatePaymentModeRequest
    {
        public int? PaymentChanelID { get; set; }

        public string? PaymentModeName { get; set; }

        public int Status { get; set; }
    }


    public class UpdatePaymentModeRequest
    {
        public int PaymentModeID { get; set; }

        public int? PaymentChanelID { get; set; }

        public string? PaymentModeName { get; set; }

        public int Status { get; set; }
    }
    public class CreateServiceRequest
    {
        public int? ServiceTypeId { get; set; }

        public string? ServiceCode { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceAccountNo { get; set; }

        public string? ServcieIfsccode { get; set; }

        public string? ServiceAccName { get; set; }

        public string? ServiceMobileNo { get; set; }
    }
    public class UpdateServiceRequest
    {
        public int ServiceId { get; set; }

        public int? ServiceTypeId { get; set; }

        public string? ServiceCode { get; set; }

        public string? ServiceName { get; set; }

        public string? ServiceAccountNo { get; set; }

        public string? ServcieIfsccode { get; set; }

        public string? ServiceAccName { get; set; }

        public string? ServiceMobileNo { get; set; }
    }
    public class CreateChargeDeductionTypeRequest
    {
        public int ChargeDeductionId { get; set; }

        public string ChargeDeductionType { get; set; }

        public int Status { get; set; } = 1;
    }


    public class UpdateChargeDeductionTypeRequest
    {
        public int ChargeDeductionId { get; set; }

        public string ChargeDeductionType { get; set; }

        public int Status { get; set; }
    }
    public class CreateSlabTypeRequest
    {
        public int SlabTypId { get; set; }

        public string SlabTypeName { get; set; }

        public int Status { get; set; } = 1;
    }


    public class UpdateSlabTypeRequest
    {
        public int SlabTypId { get; set; }

        public string SlabTypeName { get; set; }

        public int Status { get; set; }
    }
    public class CreatePaymentAccountRequest
    {
        public int? BankID { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNo { get; set; }

        public string? Ifsccode { get; set; }

        public string? BranchName { get; set; }

        public string? Branchcode { get; set; }

        public string? Micrcode { get; set; }

        public string? BranchAddress { get; set; }

        public int Status { get; set; } = 1;

        public string? Remarks { get; set; }
    }
    public class UpdatePaymentAccountRequest
    {
        public int PaymentAccountID { get; set; }

        public int? BankID { get; set; }

        public string? AccountName { get; set; }

        public string? AccountNo { get; set; }

        public string? Ifsccode { get; set; }

        public string? BranchName { get; set; }

        public string? Branchcode { get; set; }

        public string? Micrcode { get; set; }

        public string? BranchAddress { get; set; }

        public int Status { get; set; }

        public string? Remarks { get; set; }
    }
    public class CreateCalculationTypeRequest
    {
        public int CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
        public int Status { get; set; } = 1;
    }

    public class UpdateCalculationTypeRequest
    {
        public int CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
        public int Status { get; set; }
    }
}
