using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;

namespace FINOVA.Provider
{
    public class ConfigProvider : BaseProvider
    {
        public readonly ConfigRepository _repository = null;
        public ConfigProvider()
        {
            _repository = new ConfigRepository();
        }
        public async Task<SimpleResponse> AddNewTransactionslab(AddTxnslabRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();
            response.Result = await _repository.AddTransactionslab(request, serviceUser);
            return response;
        }
     
        public async Task<SimpleResponse> GetServicePolicy(GetServicePolicyRequest request)
        {
            SimpleResponse response = new SimpleResponse();
            response = await _repository.GetServicePolicy(request);
            return response;
        }
        // ============================================================
        // TOPUP CHARGE - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateTopupCharge(
            CreateTopupChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypeId == null ||
                request.SlabTypeId <= 0 ||
                request.CalculationTypeId == null ||
                request.CalculationTypeId <= 0 ||
                request.CalculationValue == null ||
                request.CalculationValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.Toamount.HasValue &&
                request.Toamount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateTopupCharge(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTopupCharge(
            UpdateTopupChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TopupChargeId <= 0 ||
                request.SlabTypeId == null ||
                request.SlabTypeId <= 0 ||
                request.CalculationTypeId == null ||
                request.CalculationTypeId <= 0 ||
                request.CalculationValue == null ||
                request.CalculationValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.Toamount.HasValue &&
                request.Toamount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateTopupCharge(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTopupCharge(
            int topupChargeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (topupChargeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteTopupCharge(
                    topupChargeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTopupChargeByID(
            int topupChargeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (topupChargeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTopupChargeByID(
                    topupChargeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllTopupCharges(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllTopupCharges(
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveTopupCharges(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveTopupCharges(
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY SLAB TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetTopupChargesBySlabTypeID(
            int slabTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (slabTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTopupChargesBySlabTypeID(
                    slabTypeId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY CALCULATION TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetTopupChargesByCalculationTypeID(
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
                await _repository.GetTopupChargesByCalculationTypeID(
                    calculationTypeId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // COMMISSION DISTRIBUTION - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateCommissionDistribution(
            CreateCommissionDistributionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.AgencyId <= 0 ||
                request.ServiceId <= 0 ||
                (request.PlanId.HasValue && request.PlanId <= 0) ||
                (request.FromAmount.HasValue && request.FromAmount < 0) ||
                (request.Toamount.HasValue && request.Toamount < 0) ||
                (request.CalculationTypeId.HasValue && request.CalculationTypeId <= 0) ||
                (request.CalculationValue.HasValue && request.CalculationValue < 0))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.Toamount.HasValue &&
                request.Toamount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateCommissionDistribution(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateCommissionDistribution(
            UpdateCommissionDistributionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MarginConfigrationID <= 0 ||
                request.AgencyId <= 0 ||
                request.ServiceId <= 0 ||
                (request.PlanId.HasValue && request.PlanId <= 0) ||
                (request.FromAmount.HasValue && request.FromAmount < 0) ||
                (request.Toamount.HasValue && request.Toamount < 0) ||
                (request.CalculationTypeId.HasValue && request.CalculationTypeId <= 0) ||
                (request.CalculationValue.HasValue && request.CalculationValue < 0))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.Toamount.HasValue &&
                request.Toamount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateCommissionDistribution(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteCommissionDistribution(
            long marginConfigrationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (marginConfigrationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteCommissionDistribution(
                    marginConfigrationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionByID(
            long marginConfigrationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (marginConfigrationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCommissionDistributionByID(
                    marginConfigrationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllCommissionDistributions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllCommissionDistributions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveCommissionDistributions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveCommissionDistributions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY ID
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionsByAgencyID(
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
                await _repository.GetCommissionDistributionsByAgencyID(
                    agencyId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY SERVICE ID
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionsByServiceID(
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
                await _repository.GetCommissionDistributionsByServiceID(
                    serviceId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY PLAN ID
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionsByPlanID(
            int planId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (planId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCommissionDistributionsByPlanID(
                    planId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY + SERVICE
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionsByAgencyService(
            int agencyId,
            int serviceId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyId <= 0 || serviceId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCommissionDistributionsByAgencyService(
                    agencyId,
                    serviceId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE TRANSACTION SLAB
        // ============================================================
        public async Task<SimpleResponse> CreateTransactionSlab(
            CreateTransactionSlabRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if ((request.PlanId.HasValue && request.PlanId <= 0) ||
                (request.AgencyID.HasValue && request.AgencyID <= 0) ||
                (request.ServiceID.HasValue && request.ServiceID <= 0) ||
                (request.FromAmount.HasValue && request.FromAmount < 0) ||
                (request.ToAmount.HasValue && request.ToAmount < 0) ||
                (request.SlabType.HasValue && request.SlabType <= 0) ||
                (request.CalculationType.HasValue && request.CalculationType <= 0) ||
                (request.CalculationValue.HasValue && request.CalculationValue < 0))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.ToAmount.HasValue &&
                request.ToAmount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateTransactionSlab(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE TRANSACTION SLAB
        // ============================================================
        public async Task<SimpleResponse> UpdateTransactionSlab(
            UpdateTransactionSlabRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabId <= 0 ||
                (request.PlanId.HasValue && request.PlanId <= 0) ||
                (request.AgencyID.HasValue && request.AgencyID <= 0) ||
                (request.ServiceID.HasValue && request.ServiceID <= 0) ||
                (request.FromAmount.HasValue && request.FromAmount < 0) ||
                (request.ToAmount.HasValue && request.ToAmount < 0) ||
                (request.SlabType.HasValue && request.SlabType <= 0) ||
                (request.CalculationType.HasValue && request.CalculationType <= 0) ||
                (request.CalculationValue.HasValue && request.CalculationValue < 0))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromAmount.HasValue &&
                request.ToAmount.HasValue &&
                request.ToAmount < request.FromAmount)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateTransactionSlab(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DELETE TRANSACTION SLAB
        // ============================================================
        public async Task<SimpleResponse> DeleteTransactionSlab(
            long slabId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (slabId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteTransactionSlab(
                    slabId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLAB BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTransactionSlabByID(
            long slabId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (slabId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTransactionSlabByID(
                    slabId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL TRANSACTION SLABS
        // ============================================================
        public async Task<SimpleResponse> GetAllTransactionSlabs(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllTransactionSlabs(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE TRANSACTION SLABS
        // ============================================================
        public async Task<SimpleResponse> GetActiveTransactionSlabs(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveTransactionSlabs(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY PLAN ID
        // ============================================================
        public async Task<SimpleResponse> GetTransactionSlabsByPlanID(
            int planId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (planId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTransactionSlabsByPlanID(
                    planId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY ID
        // ============================================================
        public async Task<SimpleResponse> GetTransactionSlabsByAgencyID(
            int agencyID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTransactionSlabsByAgencyID(
                    agencyID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY SERVICE ID
        // ============================================================
        public async Task<SimpleResponse> GetTransactionSlabsByServiceID(
            int serviceID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (serviceID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTransactionSlabsByServiceID(
                    serviceID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY + SERVICE
        // ============================================================
        public async Task<SimpleResponse> GetTransactionSlabsByAgencyService(
            int agencyID,
            int serviceID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (agencyID <= 0 || serviceID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTransactionSlabsByAgencyService(
                    agencyID,
                    serviceID,
                    serviceUser);

            return response;
        }
    }
}
