using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Repository.Shared;


namespace FINOVA.Repository
{
    public class ConfigRepository : BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public ConfigRepository()
        {
            _database = new FINOVADatabase();
        }
        public async Task<SimpleResponse> GetAllCalculationTypeMaster()
        {
            SimpleResponse response = new SimpleResponse();
            List<CalculationMasterResponse> objMaster = new List<CalculationMasterResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListCalculationTypeMaster");

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    CalculationMasterResponse obj = new CalculationMasterResponse();

                    obj.CalculationTypeId = GetInt32Value(dataReader, "CalculationTypeId").Value;
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.CalculationTypeName = GetStringValue(dataReader, "CalculationTypeName");
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<SimpleResponse> GetAllChargeDeductionType()
        {
            SimpleResponse response = new SimpleResponse();
            List<ChargedeductionTypeListResponse> objMaster = new List<ChargedeductionTypeListResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListChargeDeductionType");

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    ChargedeductionTypeListResponse obj = new ChargedeductionTypeListResponse();

                    obj.ChargeDeductionId = GetInt32Value(dataReader, "ChargeDeductionId").Value;
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.ChargeDeductionType = GetStringValue(dataReader, "ChargeDeductionType");
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<SimpleResponse> GetallPlanList(int? PlanID)
        {
            SimpleResponse response = new SimpleResponse();
            List<PlanMasterListDataResponse> objMaster = new List<PlanMasterListDataResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListPlanMaster");
            _database.AddInParameter(dbCommand, "@PlanID", PlanID);
            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    PlanMasterListDataResponse obj = new PlanMasterListDataResponse();

                    obj.PlanId = GetInt32Value(dataReader, "PlanId").Value;
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.PlanCode = GetStringValue(dataReader, "PlanCode");
                    obj.PlanName = GetStringValue(dataReader, "PlanName");
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<SimpleResponse> GetallSlabType()
        {
            SimpleResponse response = new SimpleResponse();
            List<SlabTypeListResponse> objMaster = new List<SlabTypeListResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListSlabTypeMAster");

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    SlabTypeListResponse obj = new SlabTypeListResponse();

                    obj.SlabTypId = GetInt32Value(dataReader, "SlabTypId").Value;
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.SlabTypeName = GetStringValue(dataReader, "SlabTypeName");

                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<SimpleResponse> GetallCommissionDistribution(CommissionDistributionRequest request)
        {
            SimpleResponse response = new SimpleResponse();
            List<CommissionDistributionResponse> objMaster = new List<CommissionDistributionResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].Usp_listCommissionDistribution");
            _database.AddInParameter(dbCommand, "@AgencyId", request.AgencyId);
            _database.AddInParameter(dbCommand, "@ServiceId", request.ServiceId);
            _database.AddInParameter(dbCommand, "@PlanId", request.PlanId);
            _database.AddInParameter(dbCommand, "@CalculationTypeId", request.CalculationTypeId);
            _database.AddInParameter(dbCommand, "@amount", request.amount);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    CommissionDistributionResponse obj = new CommissionDistributionResponse();
                    obj.MarginConfigrationID = GetInt32Value(dataReader, "MarginConfigrationID").Value;
                    obj.PlanId = GetInt32Value(dataReader, "PlanId").Value;
                    obj.AgencyId = GetInt32Value(dataReader, "AgencyId").Value;
                    obj.ServiceId = GetInt32Value(dataReader, "ServiceId").Value;
                    obj.CalculationTypeId = GetInt32Value(dataReader, "CalculationTypeId").Value;
                    obj.FromAmount = GetDecimalValue(dataReader, "FromAmount").Value;
                    obj.Toamount = GetDecimalValue(dataReader, "Toamount").Value;
                    obj.CalculationValue = GetDecimalValue(dataReader, "CalculationValue").Value;
                    obj.AgencyName = GetStringValue(dataReader, "AgencyName");
                    obj.ServiceName = GetStringValue(dataReader, "ServiceName");
                    obj.CalculationTypeName = GetStringValue(dataReader, "CalculationTypeName");
                    obj.PlanName = GetStringValue(dataReader, "PlanName");
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }

        public async Task<SimpleResponse> GetAllTopupCharge(TopupChargeRequest request)
        {
            SimpleResponse response = new SimpleResponse();
            List<TopupChargeResponse> objMaster = new List<TopupChargeResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListTopupCharge");
            _database.AddInParameter(dbCommand, "@TopupChargeId", request.TopupChargeId);
            _database.AddInParameter(dbCommand, "@SlabTypeId", request.SlabTypeId);
            _database.AddInParameter(dbCommand, "@CalculationTypeId", request.CalculationTypeId);
            _database.AddInParameter(dbCommand, "@Amount", request.Amount);


            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    TopupChargeResponse obj = new TopupChargeResponse();
                    obj.TopupChargeId = GetInt32Value(dataReader, "TopupChargeId").Value;
                    obj.SlabTypeId = GetInt32Value(dataReader, "SlabTypeId").Value;
                    obj.CalculationTypeId = GetInt32Value(dataReader, "CalculationTypeId").Value;
                    obj.FromAmount = GetDecimalValue(dataReader, "FromAmount").Value;
                    obj.Toamount = GetDecimalValue(dataReader, "Toamount").Value;
                    obj.CalculationValue = GetDecimalValue(dataReader, "CalculationValue").Value;
                    obj.CalculationTypeName = GetStringValue(dataReader, "CalculationTypeName");
                    obj.SlabTypeName = GetStringValue(dataReader, "SlabTypeName");
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }

        public async Task<SimpleResponse> GetallTransactionSlab(TransactionslabRequest request)
        {
            SimpleResponse response = new SimpleResponse();
            List<TransactionslabResponse> objMaster = new List<TransactionslabResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListTransactionslab");
            _database.AddInParameter(dbCommand, "@SlabId", request.SlabId);
            _database.AddInParameter(dbCommand, "@SlabType", request.SlabType);
            _database.AddInParameter(dbCommand, "@CalculationType", request.CalculationType);
            _database.AddInParameter(dbCommand, "@AgencyID", request.AgencyID);
            _database.AddInParameter(dbCommand, "@ServiceID", request.ServiceID);
            _database.AddInParameter(dbCommand, "@Amount", request.Amount);
            _database.AddInParameter(dbCommand, "@PlanId", request.PlanId);


            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    TransactionslabResponse obj = new TransactionslabResponse();
                    obj.SlabId = GetInt32Value(dataReader, "SlabId").Value;
                    obj.PlanId = GetInt32Value(dataReader, "PlanId").Value;
                    obj.SlabType = GetInt32Value(dataReader, "SlabType").Value;
                    obj.CalculationType = GetInt32Value(dataReader, "CalculationType").Value;
                    obj.AgencyID = GetInt32Value(dataReader, "AgencyID").Value;
                    obj.ServiceID = GetInt32Value(dataReader, "ServiceID").Value;
                    obj.FromAmount = GetDecimalValue(dataReader, "FromAmount").Value;
                    obj.Toamount = GetDecimalValue(dataReader, "Toamount").Value;
                    obj.CalculationValue = GetDecimalValue(dataReader, "CalculationValue").Value;
                    obj.CalculationTypeName = GetStringValue(dataReader, "CalculationTypeName");
                    obj.SlabTypeName = GetStringValue(dataReader, "SlabTypeName");
                    obj.PlanName = GetStringValue(dataReader, "PlanName");
                    obj.ServiceName = GetStringValue(dataReader, "ServiceName");
                    obj.AgencyName = GetStringValue(dataReader, "AgencyName");
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.StatusName = GetStringValue(dataReader, "StatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }

        public async Task<SimpleResponse> GetAllPaymentAccounts(int? Bankid)
        {
            SimpleResponse response = new SimpleResponse();
            List<PaymentAccountsListResponse> objMaster = new List<PaymentAccountsListResponse>();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListPaymentAccountMaster");
            _database.AddInParameter(dbCommand, "@BankID", Bankid);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    PaymentAccountsListResponse obj = new PaymentAccountsListResponse();
                    obj.PaymentAccountID = GetInt32Value(dataReader, "PaymentAccountID").Value;
                    obj.AccountName = GetStringValue(dataReader, "AccountName");
                    obj.Status = GetInt32Value(dataReader, "Status").Value;
                    obj.BankID = GetInt32Value(dataReader, "BankID").Value;
                    obj.StatusName = GetStringValue(dataReader, "StatusName");
                    obj.CreatedBy = GetStringValue(dataReader, "CreatedBy");
                    obj.UpdatedBy = GetStringValue(dataReader, "UpdatedBy");
                    obj.AccountNo = GetStringValue(dataReader, "AccountNo");
                    obj.BankName = GetStringValue(dataReader, "BankName");
                    obj.BranchName = GetStringValue(dataReader, "BranchName");
                    obj.Branchcode = GetStringValue(dataReader, "Branchcode");
                    obj.Ifsccode = GetStringValue(dataReader, "Ifsccode");
                    obj.BranchAddress = GetStringValue(dataReader, "BranchAddress");
                    obj.Micrcode = GetStringValue(dataReader, "Micrcode");
                    obj.CreatedOn = GetDateValue(dataReader, "CreatedOn").Value;


                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }

        public async Task<long> AddPaymentAccounts(AddPaymentAccountMasterRequest request, IFINOVAServiceUser serviceUser)
        {

            long outputstr = 0;
            SimpleResponse response = new SimpleResponse();
            var dbCommand = _database.GetStoredProcCommand("[CONFG].AddPaymentAccountMaster");
            _database.AddInParameter(dbCommand, "@BankID", request.BankID);
            _database.AddInParameter(dbCommand, "@AccountName", request.AccountName);
            _database.AddInParameter(dbCommand, "@AccountNo", request.AccountNo);
            _database.AddInParameter(dbCommand, "@Ifsccode", request.Ifsccode);
            _database.AddInParameter(dbCommand, "@BranchName", request.BranchName);
            _database.AddInParameter(dbCommand, "@CreatedBy", serviceUser.UserMasterID);
            _database.AddInParameter(dbCommand, "@Branchcode", request.Branchcode);
            _database.AddInParameter(dbCommand, "@Micrcode", request.Micrcode);
            _database.AddInParameter(dbCommand, "@BranchAddress", request.BranchAddress);
            _database.AddOutParameter(dbCommand, "@Out_ID", 100);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputstr = GetIDOutputLong(dbCommand);

            return outputstr;

        }

        public async Task<long> changesPaymentAccountsStatus(ChangePaymentAccStatusRequest request, IFINOVAServiceUser serviceUser)
        {

            long outputstr = 0;
            SimpleResponse response = new SimpleResponse();
            var dbCommand = _database.GetStoredProcCommand("[CONFG].ChangePaymentAccountsStatus");
            _database.AddInParameter(dbCommand, "@PaymentAccountID", request.PaymentAccountID);
            _database.AddInParameter(dbCommand, "@Status", request.Status);
            _database.AddOutParameter(dbCommand, "@Out_ID", 100);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputstr = GetIDOutputLong(dbCommand);

            return outputstr;

        }
        
        public async Task<SimpleResponse> GetServicePolicy(GetServicePolicyRequest request)
        {
            SimpleResponse response = new SimpleResponse();
            GetservicePolicyResponse objMaster = new GetservicePolicyResponse();

            var dbCommand = _database.GetStoredProcCommand("[CONFG].ListServicePolicy");
            _database.AddInParameter(dbCommand, "@ServiceId", request.ServiceId);
            _database.AddInParameter(dbCommand, "@Agencyid", request.Agencyid);
            _database.AddInParameter(dbCommand, "@PolicyId", request.PolicyId);
            _database.AddInParameter(dbCommand, "@PolicyKey", request.PolicyKey);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {

                    objMaster.SysPolicyId = GetInt32Value(dataReader, "SysPolicyId").Value;
                    objMaster.PolicyKey = GetStringValue(dataReader, "PolicyKey");
                    objMaster.PolicyValue = GetStringValue(dataReader, "PolicyValue");

                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<long> AddTransactionslab(AddTxnslabRequest request, IFINOVAServiceUser serviceUser)
        {

            long outputstr = 0;
            SimpleResponse response = new SimpleResponse();
            var dbCommand = _database.GetStoredProcCommand("[CONFG].AddTransactionSlab");
            _database.AddInParameter(dbCommand, "@PlanId", request.PlanId);
            _database.AddInParameter(dbCommand, "@AgencyID", request.AgencyID);
            _database.AddInParameter(dbCommand, "@ServiceID", request.ServiceID);
            _database.AddInParameter(dbCommand, "@FromAmount", request.FromAmount);
            _database.AddInParameter(dbCommand, "@ToAmount", request.ToAmount);
            _database.AddInParameter(dbCommand, "@SlabType", request.SlabType);
            _database.AddInParameter(dbCommand, "@CalculationType", request.CalculationType);
            _database.AddInParameter(dbCommand, "@CalculationValue", request.CalculationValue);
            _database.AddInParameter(dbCommand, "@CreatedBy", serviceUser.UserMasterID);
            _database.AddOutParameter(dbCommand, "@Out_ID", 100);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputstr = GetIDOutputLong(dbCommand);

            return outputstr;

        }
        // ============================================================
        // TOPUP CHARGE - CREATE
        // ============================================================
        public async Task<long> CreateTopupCharge(
            CreateTopupChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@Toamount",
                request.Toamount);

            _database.AddInParameter(
                dbCommand,
                "@SlabTypeId",
                request.SlabTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

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
        // TOPUP CHARGE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTopupCharge(
            UpdateTopupChargeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@TopupChargeId",
                request.TopupChargeId);

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@Toamount",
                request.Toamount);

            _database.AddInParameter(
                dbCommand,
                "@SlabTypeId",
                request.SlabTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@TopupChargeId",
                topupChargeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY ID
        // ============================================================
        public async Task<GetTopupChargeResponse?> GetTopupChargeByID(
            int topupChargeId,
            IFINOVAServiceUser serviceUser)
        {
            GetTopupChargeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@TopupChargeId",
                topupChargeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapTopupCharge(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET ALL
        // ============================================================
        public async Task<List<GetTopupChargeResponse>>
            GetAllTopupCharges(
                IFINOVAServiceUser serviceUser)
        {
            List<GetTopupChargeResponse> response =
                new List<GetTopupChargeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTopupCharge(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET ACTIVE
        // ============================================================
        public async Task<List<GetTopupChargeResponse>>
            GetActiveTopupCharges(
                IFINOVAServiceUser serviceUser)
        {
            List<GetTopupChargeResponse> response =
                new List<GetTopupChargeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTopupCharge(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY SLAB TYPE ID
        // ============================================================
        public async Task<List<GetTopupChargeResponse>>
            GetTopupChargesBySlabTypeID(
                int slabTypeId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTopupChargeResponse> response =
                new List<GetTopupChargeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_GetBySlabTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@SlabTypeId",
                slabTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTopupCharge(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TOPUP CHARGE - GET BY CALCULATION TYPE ID
        // ============================================================
        public async Task<List<GetTopupChargeResponse>>
            GetTopupChargesByCalculationTypeID(
                int calculationTypeId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTopupChargeResponse> response =
                new List<GetTopupChargeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TopupChargeMaster_GetByCalculationTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                calculationTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTopupCharge(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON TOPUP CHARGE MAPPER
        // ============================================================
        private GetTopupChargeResponse MapTopupCharge(
            System.Data.IDataReader dataReader)
        {
            GetTopupChargeResponse row =
                new GetTopupChargeResponse();

            row.TopupChargeId =
                GetInt32Value(
                    dataReader,
                    "TopupChargeId").Value;

            row.FromAmount =
                dataReader["FromAmount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(dataReader["FromAmount"]);

            row.Toamount =
                dataReader["Toamount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(dataReader["Toamount"]);

            row.SlabTypeId =
                GetInt32Value(
                    dataReader,
                    "SlabTypeId");

            row.SlabTypeName =
                GetStringValue(
                    dataReader,
                    "SlabTypeName");

            row.CalculationTypeId =
                GetInt32Value(
                    dataReader,
                    "CalculationTypeId");

            row.CalculationValue =
                dataReader["CalculationValue"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(dataReader["CalculationValue"]);

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
                    "CreatedBy");

            return row;
        }
        // ============================================================
        // COMMISSION DISTRIBUTION - CREATE
        // ============================================================
        public async Task<long> CreateCommissionDistribution(
            CreateCommissionDistributionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                request.ServiceId);

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@Toamount",
                request.Toamount);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

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
        // COMMISSION DISTRIBUTION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateCommissionDistribution(
            UpdateCommissionDistributionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@MarginConfigrationID",
                request.MarginConfigrationID);

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                request.ServiceId);

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@Toamount",
                request.Toamount);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@MarginConfigrationID",
                marginConfigrationID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY ID
        // ============================================================
        public async Task<GetCommissionDistributionResponse?>
            GetCommissionDistributionByID(
                long marginConfigrationID,
                IFINOVAServiceUser serviceUser)
        {
            GetCommissionDistributionResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@MarginConfigrationID",
                marginConfigrationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapCommissionDistribution(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ALL
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetAllCommissionDistributions(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET ACTIVE
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetActiveCommissionDistributions(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY ID
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetCommissionDistributionsByAgencyID(
                int agencyId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetByAgencyID]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                agencyId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY SERVICE ID
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetCommissionDistributionsByServiceID(
                int serviceId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetByServiceID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                serviceId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY PLAN ID
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetCommissionDistributionsByPlanID(
                int planId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetByPlanID]");

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                planId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMISSION DISTRIBUTION - GET BY AGENCY + SERVICE
        // ============================================================
        public async Task<List<GetCommissionDistributionResponse>>
            GetCommissionDistributionsByAgencyService(
                int agencyId,
                int serviceId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetCommissionDistributionResponse> response =
                new List<GetCommissionDistributionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CommissiondistributionMaster_GetByAgencyService]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                agencyId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                serviceId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCommissionDistribution(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON COMMISSION DISTRIBUTION MAPPER
        // ============================================================
        private GetCommissionDistributionResponse MapCommissionDistribution(
            System.Data.IDataReader dataReader)
        {
            GetCommissionDistributionResponse row =
                new GetCommissionDistributionResponse();

            row.MarginConfigrationID =
                GetInt64Value(
                    dataReader,
                    "MarginConfigrationID").Value;

            row.AgencyId =
                GetInt32Value(
                    dataReader,
                    "AgencyId").Value;

            row.AgencyName =
                GetStringValue(
                    dataReader,
                    "AgencyName");

            row.ServiceId =
                GetInt32Value(
                    dataReader,
                    "ServiceId").Value;

            row.ServiceName =
                GetStringValue(
                    dataReader,
                    "ServiceName");

            row.PlanId =
                GetInt32Value(
                    dataReader,
                    "PlanId");

            row.PlanName =
                GetStringValue(
                    dataReader,
                    "PlanName");

            row.FromAmount =
                dataReader["FromAmount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(dataReader["FromAmount"]);

            row.Toamount =
                dataReader["Toamount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(dataReader["Toamount"]);

            row.CalculationTypeId =
                GetInt32Value(
                    dataReader,
                    "CalculationTypeId");

            row.CalculationTypeName =
                GetStringValue(
                    dataReader,
                    "CalculationTypeName");

            row.CalculationValue =
                dataReader["CalculationValue"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(
                        dataReader["CalculationValue"]);

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

            return row;
        }
        // ============================================================
        // CREATE TRANSACTION SLAB
        // ============================================================
        public async Task<long> CreateTransactionSlab(
            CreateTransactionSlabRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@AgencyID",
                request.AgencyID);

            _database.AddInParameter(
                dbCommand,
                "@ServiceID",
                request.ServiceID);

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@ToAmount",
                request.ToAmount);

            _database.AddInParameter(
                dbCommand,
                "@SlabType",
                request.SlabType);

            _database.AddInParameter(
                dbCommand,
                "@CalculationType",
                request.CalculationType);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

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
        // UPDATE TRANSACTION SLAB
        // ============================================================
        public async Task<SimpleResponse> UpdateTransactionSlab(
            UpdateTransactionSlabRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_Update]");

            _database.AddInParameter(
                dbCommand,
                "@SlabId",
                request.SlabId);

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@AgencyID",
                request.AgencyID);

            _database.AddInParameter(
                dbCommand,
                "@ServiceID",
                request.ServiceID);

            _database.AddInParameter(
                dbCommand,
                "@FromAmount",
                request.FromAmount);

            _database.AddInParameter(
                dbCommand,
                "@ToAmount",
                request.ToAmount);

            _database.AddInParameter(
                dbCommand,
                "@SlabType",
                request.SlabType);

            _database.AddInParameter(
                dbCommand,
                "@CalculationType",
                request.CalculationType);

            _database.AddInParameter(
                dbCommand,
                "@CalculationValue",
                request.CalculationValue);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@SlabId",
                slabId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLAB BY ID
        // ============================================================
        public async Task<GetTransactionSlabResponse?>
            GetTransactionSlabByID(
                long slabId,
                IFINOVAServiceUser serviceUser)
        {
            GetTransactionSlabResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@SlabId",
                slabId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapTransactionSlab(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL TRANSACTION SLABS
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetAllTransactionSlabs(
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE TRANSACTION SLABS
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetActiveTransactionSlabs(
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY PLAN ID
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetTransactionSlabsByPlanID(
                int planId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetByPlanID]");

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                planId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY ID
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetTransactionSlabsByAgencyID(
                int agencyID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetByAgencyID]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyID",
                agencyID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY SERVICE ID
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetTransactionSlabsByServiceID(
                int serviceID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetByServiceID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceID",
                serviceID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET TRANSACTION SLABS BY AGENCY + SERVICE
        // ============================================================
        public async Task<List<GetTransactionSlabResponse>>
            GetTransactionSlabsByAgencyService(
                int agencyID,
                int serviceID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetTransactionSlabResponse> response =
                new List<GetTransactionSlabResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[TransactionSlabs_GetByAgencyService]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyID",
                agencyID);

            _database.AddInParameter(
                dbCommand,
                "@ServiceID",
                serviceID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTransactionSlab(dataReader));
                }
            }

            return response;
        }
        private GetTransactionSlabResponse MapTransactionSlab(
    System.Data.IDataReader dataReader)
        {
            GetTransactionSlabResponse row =
                new GetTransactionSlabResponse();

            row.SlabId =
                GetInt64Value(
                    dataReader,
                    "SlabId").Value;

            row.PlanId =
                GetInt32Value(
                    dataReader,
                    "PlanId");

            row.PlanName =
                GetStringValue(
                    dataReader,
                    "PlanName");

            row.AgencyID =
                GetInt32Value(
                    dataReader,
                    "AgencyID");

            row.AgencyName =
                GetStringValue(
                    dataReader,
                    "AgencyName");

            row.ServiceID =
                GetInt32Value(
                    dataReader,
                    "ServiceID");

            row.ServiceName =
                GetStringValue(
                    dataReader,
                    "ServiceName");

            row.FromAmount =
                dataReader["FromAmount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(
                        dataReader["FromAmount"]);

            row.ToAmount =
                dataReader["ToAmount"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(
                        dataReader["ToAmount"]);

            row.SlabType =
                GetInt32Value(
                    dataReader,
                    "SlabType");

            row.SlabTypeName =
                GetStringValue(
                    dataReader,
                    "SlabTypeName");

            row.CalculationType =
                GetInt32Value(
                    dataReader,
                    "CalculationType");

            row.CalculationTypeName =
                GetStringValue(
                    dataReader,
                    "CalculationTypeName");

            row.CalculationValue =
                dataReader["CalculationValue"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(
                        dataReader["CalculationValue"]);

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

            return row;
        }
    }
}
