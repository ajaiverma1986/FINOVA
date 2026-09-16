using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ResponseCache(
        Duration = -1,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    [ServiceFilter(typeof(FINOVExceptionFilterService))]
    public class MasterDataController : BaseApiController
    {
        public readonly MasterDataProvider _Provider;

        private readonly AuthenticationHelper _callValidator;

        public MasterDataController()
        {
            _Provider = new MasterDataProvider();
            _callValidator = new AuthenticationHelper();
        }

        [HttpGet("GenderList")]
        public async Task<IActionResult> GenderList()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetGender();

            return Json(response);
        }

        [HttpGet("MaritalStatusList")]
        public async Task<IActionResult> MaritalStatusList()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetMaritalStatus();

            return Json(response);
        }

        [HttpGet("DemographicDataListByPincode")]
        public async Task<IActionResult> DemographicDataListByPincode(
            [FromQuery] string Pincode)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetDataByPincode(Pincode);

            return Json(response);
        }

        [HttpPost("DemographicDataListByPincodeList")]
        public async Task<IActionResult> DemographicDataListByPincodeList(
            [FromBody] PincodeDataRequest request)
        {
            ListResponse response = new ListResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetDataByPincodeList(request);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - CREATE
        // ============================================================
        [HttpPost("CreatePlan")]
        public async Task<IActionResult> CreatePlan(
            [FromBody] CreatePlanRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreatePlan(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdatePlan")]
        public async Task<IActionResult> UpdatePlan(
            [FromBody] UpdatePlanRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdatePlan(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - DELETE
        // ============================================================
        [HttpDelete("DeletePlan/{planID}")]
        public async Task<IActionResult> DeletePlan(
            int planID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeletePlan(
                planID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetPlanByID")]
        public async Task<IActionResult> GetPlanByID(
            int planID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetPlanByID(
                planID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllPlans")]
        public async Task<IActionResult> GetAllPlans()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllPlans(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PLAN MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActivePlans")]
        public async Task<IActionResult> GetActivePlans()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActivePlans(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // COMPANY TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateCompanyType")]
        public async Task<IActionResult> CreateCompanyType(
            [FromBody] CreateCompanyTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateCompanyType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMPANY TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateCompanyType")]
        public async Task<IActionResult> UpdateCompanyType(
            [FromBody] UpdateCompanyTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateCompanyType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMPANY TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteCompanyType/{compnayTypeId}")]
        public async Task<IActionResult> DeleteCompanyType(
            int compnayTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteCompanyType(
                compnayTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetCompanyTypeByID")]
        public async Task<IActionResult> GetCompanyTypeByID(
            int compnayTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetCompanyTypeByID(
                compnayTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllCompanyTypes")]
        public async Task<IActionResult> GetAllCompanyTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllCompanyTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveCompanyTypes")]
        public async Task<IActionResult> GetActiveCompanyTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveCompanyTypes(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // AGENCY MASTER - CREATE
        // ============================================================
        [HttpPost("CreateAgency")]
        public async Task<IActionResult> CreateAgency(
            [FromBody] CreateAgencyRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateAgency(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // AGENCY MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateAgency")]
        public async Task<IActionResult> UpdateAgency(
            [FromBody] UpdateAgencyRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateAgency(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // AGENCY MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteAgency/{agencyId}")]
        public async Task<IActionResult> DeleteAgency(
            int agencyId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteAgency(
                agencyId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // AGENCY MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetAgencyByID")]
        public async Task<IActionResult> GetAgencyByID(
            int agencyId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAgencyByID(
                agencyId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // AGENCY MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllAgencies")]
        public async Task<IActionResult> GetAllAgencies()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllAgencies(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // AGENCY MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveAgencies")]
        public async Task<IActionResult> GetActiveAgencies()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveAgencies(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // ADDRESS TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateAddressType")]
        public async Task<IActionResult> CreateAddressType(
            [FromBody] CreateAddressTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateAddressType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADDRESS TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateAddressType")]
        public async Task<IActionResult> UpdateAddressType(
            [FromBody] UpdateAddressTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateAddressType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADDRESS TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteAddressType/{addressTypeId}")]
        public async Task<IActionResult> DeleteAddressType(
            int addressTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteAddressType(
                addressTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetAddressTypeByID")]
        public async Task<IActionResult> GetAddressTypeByID(
            int addressTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAddressTypeByID(
                addressTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllAddressTypes")]
        public async Task<IActionResult> GetAllAddressTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllAddressTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveAddressTypes")]
        public async Task<IActionResult> GetActiveAddressTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveAddressTypes(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // BANK MASTER - CREATE
        // ============================================================
        [HttpPost("CreateBank")]
        public async Task<IActionResult> CreateBank(
            [FromBody] CreateBankRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateBank(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // BANK MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateBank")]
        public async Task<IActionResult> UpdateBank(
            [FromBody] UpdateBankRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateBank(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // BANK MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteBank/{bankID}")]
        public async Task<IActionResult> DeleteBank(int bankID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteBank(
                bankID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // BANK MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetBankByID")]
        public async Task<IActionResult> GetBankByID(int bankID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetBankByID(
                bankID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // BANK MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllBanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllBanks(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // BANK MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveBanks")]
        public async Task<IActionResult> GetActiveBanks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveBanks(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // STATE - CREATE
        // ============================================================
        [HttpPost("CreateState")]
        public async Task<IActionResult> CreateState(
            [FromBody] CreateStateRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateState(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - UPDATE
        // ============================================================
        [HttpPost("UpdateState")]
        public async Task<IActionResult> UpdateState(
            [FromBody] UpdateStateRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateState(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - DELETE
        // ============================================================
        [HttpDelete("DeleteState/{stateID}")]
        public async Task<IActionResult> DeleteState(
            int stateID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteState(
                stateID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - GET BY ID
        // ============================================================
        [HttpGet("GetStateByID")]
        public async Task<IActionResult> GetStateByID(
            int stateID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetStateByID(
                stateID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - GET ALL
        // ============================================================
        [HttpGet("GetAllStates")]
        public async Task<IActionResult> GetAllStates()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllStates(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveStates")]
        public async Task<IActionResult> GetActiveStates()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveStates(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // STATE - GET BY COUNTRY ID
        // ============================================================
        [HttpGet("GetStatesByCountryID")]
        public async Task<IActionResult> GetStatesByCountryID(
            int countryID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetStatesByCountryID(
                countryID,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // DISTRICT - CREATE
        // ============================================================
        [HttpPost("CreateDistrict")]
        public async Task<IActionResult> CreateDistrict(
            [FromBody] CreateDistrictRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateDistrict(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - UPDATE
        // ============================================================
        [HttpPost("UpdateDistrict")]
        public async Task<IActionResult> UpdateDistrict(
            [FromBody] UpdateDistrictRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateDistrict(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - DELETE
        // ============================================================
        [HttpDelete("DeleteDistrict/{districtID}")]
        public async Task<IActionResult> DeleteDistrict(
            long districtID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteDistrict(
                districtID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - GET BY ID
        // ============================================================
        [HttpGet("GetDistrictByID")]
        public async Task<IActionResult> GetDistrictByID(
            long districtID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetDistrictByID(
                districtID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - GET ALL
        // ============================================================
        [HttpGet("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllDistricts(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveDistricts")]
        public async Task<IActionResult> GetActiveDistricts()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveDistricts(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // DISTRICT - GET BY STATE ID
        // ============================================================
        [HttpGet("GetDistrictsByStateID")]
        public async Task<IActionResult> GetDistrictsByStateID(
            int stateID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetDistrictsByStateID(
                stateID,
                CallerUser);

            return Json(response);
        }
        // ============================================================
// KYC TYPE MASTER - CREATE
// ============================================================
[HttpPost("CreateKycType")]
public async Task<IActionResult> CreateKycType(
    [FromBody] CreateKycTypeRequest request)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.CreateKycType(
        request,
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - UPDATE
// ============================================================
[HttpPost("UpdateKycType")]
public async Task<IActionResult> UpdateKycType(
    [FromBody] UpdateKycTypeRequest request)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.UpdateKycType(
        request,
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - DELETE
// ============================================================
[HttpDelete("DeleteKycType/{kycTypeID}")]
public async Task<IActionResult> DeleteKycType(
    int kycTypeID)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.DeleteKycType(
        kycTypeID,
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - GET BY ID
// ============================================================
[HttpGet("GetKycTypeByID")]
public async Task<IActionResult> GetKycTypeByID(
    int kycTypeID)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.GetKycTypeByID(
        kycTypeID,
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - GET ALL
// ============================================================
[HttpGet("GetAllKycTypes")]
public async Task<IActionResult> GetAllKycTypes()
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.GetAllKycTypes(
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - GET ACTIVE
// ============================================================
[HttpGet("GetActiveKycTypes")]
public async Task<IActionResult> GetActiveKycTypes()
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.GetActiveKycTypes(
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - GET BY USER TYPE ID
// ============================================================
[HttpGet("GetKycTypesByUserTypeID")]
public async Task<IActionResult> GetKycTypesByUserTypeID(
    int userTypeID)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response = await _Provider.GetKycTypesByUserTypeID(
        userTypeID,
        CallerUser);

    return Json(response);
}


// ============================================================
// KYC TYPE MASTER - GET BY USER TYPE + COMPANY TYPE
// ============================================================
[HttpGet("GetKycTypesByUserAndCompanyType")]
public async Task<IActionResult> GetKycTypesByUserAndCompanyType(
    int userTypeID,
    int? companyTypeId)
{
    SimpleResponse response = new SimpleResponse();

    ErrorResponse error =
        await _callValidator.AuthenticateAndAuthorize(
            CallerUser,
            true);

    if (error.HasError)
    {
        response.SetError(error);
        return Json(response);
    }

    response =
        await _Provider.GetKycTypesByUserAndCompanyType(
            userTypeID,
            companyTypeId,
            CallerUser);

    return Json(response);
}
        // ============================================================
        // USER TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateUserType")]
        public async Task<IActionResult> CreateUserType(
            [FromBody] CreateUserTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateUserType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateUserType")]
        public async Task<IActionResult> UpdateUserType(
            [FromBody] UpdateUserTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateUserType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteUserType/{userTypeId}")]
        public async Task<IActionResult> DeleteUserType(
            int userTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteUserType(
                userTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetUserTypeByID")]
        public async Task<IActionResult> GetUserTypeByID(
            int userTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetUserTypeByID(
                userTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllUserTypes")]
        public async Task<IActionResult> GetAllUserTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllUserTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // USER TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveUserTypes")]
        public async Task<IActionResult> GetActiveUserTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveUserTypes(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // LEDGER TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateLedgerType")]
        public async Task<IActionResult> CreateLedgerType(
            [FromBody] CreateLedgerTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateLedgerType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // LEDGER TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateLedgerType")]
        public async Task<IActionResult> UpdateLedgerType(
            [FromBody] UpdateLedgerTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateLedgerType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // LEDGER TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteLedgerType/{ledgerTypeId}")]
        public async Task<IActionResult> DeleteLedgerType(
            int ledgerTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteLedgerType(
                ledgerTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetLedgerTypeByID")]
        public async Task<IActionResult> GetLedgerTypeByID(
            int ledgerTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetLedgerTypeByID(
                ledgerTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllLedgerTypes")]
        public async Task<IActionResult> GetAllLedgerTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllLedgerTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveLedgerTypes")]
        public async Task<IActionResult> GetActiveLedgerTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveLedgerTypes(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateServiceType")]
        public async Task<IActionResult> CreateServiceType(
            [FromBody] CreateServiceTypeRequestmdm request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateServiceType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateServiceType")]
        public async Task<IActionResult> UpdateServiceType(
            [FromBody] UpdateServiceTypeRequestmdm request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateServiceType(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteServiceType/{serviceTypeId}")]
        public async Task<IActionResult> DeleteServiceType(
            int serviceTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteServiceType(
                serviceTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetServiceTypeByID")]
        public async Task<IActionResult> GetServiceTypeByID(
            int serviceTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetServiceTypeByID(
                serviceTypeId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllServiceTypes")]
        public async Task<IActionResult> GetAllServiceTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllServiceTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveServiceTypes")]
        public async Task<IActionResult> GetActiveServiceTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveServiceTypes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY AGENCY ID
        // ============================================================
        [HttpGet("GetServiceTypesByAgencyID")]
        public async Task<IActionResult> GetServiceTypesByAgencyID(
            int agencyId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetServiceTypesByAgencyID(
                agencyId,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // PAYMENT CHANEL MASTER - CREATE
        // ============================================================
        [HttpPost("CreatePaymentChanel")]
        public async Task<IActionResult> CreatePaymentChanel(
            [FromBody] CreatePaymentChanelRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreatePaymentChanel(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdatePaymentChanel")]
        public async Task<IActionResult> UpdatePaymentChanel(
            [FromBody] UpdatePaymentChanelRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdatePaymentChanel(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - DELETE
        // ============================================================
        [HttpDelete("DeletePaymentChanel/{paymentChanelID}")]
        public async Task<IActionResult> DeletePaymentChanel(
            int paymentChanelID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeletePaymentChanel(
                paymentChanelID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetPaymentChanelByID")]
        public async Task<IActionResult> GetPaymentChanelByID(
            int paymentChanelID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetPaymentChanelByID(
                paymentChanelID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllPaymentChanels")]
        public async Task<IActionResult> GetAllPaymentChanels()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllPaymentChanels(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActivePaymentChanels")]
        public async Task<IActionResult> GetActivePaymentChanels()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActivePaymentChanels(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // PAYMENT MODE MASTER - CREATE
        // ============================================================
        [HttpPost("CreatePaymentMode")]
        public async Task<IActionResult> CreatePaymentMode(
            [FromBody] CreatePaymentModeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreatePaymentMode(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdatePaymentMode")]
        public async Task<IActionResult> UpdatePaymentMode(
            [FromBody] UpdatePaymentModeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdatePaymentMode(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeletePaymentMode/{paymentModeID}")]
        public async Task<IActionResult> DeletePaymentMode(
            int paymentModeID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeletePaymentMode(
                paymentModeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetPaymentModeByID")]
        public async Task<IActionResult> GetPaymentModeByID(
            int paymentModeID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetPaymentModeByID(
                paymentModeID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllPaymentModes")]
        public async Task<IActionResult> GetAllPaymentModes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllPaymentModes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ACTIVE
        // ============================================================
        [HttpGet("GetActivePaymentModes")]
        public async Task<IActionResult> GetActivePaymentModes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActivePaymentModes(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY PAYMENT CHANEL ID
        // ============================================================
        [HttpGet("GetPaymentModesByPaymentChanelID")]
        public async Task<IActionResult> GetPaymentModesByPaymentChanelID(
            int paymentChanelID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetPaymentModesByPaymentChanelID(
                paymentChanelID,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // SERVICE MASTER - CREATE
        // ============================================================
        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(
            [FromBody] CreateServiceRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateService(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE MASTER - UPDATE
        // ============================================================
        [HttpPost("UpdateService")]
        public async Task<IActionResult> UpdateService(
            [FromBody] UpdateServiceRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateService(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE MASTER - DELETE
        // ============================================================
        [HttpDelete("DeleteService/{serviceId}")]
        public async Task<IActionResult> DeleteService(
            int serviceId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteService(
                serviceId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE MASTER - GET BY ID
        // ============================================================
        [HttpGet("GetServiceByID")]
        public async Task<IActionResult> GetServiceByID(
            int serviceId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetServiceByID(
                serviceId,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE MASTER - GET ALL
        // ============================================================
        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllServices(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // SERVICE MASTER - GET BY SERVICE TYPE ID
        // ============================================================
        [HttpGet("GetServicesByServiceTypeID")]
        public async Task<IActionResult> GetServicesByServiceTypeID(
            int serviceTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetServicesByServiceTypeID(
                serviceTypeId,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // CHARGE DEDUCTION TYPE - CREATE
        // ============================================================
        [HttpPost("CreateChargeDeductionType")]
        public async Task<IActionResult> CreateChargeDeductionType(
            [FromBody] CreateChargeDeductionTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateChargeDeductionType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - UPDATE
        // ============================================================
        [HttpPost("UpdateChargeDeductionType")]
        public async Task<IActionResult> UpdateChargeDeductionType(
            [FromBody] UpdateChargeDeductionTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateChargeDeductionType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - DELETE
        // ============================================================
        [HttpDelete("DeleteChargeDeductionType/{chargeDeductionId}")]
        public async Task<IActionResult> DeleteChargeDeductionType(
            int chargeDeductionId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteChargeDeductionType(
                    chargeDeductionId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET BY ID
        // ============================================================
        [HttpGet("GetChargeDeductionTypeByID")]
        public async Task<IActionResult> GetChargeDeductionTypeByID(
            int chargeDeductionId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetChargeDeductionTypeByID(
                    chargeDeductionId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ALL
        // ============================================================
        [HttpGet("GetAllChargeDeductionTypes")]
        public async Task<IActionResult> GetAllChargeDeductionTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllChargeDeductionTypes(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveChargeDeductionTypes")]
        public async Task<IActionResult> GetActiveChargeDeductionTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveChargeDeductionTypes(
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // SLAB TYPE - CREATE
        // ============================================================
        [HttpPost("CreateSlabType")]
        public async Task<IActionResult> CreateSlabType(
            [FromBody] CreateSlabTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateSlabType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // SLAB TYPE - UPDATE
        // ============================================================
        [HttpPost("UpdateSlabType")]
        public async Task<IActionResult> UpdateSlabType(
            [FromBody] UpdateSlabTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateSlabType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // SLAB TYPE - DELETE
        // ============================================================
        [HttpDelete("DeleteSlabType/{slabTypId}")]
        public async Task<IActionResult> DeleteSlabType(
            int slabTypId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteSlabType(
                    slabTypId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // SLAB TYPE - GET BY ID
        // ============================================================
        [HttpGet("GetSlabTypeByID")]
        public async Task<IActionResult> GetSlabTypeByID(
            int slabTypId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetSlabTypeByID(
                    slabTypId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // SLAB TYPE - GET ALL
        // ============================================================
        [HttpGet("GetAllSlabTypes")]
        public async Task<IActionResult> GetAllSlabTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllSlabTypes(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // SLAB TYPE - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveSlabTypes")]
        public async Task<IActionResult> GetActiveSlabTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveSlabTypes(
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // PAYMENT ACCOUNT - CREATE
        // ============================================================
        [HttpPost("CreatePaymentAccount")]
        public async Task<IActionResult> CreatePaymentAccount(
            [FromBody] CreatePaymentAccountRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreatePaymentAccount(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - UPDATE
        // ============================================================
        [HttpPost("UpdatePaymentAccount")]
        public async Task<IActionResult> UpdatePaymentAccount(
            [FromBody] UpdatePaymentAccountRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdatePaymentAccount(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - DELETE
        // ============================================================
        [HttpDelete("DeletePaymentAccount/{paymentAccountID}")]
        public async Task<IActionResult> DeletePaymentAccount(
            int paymentAccountID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeletePaymentAccount(
                    paymentAccountID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY ID
        // ============================================================
        [HttpGet("GetPaymentAccountByID")]
        public async Task<IActionResult> GetPaymentAccountByID(
            int paymentAccountID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetPaymentAccountByID(
                    paymentAccountID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ALL
        // ============================================================
        [HttpGet("GetAllPaymentAccounts")]
        public async Task<IActionResult> GetAllPaymentAccounts()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllPaymentAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ACTIVE
        // ============================================================
        [HttpGet("GetActivePaymentAccounts")]
        public async Task<IActionResult> GetActivePaymentAccounts()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActivePaymentAccounts(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY BANK ID
        // ============================================================
        [HttpGet("GetPaymentAccountsByBankID")]
        public async Task<IActionResult> GetPaymentAccountsByBankID(
            int bankID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetPaymentAccountsByBankID(
                    bankID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE CALCULATION TYPE
        // ============================================================
        [HttpPost("CreateCalculationType")]
        public async Task<IActionResult> CreateCalculationType(
            [FromBody] CreateCalculationTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateCalculationType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE CALCULATION TYPE
        // ============================================================
        [HttpPost("UpdateCalculationType")]
        public async Task<IActionResult> UpdateCalculationType(
            [FromBody] UpdateCalculationTypeRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateCalculationType(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE CALCULATION TYPE
        // ============================================================
        [HttpDelete("DeleteCalculationType/{calculationTypeId}")]
        public async Task<IActionResult> DeleteCalculationType(
            int calculationTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteCalculationType(
                    calculationTypeId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET CALCULATION TYPE BY ID
        // ============================================================
        [HttpGet("GetCalculationTypeByID")]
        public async Task<IActionResult> GetCalculationTypeByID(
            int calculationTypeId)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetCalculationTypeByID(
                    calculationTypeId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL CALCULATION TYPES
        // ============================================================
        [HttpGet("GetAllCalculationTypes")]
        public async Task<IActionResult> GetAllCalculationTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllCalculationTypes(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE CALCULATION TYPES
        // ============================================================
        [HttpGet("GetActiveCalculationTypes")]
        public async Task<IActionResult> GetActiveCalculationTypes()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveCalculationTypes(
                    CallerUser);

            return Json(response);
        }
    }
}

