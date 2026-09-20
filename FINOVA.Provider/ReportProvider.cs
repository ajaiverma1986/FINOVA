using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Report;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;


namespace FINOVA.Provider
{
   public class ReportProvider:BaseProvider
    {
        public readonly ReportRepository _repository = null;
        public ReportProvider() 
        {
            _repository = new ReportRepository();
        }
        // ============================================================
        // TRANSACTION DETAILS REPORT
        // FILTER + PAGING + SORTING
        // ============================================================
        public async Task<SimpleResponse> GetTransactionDetailsReport(
            TransactionReportRequest request,
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
            // PAGING DEFAULTS
            // ========================================================
            if (request.PageNumber <= 0)
            {
                request.PageNumber = 1;
            }

            if (request.PageSize <= 0)
            {
                request.PageSize = 20;
            }

            if (request.PageSize > 500)
            {
                request.PageSize = 500;
            }

            // ========================================================
            // DATE VALIDATION
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
            // AMOUNT VALIDATION
            // ========================================================
            if (request.MinAmount.HasValue &&
                request.MaxAmount.HasValue &&
                request.MinAmount.Value >
                request.MaxAmount.Value)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MinAmount.HasValue &&
                request.MinAmount.Value < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MaxAmount.HasValue &&
                request.MaxAmount.Value < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // NORMALIZE OPTIONAL STRING FILTERS
            // ========================================================
            request.UserName =
                string.IsNullOrWhiteSpace(request.UserName)
                    ? null
                    : request.UserName.Trim();

            request.TransactionCode =
                string.IsNullOrWhiteSpace(request.TransactionCode)
                    ? null
                    : request.TransactionCode.Trim();

            request.PartnerTxnId =
                string.IsNullOrWhiteSpace(request.PartnerTxnId)
                    ? null
                    : request.PartnerTxnId.Trim();

            request.PartnerRetailorId =
                string.IsNullOrWhiteSpace(request.PartnerRetailorId)
                    ? null
                    : request.PartnerRetailorId.Trim();

            request.RefNo =
                string.IsNullOrWhiteSpace(request.RefNo)
                    ? null
                    : request.RefNo.Trim();

            request.TxnType =
                string.IsNullOrWhiteSpace(request.TxnType)
                    ? null
                    : request.TxnType.Trim();

            request.TxnPlateform =
                string.IsNullOrWhiteSpace(request.TxnPlateform)
                    ? null
                    : request.TxnPlateform.Trim();

            // ========================================================
            // SORT COLUMN
            // ========================================================
            if (string.IsNullOrWhiteSpace(request.SortColumn))
            {
                request.SortColumn = "TransactionId";
            }
            else
            {
                request.SortColumn =
                    request.SortColumn.Trim();
            }

            // ========================================================
            // SORT DIRECTION
            // ========================================================
            if (string.IsNullOrWhiteSpace(request.SortDirection))
            {
                request.SortDirection = "DESC";
            }
            else
            {
                request.SortDirection =
                    request.SortDirection
                        .Trim()
                        .ToUpper();
            }

            if (request.SortDirection != "ASC" &&
                request.SortDirection != "DESC")
            {
                request.SortDirection = "DESC";
            }

            // ========================================================
            // CALL REPOSITORY
            // ========================================================
            response.Result =
                await _repository.GetTransactionDetailsReport(
                    request,
                    serviceUser);

            return response;
        }
        // ============================================================
        // GET USER DASHBOARD
        // ============================================================
        public async Task<SimpleResponse> GetUserDashboard(
            long userMasterId,
            DateTime? reportDate,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // VALIDATE USER
            // ========================================================
            if (userMasterId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // ========================================================
            // REMOVE TIME PORTION
            // ========================================================
            if (reportDate.HasValue)
            {
                reportDate =
                    reportDate.Value.Date;
            }

            // ========================================================
            // CALL REPOSITORY
            // ========================================================
            response.Result =
                await _repository.GetUserDashboard(
                    userMasterId,
                    reportDate,
                    serviceUser);

            return response;
        }
        // ============================================================
        // GET ADMIN DASHBOARD
        // ============================================================
        public async Task<SimpleResponse> GetAdminDashboard(
            AdminDashboardRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Invalid selected user
            if (request.UserMasterId.HasValue &&
                request.UserMasterId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Remove time component
            if (request.ReportDate.HasValue)
            {
                request.ReportDate =
                    request.ReportDate.Value.Date;
            }

            response.Result =
                await _repository.GetAdminDashboard(
                    request.UserMasterId,
                    request.ReportDate,
                    serviceUser);

            return response;
        }
        // ============================================================
        // USER DETAILS REPORT
        // ============================================================
        public async Task<SimpleResponse> GetUserDetailsReport(
            UserDetailsReportRequest request,
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
            // PAGING
            // ========================================================
            if (request.PageNumber <= 0)
            {
                request.PageNumber = 1;
            }

            if (request.PageSize <= 0)
            {
                request.PageSize = 20;
            }

            if (request.PageSize > 500)
            {
                request.PageSize = 500;
            }


            // ========================================================
            // DATE RANGE VALIDATION
            // ========================================================
            if (request.FromDate.HasValue &&
                request.ToDate.HasValue &&
                request.FromDate.Value.Date >
                request.ToDate.Value.Date)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.FromDate.HasValue)
            {
                request.FromDate =
                    request.FromDate.Value.Date;
            }

            if (request.ToDate.HasValue)
            {
                request.ToDate =
                    request.ToDate.Value.Date;
            }


            // ========================================================
            // AVAILABLE LIMIT VALIDATION
            // ========================================================
            if (request.MinAvailableLimit.HasValue &&
                request.MinAvailableLimit.Value < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MaxAvailableLimit.HasValue &&
                request.MaxAvailableLimit.Value < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MinAvailableLimit.HasValue &&
                request.MaxAvailableLimit.HasValue &&
                request.MinAvailableLimit.Value >
                request.MaxAvailableLimit.Value)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // VALIDATE IDs
            // ========================================================

            if (request.UserMasterId.HasValue &&
                request.UserMasterId.Value <= 0)
            {
                request.UserMasterId = null;
            }

            if (request.ParentId.HasValue &&
                request.ParentId.Value <= 0)
            {
                request.ParentId = null;
            }

            if (request.OrganizationId.HasValue &&
                request.OrganizationId.Value <= 0)
            {
                request.OrganizationId = null;
            }

            if (request.UserTypeId.HasValue &&
                request.UserTypeId.Value <= 0)
            {
                request.UserTypeId = null;
            }

            if (request.PlanId.HasValue &&
                request.PlanId.Value <= 0)
            {
                request.PlanId = null;
            }


            // ========================================================
            // NORMALIZE TEXT FILTERS
            // ========================================================

            request.UserName =
                string.IsNullOrWhiteSpace(request.UserName)
                    ? null
                    : request.UserName.Trim();

            request.Name =
                string.IsNullOrWhiteSpace(request.Name)
                    ? null
                    : request.Name.Trim();

            request.EmailId =
                string.IsNullOrWhiteSpace(request.EmailId)
                    ? null
                    : request.EmailId.Trim();

            request.MobileNo =
                string.IsNullOrWhiteSpace(request.MobileNo)
                    ? null
                    : request.MobileNo.Trim();

            request.PANCard =
                string.IsNullOrWhiteSpace(request.PANCard)
                    ? null
                    : request.PANCard.Trim();

            request.AadharCard =
                string.IsNullOrWhiteSpace(request.AadharCard)
                    ? null
                    : request.AadharCard.Trim();

            request.GSTNo =
                string.IsNullOrWhiteSpace(request.GSTNo)
                    ? null
                    : request.GSTNo.Trim();


            // ========================================================
            // SORT COLUMN
            // ========================================================

            if (string.IsNullOrWhiteSpace(request.SortColumn))
            {
                request.SortColumn = "CreatedOn";
            }
            else
            {
                request.SortColumn =
                    request.SortColumn.Trim();
            }


            // ========================================================
            // SORT DIRECTION
            // ========================================================

            if (string.IsNullOrWhiteSpace(request.SortDirection))
            {
                request.SortDirection = "DESC";
            }
            else
            {
                request.SortDirection =
                    request.SortDirection
                        .Trim()
                        .ToUpper();
            }

            if (request.SortDirection != "ASC" &&
                request.SortDirection != "DESC")
            {
                request.SortDirection = "DESC";
            }


            // ========================================================
            // CALL REPOSITORY
            // ========================================================

            response.Result =
                await _repository.GetUserDetailsReport(
                    request,
                    serviceUser);

            return response;
        }
    }
}
