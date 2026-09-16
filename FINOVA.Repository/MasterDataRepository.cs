using FINOVA.Database;
using FINOVA.DataModel.Entities.Notification;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Repository.Shared;

namespace FINOVA.Repository
{
    public class MasterDataRepository : BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public MasterDataRepository()
        {
            _database = new FINOVADatabase();
        }
        public async Task<ServiceListResponse> GetAllServcieList(int ServiceId)
        {
            ServiceListResponse response = null;
            var dbCommand = _database.GetStoredProcCommand("[MDM].GetAllServiceList");
            _database.AddInParameter(dbCommand, "@ServiceId", ServiceId);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                dataReader.Read();
                if (dataReader.HasRows)
                {
                    response = new ServiceListResponse();
                    response.ServiceId = GetInt32Value(dataReader, "ServiceId").Value;
                    response.ServiceTypeId = GetInt32Value(dataReader, "ServiceTypeId").Value;
                    response.ServiceCode = GetStringValue(dataReader, "ServiceCode");
                    response.ServiceName = GetStringValue(dataReader, "ServiceName");
                    response.ServcieIfsccode = GetStringValue(dataReader, "ServcieIfsccode");
                    response.ServiceAccountNo = GetStringValue(dataReader, "ServiceAccountNo");
                    response.ServiceAccName = GetStringValue(dataReader, "ServiceAccName");
                    response.ServiceMobileNo = GetStringValue(dataReader, "ServiceMobileNo");

                }
            }

