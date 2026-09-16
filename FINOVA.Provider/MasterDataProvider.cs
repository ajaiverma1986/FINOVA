using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;

namespace FINOVA.Provider
{
    public class MasterDataProvider : BaseProvider
    {
        public readonly MasterDataRepository _repository = null;
        public MasterDataProvider()
        {
            _repository = new MasterDataRepository();
        }

        public async Task<SimpleResponse> GetGender()
        {
            SimpleResponse response = new SimpleResponse();
            response = await _repository.GetGender();
            return response;
        }
        public async Task<SimpleResponse> GetMaritalStatus()
        {
            SimpleResponse response = new SimpleResponse();
            response = await _repository.GetMaritalStatus();
            return response;
        }

        public async Task<SimpleResponse> GetDataByPincode(string Pincode)
        {
            SimpleResponse response = new SimpleResponse();
            response = await _repository.GetDataByPincode(Pincode);
            return response;
        }
        public async Task<ListResponse> GetDataByPincodeList(PincodeDataRequest request)
        {
            ListResponse response = new ListResponse();
            response = await _repository.GetDataByPincodeList(request);
            return response;
        }


        // ============================================================
        // PLAN MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreatePlan(
            CreatePlanRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.PlanName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePlan(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PLAN MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePlan(
            UpdatePlanRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.PlanID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.PlanName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdatePlan(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PLAN MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeletePlan(
            int planID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (planID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeletePlan(
                    planID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPlanByID(
            int planID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (planID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetPlanByID(
                    planID,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllPlans(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllPlans(
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActivePlans(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActivePlans(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // COMPANY TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateCompanyType(
            CreateCompanyTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.CompanyTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateCompanyType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateCompanyType(
            UpdateCompanyTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CompnayTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.CompanyTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateCompanyType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteCompanyType(
            int compnayTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (compnayTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteCompanyType(
                    compnayTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetCompanyTypeByID(
            int compnayTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (compnayTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetCompanyTypeByID(
                    compnayTypeId,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllCompanyTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllCompanyTypes(
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveCompanyTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActiveCompanyTypes(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // AGENCY MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateAgency(
            CreateAgencyRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AgencyCode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AgencyName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateAgency(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // AGENCY MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateAgency(
            UpdateAgencyRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.AgencyId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AgencyCode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AgencyName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateAgency(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // AGENCY MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteAgency(
            int agencyId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteAgency(
                    agencyId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetAgencyByID(
            int agencyId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            var result =
                await _repository.GetAgencyByID(
                    agencyId,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllAgencies(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetAllAgencies(
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveAgencies(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var result =
                await _repository.GetActiveAgencies(
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // ADDRESS TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateAddressType(
            CreateAddressTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AddressTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateAddressType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateAddressType(
            UpdateAddressTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.AddressTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.AddressTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateAddressType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteAddressType(
            int addressTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (addressTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteAddressType(
                    addressTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetAddressTypeByID(
            int addressTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (addressTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetAddressTypeByID(
                    addressTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllAddressTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllAddressTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveAddressTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveAddressTypes(
                    serviceUser);

            return response;
        }
        // ============================================================
        // BANK MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateBank(
            CreateBankRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.BankName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateBank(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // BANK MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateBank(
            UpdateBankRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.BankID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.BankName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateBank(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // BANK MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteBank(
            int bankID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (bankID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteBank(
                    bankID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // BANK MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetBankByID(
            int bankID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (bankID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetBankByID(
                    bankID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // BANK MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllBanks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllBanks(
                    serviceUser);

            return response;
        }


        // ============================================================
        // BANK MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveBanks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveBanks(
                    serviceUser);

            return response;
        }
        // ============================================================
        // STATE - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateState(
            CreateStateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CountryID <= 0 ||
                request.RegionID <= 0 ||
                string.IsNullOrWhiteSpace(request.StateCode) ||
                string.IsNullOrWhiteSpace(request.StateName) ||
                string.IsNullOrWhiteSpace(request.Abbreviation))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateState(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateState(
            UpdateStateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.StateID <= 0 ||
                request.CountryID <= 0 ||
                request.RegionID <= 0 ||
                string.IsNullOrWhiteSpace(request.StateCode) ||
                string.IsNullOrWhiteSpace(request.StateName) ||
                string.IsNullOrWhiteSpace(request.Abbreviation))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateState(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteState(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (stateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteState(
                    stateID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetStateByID(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (stateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetStateByID(
                    stateID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllStates(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllStates(
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveStates(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveStates(
                    serviceUser);

            return response;
        }


        // ============================================================
        // STATE - GET BY COUNTRY ID
        // ============================================================
        public async Task<SimpleResponse> GetStatesByCountryID(
            int countryID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (countryID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetStatesByCountryID(
                    countryID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // DISTRICT - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateDistrict(
            CreateDistrictRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.StateID <= 0 ||
                string.IsNullOrWhiteSpace(request.DistrictCode) ||
                string.IsNullOrWhiteSpace(request.DistrictName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateDistrict(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateDistrict(
            UpdateDistrictRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.DistrictID <= 0 ||
                request.StateID <= 0 ||
                string.IsNullOrWhiteSpace(request.DistrictCode) ||
                string.IsNullOrWhiteSpace(request.DistrictName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateDistrict(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteDistrict(
            long districtID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (districtID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteDistrict(
                    districtID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetDistrictByID(
            long districtID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (districtID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetDistrictByID(
                    districtID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllDistricts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllDistricts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveDistricts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveDistricts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // DISTRICT - GET BY STATE ID
        // ============================================================
        public async Task<SimpleResponse> GetDistrictsByStateID(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (stateID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetDistrictsByStateID(
                    stateID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // KYC TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateKycType(
            CreateKycTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserTypeID <= 0 ||
                string.IsNullOrWhiteSpace(request.KycTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateKycType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateKycType(
            UpdateKycTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.KycTypeID <= 0 ||
                request.UserTypeID <= 0 ||
                string.IsNullOrWhiteSpace(request.KycTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateKycType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteKycType(
            int kycTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (kycTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteKycType(
                    kycTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetKycTypeByID(
            int kycTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (kycTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetKycTypeByID(
                    kycTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllKycTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllKycTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveKycTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveKycTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY USER TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetKycTypesByUserTypeID(
            int userTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetKycTypesByUserTypeID(
                    userTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY USER TYPE + COMPANY TYPE
        // ============================================================
        public async Task<SimpleResponse> GetKycTypesByUserAndCompanyType(
            int userTypeID,
            int? companyTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // CompanyTypeId is nullable, therefore no validation is
            // required when it is null.
            if (companyTypeId.HasValue && companyTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetKycTypesByUserAndCompanyType(
                    userTypeID,
                    companyTypeId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // USER TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateUserType(
            CreateUserTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserType(
            UpdateUserTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.UserTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteUserType(
            int userTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserType(
                    userTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserTypeByID(
            int userTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserTypeByID(
                    userTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllUserTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveUserTypes(
                    serviceUser);

            return response;
        }

        // ============================================================
        // LEDGER TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateLedgerType(
            CreateLedgerTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateLedgerType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateLedgerType(
            UpdateLedgerTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.LedgerTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateLedgerType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteLedgerType(
            int ledgerTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (ledgerTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteLedgerType(
                    ledgerTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetLedgerTypeByID(
            int ledgerTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (ledgerTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetLedgerTypeByID(
                    ledgerTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllLedgerTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllLedgerTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveLedgerTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveLedgerTypes(
                    serviceUser);

            return response;
        }

        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateServiceType(
            CreateServiceTypeRequestmdm request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateServiceType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateServiceType(
            UpdateServiceTypeRequestmdm request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateServiceType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteServiceType(
            int serviceTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteServiceType(
                    serviceTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetServiceTypeByID(
            int serviceTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetServiceTypeByID(
                    serviceTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllServiceTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveServiceTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY AGENCY ID
        // ============================================================
        public async Task<SimpleResponse> GetServiceTypesByAgencyID(
            int agencyId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetServiceTypesByAgencyID(
                    agencyId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // PAYMENT CHANEL MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreatePaymentChanel(
            CreatePaymentChanelRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.PaymentChanelName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePaymentChanel(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentChanel(
            UpdatePaymentChanelRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.PaymentChanelID <= 0 ||
                string.IsNullOrWhiteSpace(request.PaymentChanelName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdatePaymentChanel(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeletePaymentChanel(
            int paymentChanelID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentChanelID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeletePaymentChanel(
                    paymentChanelID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPaymentChanelByID(
            int paymentChanelID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentChanelID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPaymentChanelByID(
                    paymentChanelID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllPaymentChanels(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllPaymentChanels(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActivePaymentChanels(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActivePaymentChanels(
                    serviceUser);

            return response;
        }
        // ============================================================
        // PAYMENT MODE MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreatePaymentMode(
            CreatePaymentModeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePaymentMode(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentMode(
            UpdatePaymentModeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.PaymentModeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdatePaymentMode(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeletePaymentMode(
            int paymentModeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentModeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeletePaymentMode(
                    paymentModeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPaymentModeByID(
            int paymentModeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentModeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPaymentModeByID(
                    paymentModeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllPaymentModes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllPaymentModes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActivePaymentModes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActivePaymentModes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY PAYMENT CHANEL ID
        // ============================================================
        public async Task<SimpleResponse> GetPaymentModesByPaymentChanelID(
            int paymentChanelID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentChanelID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPaymentModesByPaymentChanelID(
                    paymentChanelID,
                    serviceUser);

            return response;
        }
    // ============================================================
// SERVICE MASTER - CREATE
// ============================================================
public async Task<SimpleResponse> CreateService(
    CreateServiceRequest request,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateService(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateService(
            UpdateServiceRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateService(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteService(
            int serviceId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteService(
                    serviceId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetServiceByID(
            int serviceId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetServiceByID(
                    serviceId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllServices(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllServices(
                    serviceUser);

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET BY SERVICE TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetServicesByServiceTypeID(
            int serviceTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetServicesByServiceTypeID(
                    serviceTypeId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CHARGE DEDUCTION TYPE - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateChargeDeductionType(
            CreateChargeDeductionTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ChargeDeductionId <= 0 ||
                string.IsNullOrWhiteSpace(request.ChargeDeductionType))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateChargeDeductionType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateChargeDeductionType(
            UpdateChargeDeductionTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ChargeDeductionId <= 0 ||
                string.IsNullOrWhiteSpace(request.ChargeDeductionType))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateChargeDeductionType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteChargeDeductionType(
            int chargeDeductionId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (chargeDeductionId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteChargeDeductionType(
                    chargeDeductionId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetChargeDeductionTypeByID(
            int chargeDeductionId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (chargeDeductionId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetChargeDeductionTypeByID(
                    chargeDeductionId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllChargeDeductionTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllChargeDeductionTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveChargeDeductionTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveChargeDeductionTypes(
                    serviceUser);

            return response;
        }
        // ============================================================
        // SLAB TYPE - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateSlabType(
            CreateSlabTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypId <= 0 ||
                string.IsNullOrWhiteSpace(request.SlabTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateSlabType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SLAB TYPE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateSlabType(
            UpdateSlabTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypId <= 0 ||
                string.IsNullOrWhiteSpace(request.SlabTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateSlabType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SLAB TYPE - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteSlabType(
            int slabTypId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (slabTypId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteSlabType(
                    slabTypId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetSlabTypeByID(
            int slabTypId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (slabTypId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetSlabTypeByID(
                    slabTypId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllSlabTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllSlabTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveSlabTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveSlabTypes(
                    serviceUser);

            return response;
        }
        // ============================================================
        // PAYMENT ACCOUNT - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreatePaymentAccount(
            CreatePaymentAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.BankID == null ||
                request.BankID <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePaymentAccount(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentAccount(
            UpdatePaymentAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.PaymentAccountID <= 0 ||
                request.BankID == null ||
                request.BankID <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdatePaymentAccount(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeletePaymentAccount(
            int paymentAccountID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentAccountID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeletePaymentAccount(
                    paymentAccountID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPaymentAccountByID(
            int paymentAccountID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (paymentAccountID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPaymentAccountByID(
                    paymentAccountID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllPaymentAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllPaymentAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActivePaymentAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActivePaymentAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY BANK ID
        // ============================================================
        public async Task<SimpleResponse> GetPaymentAccountsByBankID(
            int bankID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (bankID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPaymentAccountsByBankID(
                    bankID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE CALCULATION TYPE
        // ============================================================
        public async Task<SimpleResponse> CreateCalculationType(
            CreateCalculationTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CalculationTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.CalculationTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateCalculationType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE CALCULATION TYPE
        // ============================================================
        public async Task<SimpleResponse> UpdateCalculationType(
            UpdateCalculationTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CalculationTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.CalculationTypeName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateCalculationType(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DELETE CALCULATION TYPE
        // ============================================================
        public async Task<SimpleResponse> DeleteCalculationType(
            int calculationTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (calculationTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteCalculationType(
                    calculationTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET CALCULATION TYPE BY ID
        // ============================================================
        public async Task<SimpleResponse> GetCalculationTypeByID(
            int calculationTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (calculationTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCalculationTypeByID(
                    calculationTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL CALCULATION TYPES
        // ============================================================
        public async Task<SimpleResponse> GetAllCalculationTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllCalculationTypes(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE CALCULATION TYPES
        // ============================================================
        public async Task<SimpleResponse> GetActiveCalculationTypes(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveCalculationTypes(
                    serviceUser);

            return response;
        }
    }
}
