using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.Wallet;
using FINOVA.Repository.Shared;


namespace FINOVA.Repository
{
   public class WalletRepository:BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public WalletRepository()
        {
            _database = new FINOVADatabase();
        }
        // ============================================================
        // CREATE COMPANY ACCOUNT
        // ============================================================
        public async Task<long> CreateCompanyAccount(
            CreateCompanyAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                request.OrganizationId);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationId",
                request.ApplicationId);

            _database.AddInParameter(
                dbCommand,
                "@BankId",
                request.BankId);

            _database.AddInParameter(
                dbCommand,
                "@AccountType",
                request.AccountType);

            _database.AddInParameter(
                dbCommand,
                "@AccountName",
                request.AccountName);

            _database.AddInParameter(
                dbCommand,
                "@AccountNo",
                request.AccountNo);

            _database.AddInParameter(
                dbCommand,
                "@Ifsccode",
                request.Ifsccode);

            _database.AddInParameter(
                dbCommand,
                "@BranchName",
                request.BranchName);

            _database.AddInParameter(
                dbCommand,
                "@BranchCode",
                request.BranchCode);

            _database.AddInParameter(
                dbCommand,
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@FileURL",
                request.FileURL);

            _database.AddInParameter(
                dbCommand,
                "@Remarks",
                request.Remarks);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID = GetIDOutputLong(dbCommand);

            return outputID;
        }


        // ============================================================
        // UPDATE COMPANY ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> UpdateCompanyAccount(
            UpdateCompanyAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@CompanyAccountId",
                request.CompanyAccountId);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                request.OrganizationId);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationId",
                request.ApplicationId);

            _database.AddInParameter(
                dbCommand,
                "@BankId",
                request.BankId);

            _database.AddInParameter(
                dbCommand,
                "@AccountType",
                request.AccountType);

            _database.AddInParameter(
                dbCommand,
                "@AccountName",
                request.AccountName);

            _database.AddInParameter(
                dbCommand,
                "@AccountNo",
                request.AccountNo);

            _database.AddInParameter(
                dbCommand,
                "@Ifsccode",
                request.Ifsccode);

            _database.AddInParameter(
                dbCommand,
                "@BranchName",
                request.BranchName);

            _database.AddInParameter(
                dbCommand,
                "@BranchCode",
                request.BranchCode);

            _database.AddInParameter(
                dbCommand,
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@FileURL",
                request.FileURL);

            _database.AddInParameter(
                dbCommand,
                "@Remarks",
                request.Remarks);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@CompanyAccountId",
                companyAccountId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNT BY ID
        // ============================================================
        public async Task<GetCompanyAccountResponse?> GetCompanyAccountByID(
            long companyAccountId,
            IFINOVAServiceUser serviceUser)
        {
            GetCompanyAccountResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@CompanyAccountId",
                companyAccountId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapCompanyAccount(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL COMPANY ACCOUNTS
        // ============================================================
        public async Task<List<GetCompanyAccountResponse>>
            GetAllCompanyAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyAccountResponse> response =
                new List<GetCompanyAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE COMPANY ACCOUNTS
        // ============================================================
        public async Task<List<GetCompanyAccountResponse>>
            GetActiveCompanyAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyAccountResponse> response =
                new List<GetCompanyAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION ID
        // ============================================================
        public async Task<List<GetCompanyAccountResponse>>
            GetCompanyAccountsByOrganizationId(
                int organizationId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyAccountResponse> response =
                new List<GetCompanyAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetByOrganizationId]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                organizationId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY APPLICATION ID
        // ============================================================
        public async Task<List<GetCompanyAccountResponse>>
            GetCompanyAccountsByApplicationId(
                int applicationId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyAccountResponse> response =
                new List<GetCompanyAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetByApplicationId]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationId",
                applicationId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET COMPANY ACCOUNTS BY ORGANIZATION + APPLICATION
        // ============================================================
        public async Task<List<GetCompanyAccountResponse>>
            GetCompanyAccountsByOrganizationApplication(
                int organizationId,
                int applicationId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyAccountResponse> response =
                new List<GetCompanyAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyAccountMaster_GetByOrganizationApplication]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationId",
                organizationId);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationId",
                applicationId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyAccount(dataReader));
                }
            }

            return response;
        }
        private GetCompanyAccountResponse MapCompanyAccount(
    System.Data.IDataReader dataReader)
        {
            GetCompanyAccountResponse row =
                new GetCompanyAccountResponse();

            row.CompanyAccountId =
                GetInt64Value(
                    dataReader,
                    "CompanyAccountId").Value;

            row.OrganizationId =
                GetInt32Value(
                    dataReader,
                    "OrganizationId").Value;

            row.ApplicationId =
                GetInt32Value(
                    dataReader,
                    "ApplicationId").Value;

            row.BankId =
                GetInt32Value(
                    dataReader,
                    "BankId").Value;

            row.BankName =
                GetStringValue(
                    dataReader,
                    "BankName");

            row.AccountType =
                GetStringValue(
                    dataReader,
                    "AccountType");

            row.AccountName =
                GetStringValue(
                    dataReader,
                    "AccountName");

            row.AccountNo =
                GetStringValue(
                    dataReader,
                    "AccountNo");

            row.Ifsccode =
                GetStringValue(
                    dataReader,
                    "Ifsccode");

            row.BranchName =
                GetStringValue(
                    dataReader,
                    "BranchName");

            row.BranchCode =
                GetStringValue(
                    dataReader,
                    "BranchCode");

            row.BranchAddress =
                GetStringValue(
                    dataReader,
                    "BranchAddress");

            row.FileURL =
                GetStringValue(
                    dataReader,
                    "FileURL");

            row.Remarks =
                GetStringValue(
                    dataReader,
                    "Remarks");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                GetDateTimeValue(
                    dataReader,
                    "CreatedOn");

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                GetDateTimeValue(
                    dataReader,
                    "UpdatedOn");

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // CREATE PAYIN REQUEST
        // ============================================================
        public async Task<long> CreatePayinRequest(
            CreatePayinRequestRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                request.PaymentChanelID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeId",
                request.PaymentModeId);

            _database.AddInParameter(
                dbCommand,
                "@Amount",
                request.Amount);

            _database.AddInParameter(
                dbCommand,
                "@Charge",
                request.Charge);

            _database.AddInParameter(
                dbCommand,
                "@OriginatorAccountId",
                request.OriginatorAccountId);

            _database.AddInParameter(
                dbCommand,
                "@BenficiaryAccountId",
                request.BenficiaryAccountId);

            _database.AddInParameter(
                dbCommand,
                "@DepositDate",
                request.DepositDate);

            _database.AddInParameter(
                dbCommand,
                "@RefNo1",
                request.RefNo1);

            _database.AddInParameter(
                dbCommand,
                "@RefNo2",
                request.RefNo2);

            _database.AddInParameter(
                dbCommand,
                "@Remarks",
                request.Remarks);

            _database.AddInParameter(
                dbCommand,
                "@RecieptFileurl",
                request.RecieptFileurl);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID =
                GetIDOutputLong(dbCommand);

            return outputID;
        }
        // ============================================================
        // APPROVE / REJECT PAYIN REQUEST
        // ============================================================
        public async Task<SimpleResponse> ApproveRejectPayinRequest(
            ApproveRejectPayinRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response =
                new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_ApproveReject]");

            _database.AddInParameter(
                dbCommand,
                "@RequestID",
                request.RequestID);

            _database.AddInParameter(
                dbCommand,
                "@Action",
                request.Action);

            _database.AddInParameter(
                dbCommand,
                "@RejectedReason",
                request.RejectedReason);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(
                dbCommand);

            response.Result = 1;

            return response;
        }
        // ============================================================
        // GET PAYIN REQUEST BY ID
        // ============================================================
        public async Task<GetPayinRequestResponse?> GetPayinRequestByID(
            long requestID,
            IFINOVAServiceUser serviceUser)
        {
            GetPayinRequestResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@RequestID",
                requestID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapPayinRequest(dataReader);
                }
            }

            return response;
        }
        // ============================================================
        // GET ALL PAYIN REQUESTS
        // ============================================================
        public async Task<List<GetPayinRequestResponse>>
            GetAllPayinRequests(
                IFINOVAServiceUser serviceUser)
        {
            List<GetPayinRequestResponse> response =
                new List<GetPayinRequestResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPayinRequest(dataReader));
                }
            }

            return response;
        }
       
        // ============================================================
        // GET PAYIN REQUESTS BY USER
        // ============================================================
        public async Task<List<GetPayinRequestResponse>>
            GetPayinRequestsByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetPayinRequestResponse> response =
                new List<GetPayinRequestResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_GetByUserMasterID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                userMasterId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPayinRequest(dataReader));
                }
            }

            return response;
        }
        // ============================================================
        // GET PAYIN REQUESTS BY STATUS
        // ============================================================
        public async Task<List<GetPayinRequestResponse>>
            GetPayinRequestsByStatus(
                int status,
                IFINOVAServiceUser serviceUser)
        {
            List<GetPayinRequestResponse> response =
                new List<GetPayinRequestResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_GetByStatus]");

            _database.AddInParameter(
                dbCommand,
                "@Status",
                status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPayinRequest(dataReader));
                }
            }

            return response;
        }
        private GetPayinRequestResponse MapPayinRequest(
    System.Data.IDataReader dataReader)
        {
            GetPayinRequestResponse row =
                new GetPayinRequestResponse();

            row.RequestID =
                GetInt64Value(
                    dataReader,
                    "RequestID").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId").Value;

            row.PaymentChanelID =
                GetInt32Value(
                    dataReader,
                    "PaymentChanelID").Value;

            row.PaymentModeId =
                GetInt32Value(
                    dataReader,
                    "PaymentModeId").Value;

            row.Amount =
                dataReader["Amount"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["Amount"]);

            row.Charge =
                dataReader["Charge"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["Charge"]);

            row.OriginatorAccountId =
                GetInt64Value(
                    dataReader,
                    "OriginatorAccountId");

            row.BenficiaryAccountId =
                GetInt64Value(
                    dataReader,
                    "BenficiaryAccountId");

            row.DepositDate =
                GetDateTimeValue(
                    dataReader,
                    "DepositDate");

            row.RefNo1 =
                GetStringValue(
                    dataReader,
                    "RefNo1");

            row.RefNo2 =
                GetStringValue(
                    dataReader,
                    "RefNo2");

            row.Remarks =
                GetStringValue(
                    dataReader,
                    "Remarks");

            row.RecieptFileurl =
                GetStringValue(
                    dataReader,
                    "RecieptFileurl");

            row.RejectedReason =
                GetStringValue(
                    dataReader,
                    "RejectedReason");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                GetDateTimeValue(
                    dataReader,
                    "CreatedOn");

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                GetDateTimeValue(
                    dataReader,
                    "UpdatedOn");

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // SEARCH PAYIN REQUEST WITH FILTERS + PAGING
        // ============================================================
        public async Task<SearchPayinResponsemain> SearchPayinRequests(
            SearchPayinRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SearchPayinResponsemain response =
                new SearchPayinResponsemain();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[TXN].[PayinRequest_Search]");

            // ========================================================
            // FILTER PARAMETERS
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                request.PaymentChanelID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeId",
                request.PaymentModeId);

            _database.AddInParameter(
                dbCommand,
                "@RequestID",
                request.RequestID);

            _database.AddInParameter(
                dbCommand,
                "@RefNo",
                request.RefNo);

            _database.AddInParameter(
                dbCommand,
                "@FromDate",
                request.FromDate);

            _database.AddInParameter(
                dbCommand,
                "@ToDate",
                request.ToDate);


            // ========================================================
            // PAGING
            // ========================================================

            _database.AddInParameter(
                dbCommand,
                "@PageNumber",
                request.PageNumber);

            _database.AddInParameter(
                dbCommand,
                "@PageSize",
                request.PageSize);


            // ========================================================
            // EXECUTE
            // ========================================================

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                // ====================================================
                // RESULT SET 1
                // PAYIN REQUEST RECORDS
                // ====================================================

                while (dataReader.Read())
                {
                    response.Records.Add(
                        MapSearchPayinRequestall(dataReader));
                }


                // ====================================================
                // RESULT SET 2
                // PAGING INFORMATION
                // ====================================================

                if (dataReader.NextResult())
                {
                    if (dataReader.Read())
                    {
                        response.Paging.TotalRecords =
                            GetInt64Value(
                                dataReader,
                                "TotalRecords").Value;

                        response.Paging.TotalPages =
                            GetInt32Value(
                                dataReader,
                                "TotalPages").Value;

                        response.Paging.PageNumber =
                            GetInt32Value(
                                dataReader,
                                "PageNumber").Value;

                        response.Paging.PageSize =
                            GetInt32Value(
                                dataReader,
                                "PageSize").Value;

                        response.Paging.HasNextPage =
                            dataReader["HasNextPage"] != DBNull.Value
                            &&
                            Convert.ToBoolean(
                                dataReader["HasNextPage"]);

                        response.Paging.HasPreviousPage =
                            dataReader["HasPreviousPage"] != DBNull.Value
                            &&
                            Convert.ToBoolean(
                                dataReader["HasPreviousPage"]);
                    }
                }
            }

            return response;
        }
        private GetPayinRequestResponseall MapSearchPayinRequestall(System.Data.IDataReader dataReader)
        {
            GetPayinRequestResponseall row =
                new GetPayinRequestResponseall();

            // ========================================================
            // REQUEST
            // ========================================================

            row.RequestID =
                GetInt64Value(
                    dataReader,
                    "RequestID").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId").Value;

            row.UserName =
                GetStringValue(
                    dataReader,
                    "UserName");


            // ========================================================
            // PAYMENT CHANNEL
            // ========================================================

            row.PaymentChanelID =
                GetInt32Value(
                    dataReader,
                    "PaymentChanelID").Value;

            row.PaymentChanelName =
                GetStringValue(
                    dataReader,
                    "PaymentChanelName");


            // ========================================================
            // PAYMENT MODE
            // ========================================================

            row.PaymentModeId =
                GetInt32Value(
                    dataReader,
                    "PaymentModeId").Value;

            row.PaymentModeName =
                GetStringValue(
                    dataReader,
                    "PaymentModeName");


            // ========================================================
            // AMOUNT
            // ========================================================

            row.Amount =
                dataReader["Amount"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["Amount"]);

            row.Charge =
                dataReader["Charge"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["Charge"]);


            // ========================================================
            // USER BANK ACCOUNT
            // ========================================================

            row.OriginatorAccountId =
                GetInt64Value(
                    dataReader,
                    "OriginatorAccountId");

            row.UserAccountName =
                GetStringValue(
                    dataReader,
                    "UserAccountName");

            row.UserAccountNo =
                GetStringValue(
                    dataReader,
                    "UserAccountNo");

            row.UserIfsccode =
                GetStringValue(
                    dataReader,
                    "UserIfsccode");


            // ========================================================
            // COMPANY ACCOUNT
            // ========================================================

            row.BenficiaryAccountId =
                GetInt64Value(
                    dataReader,
                    "BenficiaryAccountId");

            row.CompanyAccountName =
                GetStringValue(
                    dataReader,
                    "CompanyAccountName");

            row.CompanyAccountNo =
                GetStringValue(
                    dataReader,
                    "CompanyAccountNo");

            row.CompanyIfsccode =
                GetStringValue(
                    dataReader,
                    "CompanyIfsccode");


            // ========================================================
            // DEPOSIT / REFERENCES
            // ========================================================

            row.DepositDate =
                GetDateTimeValue(
                    dataReader,
                    "DepositDate");

            row.RefNo1 =
                GetStringValue(
                    dataReader,
                    "RefNo1");

            row.RefNo2 =
                GetStringValue(
                    dataReader,
                    "RefNo2");


            // ========================================================
            // OTHER DETAILS
            // ========================================================

            row.Remarks =
                GetStringValue(
                    dataReader,
                    "Remarks");

            row.RecieptFileurl =
                GetStringValue(
                    dataReader,
                    "RecieptFileurl");

            row.RejectedReason =
                GetStringValue(
                    dataReader,
                    "RejectedReason");


            // ========================================================
            // STATUS
            // ========================================================

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");


            // ========================================================
            // CREATED
            // ========================================================

            row.CreatedOn =
                GetDateTimeValue(
                    dataReader,
                    "CreatedOn");

            row.CreatedByID =
                GetInt64Value(
                    dataReader,
                    "CreatedByID").Value;

            row.CreatedBy =
                GetStringValue(
                    dataReader,
                    "CreatedBy");


            // ========================================================
            // UPDATED
            // ========================================================

            row.UpdatedOn =
                GetDateTimeValue(
                    dataReader,
                    "UpdatedOn");

            row.UpdatedByID =
                GetInt64Value(
                    dataReader,
                    "UpdatedByID");

            row.UpdatedBy =
                GetStringValue(
                    dataReader,
                    "UpdatedBy");

            return row;
        }

    }
}