            return response;
        }


        public async Task<SimpleResponse> GetGender()
        {
            SimpleResponse response = new SimpleResponse();
            List<GenderResponse> objMaster = new List<GenderResponse>();

            var dbCommand = _database.GetStoredProcCommand("usp_GetGender");

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    GenderResponse obj = new GenderResponse();

                    obj.GenderId = GetInt32Value(dataReader, "GenderId").Value;

                    obj.GenderName = GetStringValue(dataReader, "GenderName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }

        public async Task<SimpleResponse> GetMaritalStatus()
        {
            SimpleResponse response = new SimpleResponse();
            List<MaritalStatusResponse> objMaster = new List<MaritalStatusResponse>();

            var dbCommand = _database.GetStoredProcCommand("usp_GetMaritalStatus");

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    MaritalStatusResponse obj = new MaritalStatusResponse();

                    obj.MaritalStatusID = GetInt32Value(dataReader, "MaritalStatusID").Value;

                    obj.MaritalStatusName = GetStringValue(dataReader, "MaritalStatusName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
       
        public async Task<SimpleResponse> GetDataByPincode(string Pincode)
        {
            SimpleResponse response = new SimpleResponse();
            List<PincodeDataResponse> objMaster = new List<PincodeDataResponse>();

            var dbCommand = _database.GetStoredProcCommand("[MDM].GetDataByPincode");
            _database.AddInParameter(dbCommand, "@Pincode", Pincode);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    PincodeDataResponse obj = new PincodeDataResponse();
                    obj.StateID = GetInt32Value(dataReader, "StateID").Value;
                    obj.DistrictID = GetInt32Value(dataReader, "DistrictID").Value;
                    obj.PincodeDataId = GetInt32Value(dataReader, "PincodeDataId").Value;
                    obj.AreaName = GetStringValue(dataReader, "AreaName");
                    obj.DistrictName = GetStringValue(dataReader, "DistrictName");
                    obj.StateName = GetStringValue(dataReader, "StateName");
                    obj.Pincode = GetStringValue(dataReader, "Pincode");
                    obj.SubDistrictName = GetStringValue(dataReader, "SubDistrictName");

                    objMaster.Add(obj);
                }
                response.Result = objMaster;
                return response;
            }

        }
        public async Task<ListResponse> GetDataByPincodeList(PincodeDataRequest request)
        {
            ListResponse response = new ListResponse();
            List<PincodeDataResponse> objMaster = new List<PincodeDataResponse>();

            var dbCommand = _database.GetStoredProcCommand("[MDM].GetDataByPincodeList");
            _database.AddInParameter(dbCommand, "@Pincode", request.Pincode);
            _database.AddInParameter(dbCommand, "@PageNo", request.PageNo);
            _database.AddInParameter(dbCommand, "@PageSize", request.PageSize);
            _database.AddInParameter(dbCommand, "@OrderBy", request.OrderBy);
            _database.AddOutParameter(dbCommand, "@Out_TotalRec", 100);

            using (var dataReader = await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    PincodeDataResponse obj = new PincodeDataResponse();
                    obj.StateID = GetInt32Value(dataReader, "StateID").Value;
                    obj.DistrictID = GetInt32Value(dataReader, "DistrictID").Value;
                    obj.PincodeDataId = GetInt32Value(dataReader, "PincodeDataId").Value;
                    obj.AreaName = GetStringValue(dataReader, "AreaName");
                    obj.DistrictName = GetStringValue(dataReader, "DistrictName");
                    obj.StateName = GetStringValue(dataReader, "StateName");
                    obj.Pincode = GetStringValue(dataReader, "Pincode");
                    obj.SubDistrictName = GetStringValue(dataReader, "SubDistrictName");

                    objMaster.Add(obj);
                }

            }
            response.SetPagingOutput(dbCommand);
            response.CurrentPage = request.PageNo;
            response.Result = objMaster;
            return response;

        }

        // ============================================================
        // PLAN MASTER - CREATE
        // ============================================================
        public async Task<int> CreatePlan(
            CreatePlanRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int planID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@PlanName",
                request.PlanName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    planID =
                        GetInt32Value(
                            dataReader,
                            "PlanID").Value;
                }
            }

            return planID;
        }


        // ============================================================
        // PLAN MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePlan(
            UpdatePlanRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@PlanID",
                request.PlanID);

            _database.AddInParameter(
                dbCommand,
                "@PlanName",
                request.PlanName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@PlanID",
                planID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET BY ID
        // ============================================================
        public async Task<GetPlanResponse?> GetPlanByID(
            int planID,
            IFINOVAServiceUser serviceUser)
        {
            GetPlanResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@PlanID",
                planID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapPlan(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET ALL
        // ============================================================
        public async Task<List<GetPlanResponse>> GetAllPlans(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPlanResponse> response =
                new List<GetPlanResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapPlan(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PLAN MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetPlanResponse>> GetActivePlans(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPlanResponse> response =
                new List<GetPlanResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PlanMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapPlan(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PLAN MASTER - COMMON MAPPER
        // ============================================================
        private GetPlanResponse MapPlan(
            System.Data.IDataReader dataReader)
        {
            GetPlanResponse row =
                new GetPlanResponse();

            row.PlanID =
                GetInt32Value(
                    dataReader,
                    "PlanID").Value;

            row.PlanName =
                GetStringValue(
                    dataReader,
                    "PlanName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status");

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // COMPANY TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateCompanyType(
            CreateCompanyTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int companyTypeID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@CompanyTypeName",
                request.CompanyTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    companyTypeID =
                        GetInt32Value(
                            dataReader,
                            "CompnayTypeId").Value;
                }
            }

            return companyTypeID;
        }


        // ============================================================
        // COMPANY TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateCompanyType(
            UpdateCompanyTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@CompnayTypeId",
                request.CompnayTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CompanyTypeName",
                request.CompanyTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@CompnayTypeId",
                compnayTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetCompanyTypeResponse?> GetCompanyTypeByID(
            int compnayTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetCompanyTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@CompnayTypeId",
                compnayTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapCompanyType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetCompanyTypeResponse>> GetAllCompanyTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyTypeResponse> response =
                new List<GetCompanyTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetCompanyTypeResponse>> GetActiveCompanyTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetCompanyTypeResponse> response =
                new List<GetCompanyTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[CompanyTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCompanyType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMPANY TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetCompanyTypeResponse MapCompanyType(
            System.Data.IDataReader dataReader)
        {
            GetCompanyTypeResponse row =
                new GetCompanyTypeResponse();

            row.CompnayTypeId =
                GetInt32Value(
                    dataReader,
                    "CompnayTypeId").Value;

            row.CompanyTypeName =
                GetStringValue(
                    dataReader,
                    "CompanyTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // AGENCY MASTER - CREATE
        // ============================================================
        public async Task<int> CreateAgency(
            CreateAgencyRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int agencyId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyCode",
                request.AgencyCode);

            _database.AddInParameter(
                dbCommand,
                "@AgencyName",
                request.AgencyName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    agencyId =
                        GetInt32Value(
                            dataReader,
                            "AgencyId").Value;
                }
            }

            return agencyId;
        }


        // ============================================================
        // AGENCY MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateAgency(
            UpdateAgencyRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@AgencyCode",
                request.AgencyCode);

            _database.AddInParameter(
                dbCommand,
                "@AgencyName",
                request.AgencyName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                agencyId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET BY ID
        // ============================================================
        public async Task<GetAgencyResponse?> GetAgencyByID(
            int agencyId,
            IFINOVAServiceUser serviceUser)
        {
            GetAgencyResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                agencyId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapAgency(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET ALL
        // ============================================================
        public async Task<List<GetAgencyResponse>> GetAllAgencies(
            IFINOVAServiceUser serviceUser)
        {
            List<GetAgencyResponse> response =
                new List<GetAgencyResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapAgency(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // AGENCY MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetAgencyResponse>> GetActiveAgencies(
            IFINOVAServiceUser serviceUser)
        {
            List<GetAgencyResponse> response =
                new List<GetAgencyResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AgencyMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapAgency(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // AGENCY MASTER - COMMON MAPPER
        // ============================================================
        private GetAgencyResponse MapAgency(
            System.Data.IDataReader dataReader)
        {
            GetAgencyResponse row =
                new GetAgencyResponse();

            row.AgencyId =
                GetInt32Value(
                    dataReader,
                    "AgencyId").Value;

            row.AgencyCode =
                GetStringValue(
                    dataReader,
                    "AgencyCode");

            row.AgencyName =
                GetStringValue(
                    dataReader,
                    "AgencyName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // ADDRESS TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateAddressType(
            CreateAddressTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int addressTypeId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeName",
                request.AddressTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    addressTypeId =
                        GetInt32Value(
                            dataReader,
                            "AddressTypeId").Value;
                }
            }

            return addressTypeId;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateAddressType(
            UpdateAddressTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeId",
                request.AddressTypeId);

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeName",
                request.AddressTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeId",
                addressTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetAddressTypeResponse?> GetAddressTypeByID(
            int addressTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetAddressTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeId",
                addressTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapAddressType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetAddressTypeResponse>> GetAllAddressTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetAddressTypeResponse> response =
                new List<GetAddressTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapAddressType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetAddressTypeResponse>> GetActiveAddressTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetAddressTypeResponse> response =
                new List<GetAddressTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[AddressTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapAddressType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ADDRESS TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetAddressTypeResponse MapAddressType(
            System.Data.IDataReader dataReader)
        {
            GetAddressTypeResponse row =
                new GetAddressTypeResponse();

            row.AddressTypeId =
                GetInt32Value(
                    dataReader,
                    "AddressTypeId").Value;

            row.AddressTypeName =
                GetStringValue(
                    dataReader,
                    "AddressTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // BANK MASTER - CREATE
        // ============================================================
        public async Task<int> CreateBank(
            CreateBankRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int bankID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@BankName",
                request.BankName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    bankID =
                        GetInt32Value(
                            dataReader,
                            "BankID").Value;
                }
            }

            return bankID;
        }


        // ============================================================
        // BANK MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateBank(
            UpdateBankRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                request.BankID);

            _database.AddInParameter(
                dbCommand,
                "@BankName",
                request.BankName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                bankID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // BANK MASTER - GET BY ID
        // ============================================================
        public async Task<GetBankResponse?> GetBankByID(
            int bankID,
            IFINOVAServiceUser serviceUser)
        {
            GetBankResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                bankID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapBank(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // BANK MASTER - GET ALL
        // ============================================================
        public async Task<List<GetBankResponse>> GetAllBanks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetBankResponse> response =
                new List<GetBankResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapBank(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // BANK MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetBankResponse>> GetActiveBanks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetBankResponse> response =
                new List<GetBankResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[BankMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapBank(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // BANK MASTER - COMMON MAPPER
        // ============================================================
        private GetBankResponse MapBank(
            System.Data.IDataReader dataReader)
        {
            GetBankResponse row =
                new GetBankResponse();

            row.BankID =
                GetInt32Value(
                    dataReader,
                    "BankID").Value;

            row.BankName =
                GetStringValue(
                    dataReader,
                    "BankName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // STATE - CREATE
        // ============================================================
        public async Task<int> CreateState(
            CreateStateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int stateID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@StateFlagID",
                request.StateFlagID);

            _database.AddInParameter(
                dbCommand,
                "@CountryID",
                request.CountryID);

            _database.AddInParameter(
                dbCommand,
                "@RegionID",
                request.RegionID);

            _database.AddInParameter(
                dbCommand,
                "@StateCode",
                request.StateCode);

            _database.AddInParameter(
                dbCommand,
                "@StateName",
                request.StateName);

            _database.AddInParameter(
                dbCommand,
                "@Abbreviation",
                request.Abbreviation);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    stateID =
                        GetInt32Value(
                            dataReader,
                            "StateID").Value;
                }
            }

            return stateID;
        }


        // ============================================================
        // STATE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateState(
            UpdateStateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_Update]");

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                request.StateID);

            _database.AddInParameter(
                dbCommand,
                "@StateFlagID",
                request.StateFlagID);

            _database.AddInParameter(
                dbCommand,
                "@CountryID",
                request.CountryID);

            _database.AddInParameter(
                dbCommand,
                "@RegionID",
                request.RegionID);

            _database.AddInParameter(
                dbCommand,
                "@StateCode",
                request.StateCode);

            _database.AddInParameter(
                dbCommand,
                "@StateName",
                request.StateName);

            _database.AddInParameter(
                dbCommand,
                "@Abbreviation",
                request.Abbreviation);

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
        // STATE - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteState(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                stateID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // STATE - GET BY ID
        // ============================================================
        public async Task<GetStateResponse?> GetStateByID(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            GetStateResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                stateID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapState(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // STATE - GET ALL
        // ============================================================
        public async Task<List<GetStateResponse>> GetAllStates(
            IFINOVAServiceUser serviceUser)
        {
            List<GetStateResponse> response =
                new List<GetStateResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapState(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // STATE - GET ACTIVE
        // ============================================================
        public async Task<List<GetStateResponse>> GetActiveStates(
            IFINOVAServiceUser serviceUser)
        {
            List<GetStateResponse> response =
                new List<GetStateResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapState(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // STATE - GET BY COUNTRY ID
        // ============================================================
        public async Task<List<GetStateResponse>> GetStatesByCountryID(
            int countryID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetStateResponse> response =
                new List<GetStateResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[State_GetByCountryID]");

            _database.AddInParameter(
                dbCommand,
                "@CountryID",
                countryID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapState(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // STATE - COMMON MAPPER
        // ============================================================
        private GetStateResponse MapState(
            System.Data.IDataReader dataReader)
        {
            GetStateResponse row =
                new GetStateResponse();

            row.StateID =
                GetInt32Value(
                    dataReader,
                    "StateID").Value;

            row.StateUID =
                dataReader["StateUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["StateUID"];

            row.StateFlagID =
                GetInt64Value(
                    dataReader,
                    "StateFlagID");

            row.CountryID =
                GetInt32Value(
                    dataReader,
                    "CountryID").Value;

            row.CountryName =
                GetStringValue(
                    dataReader,
                    "CountryName");

            row.RegionID =
                GetInt32Value(
                    dataReader,
                    "RegionID").Value;

            row.RegionName =
                GetStringValue(
                    dataReader,
                    "RegionName");

            row.StateCode =
                GetStringValue(
                    dataReader,
                    "StateCode");

            row.StateName =
                GetStringValue(
                    dataReader,
                    "StateName");

            row.Abbreviation =
                GetStringValue(
                    dataReader,
                    "Abbreviation");

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
                    "CreatedOn").Value;

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
        // DISTRICT - CREATE
        // ============================================================
        public async Task<long> CreateDistrict(
            CreateDistrictRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long districtID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                request.StateID);

            _database.AddInParameter(
                dbCommand,
                "@DistrictCode",
                request.DistrictCode);

            _database.AddInParameter(
                dbCommand,
                "@DistrictCodeOld",
                request.DistrictCodeOld);

            _database.AddInParameter(
                dbCommand,
                "@DistrictName",
                request.DistrictName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    districtID =
                        GetInt64Value(
                            dataReader,
                            "DistrictID").Value;
                }
            }

            return districtID;
        }


        // ============================================================
        // DISTRICT - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateDistrict(
            UpdateDistrictRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_Update]");

            _database.AddInParameter(
                dbCommand,
                "@DistrictID",
                request.DistrictID);

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                request.StateID);

            _database.AddInParameter(
                dbCommand,
                "@DistrictCode",
                request.DistrictCode);

            _database.AddInParameter(
                dbCommand,
                "@DistrictCodeOld",
                request.DistrictCodeOld);

            _database.AddInParameter(
                dbCommand,
                "@DistrictName",
                request.DistrictName);

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
        // DISTRICT - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteDistrict(
            long districtID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@DistrictID",
                districtID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // DISTRICT - GET BY ID
        // ============================================================
        public async Task<GetDistrictResponse?> GetDistrictByID(
            long districtID,
            IFINOVAServiceUser serviceUser)
        {
            GetDistrictResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@DistrictID",
                districtID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapDistrict(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // DISTRICT - GET ALL
        // ============================================================
        public async Task<List<GetDistrictResponse>> GetAllDistricts(
            IFINOVAServiceUser serviceUser)
        {
            List<GetDistrictResponse> response =
                new List<GetDistrictResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapDistrict(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // DISTRICT - GET ACTIVE
        // ============================================================
        public async Task<List<GetDistrictResponse>> GetActiveDistricts(
            IFINOVAServiceUser serviceUser)
        {
            List<GetDistrictResponse> response =
                new List<GetDistrictResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapDistrict(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // DISTRICT - GET BY STATE ID
        // ============================================================
        public async Task<List<GetDistrictResponse>> GetDistrictsByStateID(
            int stateID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetDistrictResponse> response =
                new List<GetDistrictResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[District_GetByStateID]");

            _database.AddInParameter(
                dbCommand,
                "@StateID",
                stateID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapDistrict(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // DISTRICT - COMMON MAPPER
        // ============================================================
        private GetDistrictResponse MapDistrict(
            System.Data.IDataReader dataReader)
        {
            GetDistrictResponse row =
                new GetDistrictResponse();

            row.DistrictID =
                GetInt64Value(
                    dataReader,
                    "DistrictID").Value;

            row.DistrictUID =
                dataReader["DistrictUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["DistrictUID"];

            row.StateID =
                GetInt32Value(
                    dataReader,
                    "StateID").Value;

            row.StateName =
                GetStringValue(
                    dataReader,
                    "StateName");

            row.DistrictCode =
                GetStringValue(
                    dataReader,
                    "DistrictCode");

            row.DistrictCodeOld =
                GetStringValue(
                    dataReader,
                    "DistrictCodeOld");

            row.DistrictName =
                GetStringValue(
                    dataReader,
                    "DistrictName");

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
                    "CreatedOn").Value;

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
        // KYC TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateKycType(
            CreateKycTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int kycTypeID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeID",
                request.UserTypeID);

            _database.AddInParameter(
                dbCommand,
                "@CompanyTypeId",
                request.CompanyTypeId);

            _database.AddInParameter(
                dbCommand,
                "@KycTypeName",
                request.KycTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    kycTypeID =
                        GetInt32Value(
                            dataReader,
                            "KycTypeID").Value;
                }
            }

            return kycTypeID;
        }


        // ============================================================
        // KYC TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateKycType(
            UpdateKycTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@KycTypeID",
                request.KycTypeID);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeID",
                request.UserTypeID);

            _database.AddInParameter(
                dbCommand,
                "@CompanyTypeId",
                request.CompanyTypeId);

            _database.AddInParameter(
                dbCommand,
                "@KycTypeName",
                request.KycTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@KycTypeID",
                kycTypeID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetKycTypeResponse?> GetKycTypeByID(
            int kycTypeID,
            IFINOVAServiceUser serviceUser)
        {
            GetKycTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@KycTypeID",
                kycTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapKycType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetKycTypeResponse>> GetAllKycTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetKycTypeResponse> response =
                new List<GetKycTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapKycType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetKycTypeResponse>> GetActiveKycTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetKycTypeResponse> response =
                new List<GetKycTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapKycType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY USER TYPE ID
        // ============================================================
        public async Task<List<GetKycTypeResponse>> GetKycTypesByUserTypeID(
            int userTypeID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetKycTypeResponse> response =
                new List<GetKycTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_GetByUserTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeID",
                userTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapKycType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - GET BY USER TYPE + COMPANY TYPE
        // ============================================================
        public async Task<List<GetKycTypeResponse>> GetKycTypesByUserAndCompanyType(
            int userTypeID,
            int? companyTypeId,
            IFINOVAServiceUser serviceUser)
        {
            List<GetKycTypeResponse> response =
                new List<GetKycTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[KycTypeMaster_GetByUserAndCompanyType]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeID",
                userTypeID);

            _database.AddInParameter(
                dbCommand,
                "@CompanyTypeId",
                companyTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapKycType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // KYC TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetKycTypeResponse MapKycType(
            System.Data.IDataReader dataReader)
        {
            GetKycTypeResponse row =
                new GetKycTypeResponse();

            row.KycTypeID =
                GetInt32Value(
                    dataReader,
                    "KycTypeID").Value;

            row.UserTypeID =
                GetInt32Value(
                    dataReader,
                    "UserTypeID").Value;

            row.CompanyTypeId =
                GetInt32Value(
                    dataReader,
                    "CompanyTypeId");

            row.KycTypeName =
                GetStringValue(
                    dataReader,
                    "KycTypeName");

            row.UserTypeName =
                GetStringValue(
                    dataReader,
                    "UserTypeName");
            row.CompanyTypeName =
    GetStringValue(
        dataReader,
        "CompanyTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // USER TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateUserType(
            CreateUserTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int userTypeId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeName",
                request.UserTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    userTypeId =
                        GetInt32Value(
                            dataReader,
                            "UserTypeId").Value;
                }
            }

            return userTypeId;
        }


        // ============================================================
        // USER TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserType(
            UpdateUserTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                request.UserTypeId);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeName",
                request.UserTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                userTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetUserTypeResponse?> GetUserTypeByID(
            int userTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetUserTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                userTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapUserType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetUserTypeResponse>> GetAllUserTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserTypeResponse> response =
                new List<GetUserTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetUserTypeResponse>> GetActiveUserTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserTypeResponse> response =
                new List<GetUserTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[UserTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetUserTypeResponse MapUserType(
            System.Data.IDataReader dataReader)
        {
            GetUserTypeResponse row =
                new GetUserTypeResponse();

            row.UserTypeId =
                GetInt32Value(
                    dataReader,
                    "UserTypeId").Value;

            row.UserTypeName =
                GetStringValue(
                    dataReader,
                    "UserTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // LEDGER TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateLedgerType(
            CreateLedgerTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int ledgerTypeId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@LedgerTypeName",
                request.LedgerTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    ledgerTypeId =
                        GetInt32Value(
                            dataReader,
                            "LedgerTypeId").Value;
                }
            }

            return ledgerTypeId;
        }


        // ============================================================
        // LEDGER TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateLedgerType(
            UpdateLedgerTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@LedgerTypeId",
                request.LedgerTypeId);

            _database.AddInParameter(
                dbCommand,
                "@LedgerTypeName",
                request.LedgerTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@LedgerTypeId",
                ledgerTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetLedgerTypeResponse?> GetLedgerTypeByID(
            int ledgerTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetLedgerTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@LedgerTypeId",
                ledgerTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapLedgerType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetLedgerTypeResponse>> GetAllLedgerTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetLedgerTypeResponse> response =
                new List<GetLedgerTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapLedgerType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetLedgerTypeResponse>> GetActiveLedgerTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetLedgerTypeResponse> response =
                new List<GetLedgerTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[LedgerTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapLedgerType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // LEDGER TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetLedgerTypeResponse MapLedgerType(
            System.Data.IDataReader dataReader)
        {
            GetLedgerTypeResponse row =
                new GetLedgerTypeResponse();

            row.LedgerTypeId =
                GetInt32Value(
                    dataReader,
                    "LedgerTypeId").Value;

            row.LedgerTypeName =
                GetStringValue(
                    dataReader,
                    "LedgerTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateServiceType(
            CreateServiceTypeRequestmdm request,
            IFINOVAServiceUser serviceUser)
        {
            int serviceTypeId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeName",
                request.ServiceTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    serviceTypeId =
                        GetInt32Value(
                            dataReader,
                            "ServiceTypeId").Value;
                }
            }

            return serviceTypeId;
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateServiceType(
            UpdateServiceTypeRequestmdm request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                request.ServiceTypeId);

            _database.AddInParameter(
                dbCommand,
                "@AgencyId",
                request.AgencyId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeName",
                request.ServiceTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                serviceTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetServiceTypeResponsemdm?> GetServiceTypeByID(
            int serviceTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetServiceTypeResponsemdm? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                serviceTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapServiceType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetServiceTypeResponsemdm>> GetAllServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceTypeResponsemdm> response =
                new List<GetServiceTypeResponsemdm>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapServiceType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetServiceTypeResponsemdm>> GetActiveServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceTypeResponsemdm> response =
                new List<GetServiceTypeResponsemdm>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapServiceType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY AGENCY ID
        // ============================================================
        public async Task<List<GetServiceTypeResponsemdm>> GetServiceTypesByAgencyID(
            int agencyId,
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceTypeResponsemdm> response =
                new List<GetServiceTypeResponsemdm>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceTypeMaster_GetByAgencyID]");

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
                        MapServiceType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetServiceTypeResponsemdm MapServiceType(
            System.Data.IDataReader dataReader)
        {
            GetServiceTypeResponsemdm row =
                new GetServiceTypeResponsemdm();

            row.ServiceTypeId =
                GetInt32Value(
                    dataReader,
                    "ServiceTypeId").Value;

            row.AgencyId =
                GetInt32Value(
                    dataReader,
                    "AgencyId");

            row.ServiceTypeName =
                GetStringValue(
                    dataReader,
                    "ServiceTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");
            row.AgencyName =
                GetStringValue(
                    dataReader,
                    "AgencyName");

            return row;
        }
        // ============================================================
        // PAYMENT CHANEL MASTER - CREATE
        // ============================================================
        public async Task<int> CreatePaymentChanel(
            CreatePaymentChanelRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int paymentChanelID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelName",
                request.PaymentChanelName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    paymentChanelID =
                        GetInt32Value(
                            dataReader,
                            "PaymentChanelID").Value;
                }
            }

            return paymentChanelID;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentChanel(
            UpdatePaymentChanelRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                request.PaymentChanelID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelName",
                request.PaymentChanelName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                paymentChanelID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET BY ID
        // ============================================================
        public async Task<GetPaymentChanelResponse?> GetPaymentChanelByID(
            int paymentChanelID,
            IFINOVAServiceUser serviceUser)
        {
            GetPaymentChanelResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                paymentChanelID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapPaymentChanel(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ALL
        // ============================================================
        public async Task<List<GetPaymentChanelResponse>> GetAllPaymentChanels(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentChanelResponse> response =
                new List<GetPaymentChanelResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentChanel(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetPaymentChanelResponse>> GetActivePaymentChanels(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentChanelResponse> response =
                new List<GetPaymentChanelResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentChanelMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentChanel(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT CHANEL MASTER - COMMON MAPPER
        // ============================================================
        private GetPaymentChanelResponse MapPaymentChanel(
            System.Data.IDataReader dataReader)
        {
            GetPaymentChanelResponse row =
                new GetPaymentChanelResponse();

            row.PaymentChanelID =
                GetInt32Value(
                    dataReader,
                    "PaymentChanelID").Value;

            row.PaymentChanelName =
                GetStringValue(
                    dataReader,
                    "PaymentChanelName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // PAYMENT MODE MASTER - CREATE
        // ============================================================
        public async Task<int> CreatePaymentMode(
            CreatePaymentModeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int paymentModeID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                request.PaymentChanelID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeName",
                request.PaymentModeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    paymentModeID =
                        GetInt32Value(
                            dataReader,
                            "PaymentModeID").Value;
                }
            }

            return paymentModeID;
        }


        // ============================================================
        // PAYMENT MODE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentMode(
            UpdatePaymentModeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeID",
                request.PaymentModeID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                request.PaymentChanelID);

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeName",
                request.PaymentModeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeID",
                paymentModeID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY ID
        // ============================================================
        public async Task<GetPaymentModeResponse?> GetPaymentModeByID(
            int paymentModeID,
            IFINOVAServiceUser serviceUser)
        {
            GetPaymentModeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentModeID",
                paymentModeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapPaymentMode(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetPaymentModeResponse>> GetAllPaymentModes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentModeResponse> response =
                new List<GetPaymentModeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentMode(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetPaymentModeResponse>> GetActivePaymentModes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentModeResponse> response =
                new List<GetPaymentModeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentMode(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - GET BY PAYMENT CHANEL ID
        // ============================================================
        public async Task<List<GetPaymentModeResponse>> GetPaymentModesByPaymentChanelID(
            int paymentChanelID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentModeResponse> response =
                new List<GetPaymentModeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[PaymentModeMaster_GetByPaymentChanelID]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentChanelID",
                paymentChanelID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentMode(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT MODE MASTER - COMMON MAPPER
        // ============================================================
        private GetPaymentModeResponse MapPaymentMode(
            System.Data.IDataReader dataReader)
        {
            GetPaymentModeResponse row =
                new GetPaymentModeResponse();

            row.PaymentModeID =
                GetInt32Value(
                    dataReader,
                    "PaymentModeID").Value;

            row.PaymentChanelID =
                GetInt32Value(
                    dataReader,
                    "PaymentChanelID");

            row.PaymentChanelName =
                GetStringValue(
                    dataReader,
                    "PaymentChanelName");

            row.PaymentModeName =
                GetStringValue(
                    dataReader,
                    "PaymentModeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // SERVICE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateService(
            CreateServiceRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int serviceId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                request.ServiceTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceCode",
                request.ServiceCode);

            _database.AddInParameter(
                dbCommand,
                "@ServiceName",
                request.ServiceName);

            _database.AddInParameter(
                dbCommand,
                "@ServiceAccountNo",
                request.ServiceAccountNo);

            _database.AddInParameter(
                dbCommand,
                "@ServcieIfsccode",
                request.ServcieIfsccode);

            _database.AddInParameter(
                dbCommand,
                "@ServiceAccName",
                request.ServiceAccName);

            _database.AddInParameter(
                dbCommand,
                "@ServiceMobileNo",
                request.ServiceMobileNo);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    serviceId =
                        GetInt32Value(
                            dataReader,
                            "ServiceId").Value;
                }
            }

            return serviceId;
        }


        // ============================================================
        // SERVICE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateService(
            UpdateServiceRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                request.ServiceId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                request.ServiceTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceCode",
                request.ServiceCode);

            _database.AddInParameter(
                dbCommand,
                "@ServiceName",
                request.ServiceName);

            _database.AddInParameter(
                dbCommand,
                "@ServiceAccountNo",
                request.ServiceAccountNo);

            _database.AddInParameter(
                dbCommand,
                "@ServcieIfsccode",
                request.ServcieIfsccode);

            _database.AddInParameter(
                dbCommand,
                "@ServiceAccName",
                request.ServiceAccName);

            _database.AddInParameter(
                dbCommand,
                "@ServiceMobileNo",
                request.ServiceMobileNo);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                serviceId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET BY ID
        // ============================================================
        public async Task<GetServiceResponse?> GetServiceByID(
            int serviceId,
            IFINOVAServiceUser serviceUser)
        {
            GetServiceResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceId",
                serviceId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapService(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetServiceResponse>> GetAllServices(
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceResponse> response =
                new List<GetServiceResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapService(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE MASTER - GET BY SERVICE TYPE ID
        // ============================================================
        public async Task<List<GetServiceResponse>> GetServicesByServiceTypeID(
            int serviceTypeId,
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceResponse> response =
                new List<GetServiceResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[MDM].[ServiceMaster_GetByServiceTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeId",
                serviceTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapService(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE MASTER - COMMON MAPPER
        // ============================================================
        private GetServiceResponse MapService(
            System.Data.IDataReader dataReader)
        {
            GetServiceResponse row =
                new GetServiceResponse();

            row.ServiceId =
                GetInt32Value(
                    dataReader,
                    "ServiceId").Value;

            row.ServiceTypeId =
                GetInt32Value(
                    dataReader,
                    "ServiceTypeId");

            row.ServiceTypeName =
                GetStringValue(
                    dataReader,
                    "ServiceTypeName");

            row.ServiceCode =
                GetStringValue(
                    dataReader,
                    "ServiceCode");

            row.ServiceName =
                GetStringValue(
                    dataReader,
                    "ServiceName");

            row.ServiceAccountNo =
                GetStringValue(
                    dataReader,
                    "ServiceAccountNo");

            row.ServcieIfsccode =
                GetStringValue(
                    dataReader,
                    "ServcieIfsccode");

            row.ServiceAccName =
                GetStringValue(
                    dataReader,
                    "ServiceAccName");

            row.ServiceMobileNo =
                GetStringValue(
                    dataReader,
                    "ServiceMobileNo");

            return row;
        }
        // ============================================================
        // CHARGE DEDUCTION TYPE - CREATE
        // ============================================================
        public async Task<long> CreateChargeDeductionType(
            CreateChargeDeductionTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionId",
                request.ChargeDeductionId);

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionType",
                request.ChargeDeductionType);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID = GetIDOutputLong(dbCommand);

            return outputID;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateChargeDeductionType(
            UpdateChargeDeductionTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionId",
                request.ChargeDeductionId);

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionType",
                request.ChargeDeductionType);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionId",
                chargeDeductionId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET BY ID
        // ============================================================
        public async Task<GetChargeDeductionTypeResponse?>
            GetChargeDeductionTypeByID(
                int chargeDeductionId,
                IFINOVAServiceUser serviceUser)
        {
            GetChargeDeductionTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ChargeDeductionId",
                chargeDeductionId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapChargeDeductionType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ALL
        // ============================================================
        public async Task<List<GetChargeDeductionTypeResponse>>
            GetAllChargeDeductionTypes(
                IFINOVAServiceUser serviceUser)
        {
            List<GetChargeDeductionTypeResponse> response =
                new List<GetChargeDeductionTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapChargeDeductionType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // CHARGE DEDUCTION TYPE - GET ACTIVE
        // ============================================================
        public async Task<List<GetChargeDeductionTypeResponse>>
            GetActiveChargeDeductionTypes(
                IFINOVAServiceUser serviceUser)
        {
            List<GetChargeDeductionTypeResponse> response =
                new List<GetChargeDeductionTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[ChargeDeductionTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapChargeDeductionType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON MAPPER
        // ============================================================
        private GetChargeDeductionTypeResponse MapChargeDeductionType(
            System.Data.IDataReader dataReader)
        {
            GetChargeDeductionTypeResponse row =
                new GetChargeDeductionTypeResponse();

            row.ChargeDeductionId =
                GetInt32Value(
                    dataReader,
                    "ChargeDeductionId").Value;

            row.ChargeDeductionType =
                GetStringValue(
                    dataReader,
                    "ChargeDeductionType");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // SLAB TYPE - CREATE
        // ============================================================
        public async Task<long> CreateSlabType(
            CreateSlabTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@SlabTypId",
                request.SlabTypId);

            _database.AddInParameter(
                dbCommand,
                "@SlabTypeName",
                request.SlabTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID = GetIDOutputLong(dbCommand);

            return outputID;
        }


        // ============================================================
        // SLAB TYPE - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateSlabType(
            UpdateSlabTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@SlabTypId",
                request.SlabTypId);

            _database.AddInParameter(
                dbCommand,
                "@SlabTypeName",
                request.SlabTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@SlabTypId",
                slabTypId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET BY ID
        // ============================================================
        public async Task<GetSlabTypeResponse?> GetSlabTypeByID(
            int slabTypId,
            IFINOVAServiceUser serviceUser)
        {
            GetSlabTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@SlabTypId",
                slabTypId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapSlabType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET ALL
        // ============================================================
        public async Task<List<GetSlabTypeResponse>> GetAllSlabTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetSlabTypeResponse> response =
                new List<GetSlabTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapSlabType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SLAB TYPE - GET ACTIVE
        // ============================================================
        public async Task<List<GetSlabTypeResponse>> GetActiveSlabTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetSlabTypeResponse> response =
                new List<GetSlabTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[SlabTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapSlabType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON MAPPER
        // ============================================================
        private GetSlabTypeResponse MapSlabType(
            System.Data.IDataReader dataReader)
        {
            GetSlabTypeResponse row =
                new GetSlabTypeResponse();

            row.SlabTypId =
                GetInt32Value(
                    dataReader,
                    "SlabTypId").Value;

            row.SlabTypeName =
                GetStringValue(
                    dataReader,
                    "SlabTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
        // ============================================================
        // PAYMENT ACCOUNT - CREATE
        // ============================================================
        public async Task<long> CreatePaymentAccount(
            CreatePaymentAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                request.BankID);

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
                "@Branchcode",
                request.Branchcode);

            _database.AddInParameter(
                dbCommand,
                "@Micrcode",
                request.Micrcode);

            _database.AddInParameter(
                dbCommand,
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@Remarks",
                request.Remarks);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID = GetIDOutputLong(dbCommand);

            return outputID;
        }


        // ============================================================
        // PAYMENT ACCOUNT - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePaymentAccount(
            UpdatePaymentAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentAccountID",
                request.PaymentAccountID);

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                request.BankID);

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
                "@Branchcode",
                request.Branchcode);

            _database.AddInParameter(
                dbCommand,
                "@Micrcode",
                request.Micrcode);

            _database.AddInParameter(
                dbCommand,
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@Remarks",
                request.Remarks);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentAccountID",
                paymentAccountID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY ID
        // ============================================================
        public async Task<GetPaymentAccountResponse?> GetPaymentAccountByID(
            int paymentAccountID,
            IFINOVAServiceUser serviceUser)
        {
            GetPaymentAccountResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@PaymentAccountID",
                paymentAccountID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapPaymentAccount(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ALL
        // ============================================================
        public async Task<List<GetPaymentAccountResponse>>
            GetAllPaymentAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentAccountResponse> response =
                new List<GetPaymentAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET ACTIVE
        // ============================================================
        public async Task<List<GetPaymentAccountResponse>>
            GetActivePaymentAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentAccountResponse> response =
                new List<GetPaymentAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PAYMENT ACCOUNT - GET BY BANK ID
        // ============================================================
        public async Task<List<GetPaymentAccountResponse>>
            GetPaymentAccountsByBankID(
                int bankID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetPaymentAccountResponse> response =
                new List<GetPaymentAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[PaymentAccountMaster_GetByBankID]");

            _database.AddInParameter(
                dbCommand,
                "@BankID",
                bankID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPaymentAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON PAYMENT ACCOUNT MAPPER
        // ============================================================
        private GetPaymentAccountResponse MapPaymentAccount(
            System.Data.IDataReader dataReader)
        {
            GetPaymentAccountResponse row =
                new GetPaymentAccountResponse();

            row.PaymentAccountID =
                GetInt32Value(
                    dataReader,
                    "PaymentAccountID").Value;

            row.BankID =
                GetInt32Value(
                    dataReader,
                    "BankID");

            row.BankName =
                GetStringValue(
                    dataReader,
                    "BankName");

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

            row.Branchcode =
                GetStringValue(
                    dataReader,
                    "Branchcode");

            row.Micrcode =
                GetStringValue(
                    dataReader,
                    "Micrcode");

            row.BranchAddress =
                GetStringValue(
                    dataReader,
                    "BranchAddress");

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

            row.Remarks =
                GetStringValue(
                    dataReader,
                    "Remarks");

            return row;
        }
        // ============================================================
        // CREATE CALCULATION TYPE
        // ============================================================
        public async Task<long> CreateCalculationType(
            CreateCalculationTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeName",
                request.CalculationTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputID = GetIDOutputLong(dbCommand);

            return outputID;
        }


        // ============================================================
        // UPDATE CALCULATION TYPE
        // ============================================================
        public async Task<SimpleResponse> UpdateCalculationType(
            UpdateCalculationTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                request.CalculationTypeId);

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeName",
                request.CalculationTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                calculationTypeId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET CALCULATION TYPE BY ID
        // ============================================================
        public async Task<GetCalculationTypeResponse?> GetCalculationTypeByID(
            int calculationTypeId,
            IFINOVAServiceUser serviceUser)
        {
            GetCalculationTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@CalculationTypeId",
                calculationTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapCalculationType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL CALCULATION TYPES
        // ============================================================
        public async Task<List<GetCalculationTypeResponse>>
            GetAllCalculationTypes(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCalculationTypeResponse> response =
                new List<GetCalculationTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCalculationType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE CALCULATION TYPES
        // ============================================================
        public async Task<List<GetCalculationTypeResponse>>
            GetActiveCalculationTypes(
                IFINOVAServiceUser serviceUser)
        {
            List<GetCalculationTypeResponse> response =
                new List<GetCalculationTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[CONFG].[CalculationTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapCalculationType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON MAPPER
        // ============================================================
        private GetCalculationTypeResponse MapCalculationType(
            System.Data.IDataReader dataReader)
        {
            GetCalculationTypeResponse row =
                new GetCalculationTypeResponse();

            row.CalculationTypeId =
                GetInt32Value(
                    dataReader,
                    "CalculationTypeId").Value;

            row.CalculationTypeName =
                GetStringValue(
                    dataReader,
                    "CalculationTypeName");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            return row;
        }
    }
}
