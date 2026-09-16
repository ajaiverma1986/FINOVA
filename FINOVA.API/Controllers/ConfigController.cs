using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    [ResponseCache(
        Duration = -1,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    [ServiceFilter(typeof(FINOVExceptionFilterService))]
    public class ConfigController : BaseApiController
    {
        public readonly ConfigProvider _Provider;

        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;

        public ConfigController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new ConfigProvider();
            _callValidator = new AuthenticationHelper();
        }


        [HttpPost("GetServicePolicy")]
        public async Task<IActionResult> GetServicePolicy(
            [FromBody] GetServicePolicyRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetServicePolicy(request);

            return Json(response);
        }

        [HttpPost("AddTransacttionSlab")]
        public async Task<IActionResult> AddTransacttionSlab(
            [FromBody] AddTxnslabRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.AddNewTransactionslab(
                request,
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // TOPUP CHARGE - CREATE
        // ============================================================
        [HttpPost("CreateTopupCharge")]
        public async Task<IActionResult> CreateTopupCharge(
            [FromBody] CreateTopupChargeRequest request)
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
                await _Provider.CreateTopupCharge(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - UPDATE
        // ============================================================
        [HttpPost("UpdateTopupCharge")]
        public async Task<IActionResult> UpdateTopupCharge(
            [FromBody] UpdateTopupChargeRequest request)
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
                await _Provider.UpdateTopupCharge(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - DELETE
        // ============================================================
        [HttpDelete("DeleteTopupCharge/{topupChargeId}")]
        public async Task<IActionResult> DeleteTopupCharge(
            int topupChargeId)
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
                await _Provider.DeleteTopupCharge(
                    topupChargeId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - GET BY ID
        // ============================================================
        [HttpGet("GetTopupChargeByID")]
        public async Task<IActionResult> GetTopupChargeByID(
            int topupChargeId)
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
                await _Provider.GetTopupChargeByID(
                    topupChargeId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - GET ALL
        // ============================================================
        [HttpGet("GetAllTopupCharges")]
        public async Task<IActionResult> GetAllTopupCharges()
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
                await _Provider.GetAllTopupCharges(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveTopupCharges")]
        public async Task<IActionResult> GetActiveTopupCharges()
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
                await _Provider.GetActiveTopupCharges(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - GET BY SLAB TYPE ID
        // ============================================================
        [HttpGet("GetTopupChargesBySlabTypeID")]
        public async Task<IActionResult> GetTopupChargesBySlabTypeID(
            int slabTypeId)
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
                await _Provider.GetTopupChargesBySlabTypeID(
                    slabTypeId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TOPUP CHARGE - GET BY CALCULATION TYPE ID
        // ============================================================
        [HttpGet("GetTopupChargesByCalculationTypeID")]
        public async Task<IActionResult> GetTopupChargesByCalculationTypeID(
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
                await _Provider.GetTopupChargesByCalculationTypeID(
                    calculationTypeId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // COMMISSION DISTRIBUTION - CREATE
        // ============================================================
        [HttpPost("CreateCommissionDistribution")]
        public async Task<IActionResult> CreateCommissionDistribution(
            [FromBody] CreateCommissionDistributionRequest request)
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
                await _Provider.CreateCommissionDistribution(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - UPDATE
        // ============================================================
        [HttpPost("UpdateCommissionDistribution")]
        public async Task<IActionResult> UpdateCommissionDistribution(
            [FromBody] UpdateCommissionDistributionRequest request)
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
                await _Provider.UpdateCommissionDistribution(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - DELETE
        // ============================================================
        [HttpDelete("DeleteCommissionDistribution/{marginConfigrationID}")]
        public async Task<IActionResult> DeleteCommissionDistribution(
            long marginConfigrationID)
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
                await _Provider.DeleteCommissionDistribution(
                    marginConfigrationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY ID
        // ============================================================
        [HttpGet("GetCommissionDistributionByID")]
        public async Task<IActionResult> GetCommissionDistributionByID(
            long marginConfigrationID)
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
                await _Provider.GetCommissionDistributionByID(
                    marginConfigrationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ALL
        // ============================================================
        [HttpGet("GetAllCommissionDistributions")]
        public async Task<IActionResult> GetAllCommissionDistributions()
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
                await _Provider.GetAllCommissionDistributions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveCommissionDistributions")]
        public async Task<IActionResult> GetActiveCommissionDistributions()
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
                await _Provider.GetActiveCommissionDistributions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY ID
        // ============================================================
        [HttpGet("GetCommissionDistributionsByAgencyID")]
        public async Task<IActionResult> GetCommissionDistributionsByAgencyID(
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

            response =
                await _Provider.GetCommissionDistributionsByAgencyID(
                    agencyId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY SERVICE ID
        // ============================================================
        [HttpGet("GetCommissionDistributionsByServiceID")]
        public async Task<IActionResult> GetCommissionDistributionsByServiceID(
            int serviceId)
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
                await _Provider.GetCommissionDistributionsByServiceID(
                    serviceId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY PLAN ID
        // ============================================================
        [HttpGet("GetCommissionDistributionsByPlanID")]
        public async Task<IActionResult> GetCommissionDistributionsByPlanID(
            int planId)
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
                await _Provider.GetCommissionDistributionsByPlanID(
                    planId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY + SERVICE
        // ============================================================
        [HttpGet("GetCommissionDistributionsByAgencyService")]
        public async Task<IActionResult> GetCommissionDistributionsByAgencyService(
            int agencyId,
            int serviceId)
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
                await _Provider.GetCommissionDistributionsByAgencyService(
                    agencyId,
                    serviceId,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // CREATE TRANSACTION SLAB
        // ============================================================
        [HttpPost("CreateTransactionSlab")]
        public async Task<IActionResult> CreateTransactionSlab(
            [FromBody] CreateTransactionSlabRequest request)
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
                await _Provider.CreateTransactionSlab(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // UPDATE TRANSACTION SLAB
        // ============================================================
        [HttpPost("UpdateTransactionSlab")]
        public async Task<IActionResult> UpdateTransactionSlab(
            [FromBody] UpdateTransactionSlabRequest request)
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
                await _Provider.UpdateTransactionSlab(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // DELETE TRANSACTION SLAB
        // ============================================================
        [HttpDelete("DeleteTransactionSlab/{slabId}")]
        public async Task<IActionResult> DeleteTransactionSlab(
            long slabId)
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
                await _Provider.DeleteTransactionSlab(
                    slabId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET TRANSACTION SLAB BY ID
        // ============================================================
        [HttpGet("GetTransactionSlabByID")]
        public async Task<IActionResult> GetTransactionSlabByID(
            long slabId)
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
                await _Provider.GetTransactionSlabByID(
                    slabId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ALL TRANSACTION SLABS
        // ============================================================
        [HttpGet("GetAllTransactionSlabs")]
        public async Task<IActionResult> GetAllTransactionSlabs()
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
                await _Provider.GetAllTransactionSlabs(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET ACTIVE TRANSACTION SLABS
        // ============================================================
        [HttpGet("GetActiveTransactionSlabs")]
        public async Task<IActionResult> GetActiveTransactionSlabs()
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
                await _Provider.GetActiveTransactionSlabs(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET TRANSACTION SLABS BY PLAN ID
        // ============================================================
        [HttpGet("GetTransactionSlabsByPlanID")]
        public async Task<IActionResult> GetTransactionSlabsByPlanID(
            int planId)
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
                await _Provider.GetTransactionSlabsByPlanID(
                    planId,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY ID
        // ============================================================
        [HttpGet("GetTransactionSlabsByAgencyID")]
        public async Task<IActionResult> GetTransactionSlabsByAgencyID(
            int agencyID)
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
                await _Provider.GetTransactionSlabsByAgencyID(
                    agencyID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET TRANSACTION SLABS BY SERVICE ID
        // ============================================================
        [HttpGet("GetTransactionSlabsByServiceID")]
        public async Task<IActionResult> GetTransactionSlabsByServiceID(
            int serviceID)
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
                await _Provider.GetTransactionSlabsByServiceID(
                    serviceID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY + SERVICE
        // ============================================================
        [HttpGet("GetTransactionSlabsByAgencyService")]
        public async Task<IActionResult> GetTransactionSlabsByAgencyService(
            int agencyID,
            int serviceID)
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
                await _Provider.GetTransactionSlabsByAgencyService(
                    agencyID,
                    serviceID,
                    CallerUser);

            return Json(response);
        }
    }
}
