using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.Transactions;
using FINOVA.Provider.Shared;
using FINOVA.Repository;


namespace FINOVA.Provider
{
   public class TransactionProvider:BaseProvider
    {
        public readonly TransactionRepository _repository = null;
        public TransactionProvider()
        {
            _repository = new TransactionRepository();
        }
        // ============================================================
        // CREATE NEW TRANSACTION
        // ============================================================
        public async Task<SimpleResponse> CreateNewTransaction(
            NewTransactionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // VALIDATE REQUEST
            // ========================================================
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // VALIDATE REQUIRED IDS
            // ========================================================
            if (request.OrganizationId <= 0 ||
                request.UserMasterId <= 0 ||
                request.ServiceId <= 0 ||
                request.AgencyId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // VALIDATE AMOUNT
            // ========================================================
            if (request.Amount <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // VALIDATE FEE / MARGIN
            // ========================================================
            if (request.TxnFee < 0 ||
                request.Margin < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // VALIDATE REQUIRED STRING VALUES
            // ========================================================
            if (string.IsNullOrWhiteSpace(request.PartnerTxnId) ||
                string.IsNullOrWhiteSpace(request.TxnType) ||
                string.IsNullOrWhiteSpace(request.TxnPlateform))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // NORMALIZE STRING VALUES
            // ========================================================
            request.PartnerTxnId =
                request.PartnerTxnId.Trim();

            if (!string.IsNullOrWhiteSpace(request.PartnerRetailorId))
            {
                request.PartnerRetailorId =
                    request.PartnerRetailorId.Trim();
            }

            if (!string.IsNullOrWhiteSpace(request.Description))
            {
                request.Description =
                    request.Description.Trim();
            }

            request.TxnType =
                request.TxnType.Trim();

            request.TxnPlateform =
                request.TxnPlateform.Trim();

            // ========================================================
            // CALL REPOSITORY
            // ========================================================
            response.Result =
                await _repository.CreateNewTransaction(
                    request,
                    serviceUser);

            return response;
        }
    }
}
