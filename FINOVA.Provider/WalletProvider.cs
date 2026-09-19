using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.Wallet;
using FINOVA.Provider.Shared;
using FINOVA.Repository;


namespace FINOVA.Provider
{
   public class WalletProvider:BaseProvider
    {
        public readonly WalletRepository _repository = null;
        public WalletProvider() 
        {
            _repository = new WalletRepository();
        }
        // ============================================================
        // CREATE COMPANY ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> CreateCompanyAccount(
            CreateCompanyAccountRequest request,
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
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountType) ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // IFSC is optional, but if supplied it should not exceed DB length.
            if (!string.IsNullOrWhiteSpace(request.Ifsccode) &&
                request.Ifsccode.Trim().Length > 11)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateCompanyAccount(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE COMPANY ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> UpdateCompanyAccount(
            UpdateCompanyAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.CompanyAccountId <= 0 ||
                request.OrganizationId <= 0 ||
                request.ApplicationId <= 0 ||
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountType) ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (!string.IsNullOrWhiteSpace(request.Ifsccode) &&
                request.Ifsccode.Trim().Length > 11)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateCompanyAccount(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DELETE COMPANY ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> DeleteCompanyAccount(
            long companyAccountId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (companyAccountId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteCompanyAccount(
                    companyAccountId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNT BY ID
        // ============================================================
        public async Task<SimpleResponse> GetCompanyAccountByID(
            long companyAccountId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (companyAccountId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCompanyAccountByID(
                    companyAccountId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL COMPANY ACCOUNTS
        // ============================================================
        public async Task<SimpleResponse> GetAllCompanyAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllCompanyAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE COMPANY ACCOUNTS
        // ============================================================
        public async Task<SimpleResponse> GetActiveCompanyAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveCompanyAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION ID
        // ============================================================
        public async Task<SimpleResponse> GetCompanyAccountsByOrganizationId(
            int organizationId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (organizationId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCompanyAccountsByOrganizationId(
                    organizationId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY APPLICATION ID
        // ============================================================
        public async Task<SimpleResponse> GetCompanyAccountsByApplicationId(
            int applicationId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (applicationId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetCompanyAccountsByApplicationId(
                    applicationId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION + APPLICATION
        // ============================================================
        public async Task<SimpleResponse>
            GetCompanyAccountsByOrganizationApplication(
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
                await _repository.GetCompanyAccountsByOrganizationApplication(
                    organizationId,
                    applicationId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE PAYIN REQUEST
        // ============================================================
        public async Task<SimpleResponse> CreatePayinRequest(
            CreatePayinRequestRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId <= 0 ||
                request.PaymentChanelID <= 0 ||
                request.PaymentModeId <= 0 ||
                request.Amount <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.Charge < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePayinRequest(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPROVE / REJECT PAYIN REQUEST
        // ============================================================
        public async Task<SimpleResponse> ApproveRejectPayinRequest(
            ApproveRejectPayinRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.RequestID <= 0 ||
                string.IsNullOrWhiteSpace(request.Action))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            string action =
                request.Action.Trim().ToUpper();

            if (action != "APPROVE" &&
                action != "REJECT")
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Rejection reason is mandatory for REJECT.
            if (action == "REJECT" &&
                string.IsNullOrWhiteSpace(request.RejectedReason))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.Action = action;

            response =
                await _repository.ApproveRejectPayinRequest(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET PAYIN REQUEST BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPayinRequestByID(
            long requestID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (requestID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPayinRequestByID(
                    requestID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL PAYIN REQUESTS
        // ============================================================
        public async Task<SimpleResponse> GetAllPayinRequests(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllPayinRequests(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET PAYIN REQUESTS BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetPayinRequestsByUserMasterID(
            long userMasterId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPayinRequestsByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET PAYIN REQUESTS BY STATUS
        // ============================================================
        public async Task<SimpleResponse> GetPayinRequestsByStatus(
            int status,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // Based on current Payin status:
            // 1 = Pending
            // 2 = Approved
            // 3 = Rejected
            if (status != 1 &&
                status != 2 &&
                status != 3)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPayinRequestsByStatus(
                    status,
                    serviceUser);

            return response;
        }
        // ============================================================
        // SEARCH PAYIN REQUESTS WITH FILTERS + PAGING
        // ============================================================
        public async Task<SimpleResponse> SearchPayinRequests(
            SearchPayinRequest request,
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
            // VALIDATE PAGING
            // ========================================================
            if (request.PageNumber <= 0)
            {
                request.PageNumber = 1;
            }

            if (request.PageSize <= 0)
            {
                request.PageSize = 20;
            }

            // Maximum page size
            if (request.PageSize > 500)
            {
                request.PageSize = 500;
            }

            // ========================================================
            // VALIDATE DATE RANGE
            // ========================================================
            if (request.FromDate.HasValue &&
                request.ToDate.HasValue &&
                request.FromDate.Value.Date >
                request.ToDate.Value.Date)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // NORMALIZE OPTIONAL STRING FILTERS
            // ========================================================
            if (!string.IsNullOrWhiteSpace(request.UserName))
            {
                request.UserName =
                    request.UserName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(request.RefNo))
            {
                request.RefNo =
                    request.RefNo.Trim();
            }

            // ========================================================
            // CALL REPOSITORY
            // ========================================================
            response.Result =
                await _repository.SearchPayinRequests(
                    request,
                    serviceUser);

            return response;
        }
    }
}
