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
        // ============================================================
        // CODE PREFIX MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateCodePrefix(
            CreateCodePrefixRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.OrganizationId <= 0 ||
                request.ApplicationId <= 0 ||
                string.IsNullOrWhiteSpace(request.CodePrefix) ||
                string.IsNullOrWhiteSpace(request.CodeLngth))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.CodePrefix = request.CodePrefix.Trim();
            request.CodeLngth = request.CodeLngth.Trim();

            if (request.CodePrefix.Length > 10 ||
                request.CodeLngth.Length > 20)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.Status < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateCodePrefix(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CODE PREFIX MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateCodePrefix(
            UpdateCodePrefixRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.Id <= 0 ||
                request.OrganizationId <= 0 ||
                request.ApplicationId <= 0 ||
                string.IsNullOrWhiteSpace(request.CodePrefix) ||
                string.IsNullOrWhiteSpace(request.CodeLngth))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.CodePrefix = request.CodePrefix.Trim();
            request.CodeLngth = request.CodeLngth.Trim();

            if (request.CodePrefix.Length > 10 ||
                request.CodeLngth.Length > 20)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.Status < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.UpdateCodePrefix(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CODE PREFIX MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteCodePrefix(
            int id,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (id <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.DeleteCodePrefix(
                    id,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CODE PREFIX MASTER - GET / GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetCodePrefixes(
            GetCodePrefixRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Invalid optional Id -> remove filter
            if (request.Id.HasValue &&
                request.Id.Value <= 0)
            {
                request.Id = null;
            }

            // Invalid optional OrganizationId -> remove filter
            if (request.OrganizationId.HasValue &&
                request.OrganizationId.Value <= 0)
            {
                request.OrganizationId = null;
            }

            // Invalid optional ApplicationId -> remove filter
            if (request.ApplicationId.HasValue &&
                request.ApplicationId.Value <= 0)
            {
                request.ApplicationId = null;
            }

            request.CodePrefix =
                string.IsNullOrWhiteSpace(request.CodePrefix)
                    ? null
                    : request.CodePrefix.Trim();

            if (!string.IsNullOrEmpty(request.CodePrefix) &&
                request.CodePrefix.Length > 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCodePrefixes(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // CODE PREFIX MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveCodePrefix(
            int organizationId,
            int applicationId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (organizationId <= 0 ||
                applicationId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveCodePrefix(
                    organizationId,
                    applicationId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE SERVICE AGENCY CHARGE
        // ============================================================
        public async Task<SimpleResponse> CreateServiceAgencyCharge(
            CreateServiceAgencyChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate amount range
            if (request.FromAmount < 0 ||
                request.ToAmount < 0 ||
                request.ToAmount < request.FromAmount ||
                request.CalculationValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate optional IDs when provided
            if (request.AgencyID.HasValue &&
                request.AgencyID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceID.HasValue &&
                request.ServiceID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypeId.HasValue &&
                request.SlabTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CalculationTypeId.HasValue &&
                request.CalculationTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            long mappingId =
                await _repository.CreateServiceAgencyCharge(
                    request,
                    serviceUser);

            response.Result = mappingId;

            return response;
        }


        // ============================================================
        // UPDATE SERVICE AGENCY CHARGE
        // ============================================================
        public async Task<SimpleResponse> UpdateServiceAgencyCharge(
            UpdateServiceAgencyChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.MappingId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate amount range
            if (request.FromAmount < 0 ||
                request.ToAmount < 0 ||
                request.ToAmount < request.FromAmount ||
                request.CalculationValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate optional IDs
            if (request.AgencyID.HasValue &&
                request.AgencyID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceID.HasValue &&
                request.ServiceID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypeId.HasValue &&
                request.SlabTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CalculationTypeId.HasValue &&
                request.CalculationTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            UpdateServiceAgencyChargeResponse? result =
                await _repository.UpdateServiceAgencyCharge(
                    request,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // DELETE SERVICE AGENCY CHARGE
        // ============================================================
        public async Task<SimpleResponse> DeleteServiceAgencyCharge(
            long mappingId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (mappingId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            DeleteServiceAgencyChargeResponse? result =
                await _repository.DeleteServiceAgencyCharge(
                    mappingId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET SERVICE AGENCY CHARGE BY ID
        // ============================================================
        public async Task<SimpleResponse> GetServiceAgencyChargeByID(
            long mappingId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (mappingId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            GetServiceAgencyChargeResponse? result =
                await _repository.GetServiceAgencyChargeByID(
                    mappingId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET SERVICE AGENCY CHARGES
        // ============================================================
        public async Task<SimpleResponse> GetServiceAgencyCharges(
            GetServiceAgencyChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // Allow an empty request because all GetAll filters are optional
            request ??= new GetServiceAgencyChargeRequest();

            if (request.AgencyID.HasValue &&
                request.AgencyID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ServiceID.HasValue &&
                request.ServiceID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.SlabTypeId.HasValue &&
                request.SlabTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CalculationTypeId.HasValue &&
                request.CalculationTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            List<GetServiceAgencyChargeResponse> result =
                await _repository.GetServiceAgencyCharges(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // CREATE TDS MASTER
        // ============================================================
        public async Task<SimpleResponse> CreateTdsMaster(
            CreateTdsMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TdsRate < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            int result =
                await _repository.CreateTdsMaster(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // UPDATE TDS MASTER
        // ============================================================
        public async Task<SimpleResponse> UpdateTdsMaster(
            UpdateTdsMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.TdsRateId <= 0 ||
                request.TdsRate < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            UpdateTdsMasterResponse? result =
                await _repository.UpdateTdsMaster(
                    request,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // DELETE TDS MASTER
        // ============================================================
        public async Task<SimpleResponse> DeleteTdsMaster(
            int tdsRateId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (tdsRateId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            DeleteTdsMasterResponse? result =
                await _repository.DeleteTdsMaster(
                    tdsRateId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET TDS MASTER BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTdsMasterByID(
            int tdsRateId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (tdsRateId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            GetTdsMasterResponse? result =
                await _repository.GetTdsMasterByID(
                    tdsRateId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET ALL TDS MASTER
        // ============================================================
        public async Task<SimpleResponse> GetTdsMasters(
            GetTdsMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            request ??= new GetTdsMasterRequest();

            List<GetTdsMasterResponse> result =
                await _repository.GetTdsMasters(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
        // ============================================================
        // CREATE COMMISSION DISTRIBUTION SETUP
        // ============================================================
        public async Task<SimpleResponse> CreateCommissionDistributionSetup(
            CreateCommissionDistributionSetupRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.AgencyId <= 0 ||
                request.ServiceId <= 0 ||
                request.PlanId <= 0 ||
                request.CalculationTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.AgancyValue < 0 ||
                request.OrgValue < 0 ||
                request.MdsValue < 0 ||
                request.DSValue < 0 ||
                request.AgentValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            long result =
                await _repository.CreateCommissionDistributionSetup(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // UPDATE COMMISSION DISTRIBUTION SETUP
        // ============================================================
        public async Task<SimpleResponse> UpdateCommissionDistributionSetup(
            UpdateCommissionDistributionSetupRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.DistributionId <= 0 ||
                request.AgencyId <= 0 ||
                request.ServiceId <= 0 ||
                request.PlanId <= 0 ||
                request.CalculationTypeId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.AgancyValue < 0 ||
                request.OrgValue < 0 ||
                request.MdsValue < 0 ||
                request.DSValue < 0 ||
                request.AgentValue < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            UpdateCommissionDistributionSetupResponse? result =
                await _repository.UpdateCommissionDistributionSetup(
                    request,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // DELETE COMMISSION DISTRIBUTION SETUP
        // ============================================================
        public async Task<SimpleResponse> DeleteCommissionDistributionSetup(
            long distributionId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (distributionId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            DeleteCommissionDistributionSetupResponse? result =
                await _repository.DeleteCommissionDistributionSetup(
                    distributionId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET COMMISSION DISTRIBUTION SETUP BY ID
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionSetupByID(
            long distributionId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (distributionId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            GetCommissionDistributionSetupResponse? result =
                await _repository.GetCommissionDistributionSetupByID(
                    distributionId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET ALL / FILTER COMMISSION DISTRIBUTION SETUPS
        // ============================================================
        public async Task<SimpleResponse> GetCommissionDistributionSetups(
            GetCommissionDistributionSetupRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            request ??= new GetCommissionDistributionSetupRequest();

            // Validate optional filters only when supplied
            if ((request.AgencyId.HasValue &&
                 request.AgencyId.Value <= 0) ||

                (request.ServiceId.HasValue &&
                 request.ServiceId.Value <= 0) ||

                (request.PlanId.HasValue &&
                 request.PlanId.Value <= 0) ||

                (request.CalculationTypeId.HasValue &&
                 request.CalculationTypeId.Value <= 0))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            List<GetCommissionDistributionSetupResponse> result =
                await _repository.GetCommissionDistributionSetups(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
    }
}
