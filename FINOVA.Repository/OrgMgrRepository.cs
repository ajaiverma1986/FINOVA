using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.OrgMgr;
using FINOVA.DataModel.Shared;
using FINOVA.Repository.Shared;

namespace FINOVA.Repository
{
    public class OrgMgrRepository : BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public OrgMgrRepository()
        {
            _database = new FINOVADatabase();
        }
        // ============================================================
        // ORGANIZATION - CREATE
        // ============================================================
        public async Task<long> CreateOrganization(
            CreateOrganizationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long organizationID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationCode",
                request.OrganizationCode);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationName",
                request.OrganizationName);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationTypeID",
                request.OrganizationTypeID);

            _database.AddInParameter(
                dbCommand,
                "@DisplayName",
                request.DisplayName);

            _database.AddInParameter(
                dbCommand,
                "@LegalName",
                request.LegalName);

            _database.AddInParameter(
                dbCommand,
                "@Email",
                request.Email);

            _database.AddInParameter(
                dbCommand,
                "@MobileNo",
                request.MobileNo);

            _database.AddInParameter(
                dbCommand,
                "@PhoneNo",
                request.PhoneNo);

            _database.AddInParameter(
                dbCommand,
                "@Website",
                request.Website);

            _database.AddInParameter(
                dbCommand,
                "@RegistrationNo",
                request.RegistrationNo);

            _database.AddInParameter(
                dbCommand,
                "@GSTIN",
                request.GSTIN);

            _database.AddInParameter(
                dbCommand,
                "@PAN",
                request.PAN);

            _database.AddInParameter(
                dbCommand,
                "@TAN",
                request.TAN);

            _database.AddInParameter(
                dbCommand,
                "@LogoPath",
                request.LogoPath);

            _database.AddInParameter(
                dbCommand,
                "@CurrencyID",
                request.CurrencyID);

            _database.AddInParameter(
                dbCommand,
                "@TimeZoneID",
                request.TimeZoneID);

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

            organizationID =
                GetIDOutputLong(dbCommand);

            return organizationID;
        }


        // ============================================================
        // ORGANIZATION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateOrganization(
            UpdateOrganizationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationCode",
                request.OrganizationCode);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationName",
                request.OrganizationName);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationTypeID",
                request.OrganizationTypeID);

            _database.AddInParameter(
                dbCommand,
                "@DisplayName",
                request.DisplayName);

            _database.AddInParameter(
                dbCommand,
                "@LegalName",
                request.LegalName);

            _database.AddInParameter(
                dbCommand,
                "@Email",
                request.Email);

            _database.AddInParameter(
                dbCommand,
                "@MobileNo",
                request.MobileNo);

            _database.AddInParameter(
                dbCommand,
                "@PhoneNo",
                request.PhoneNo);

            _database.AddInParameter(
                dbCommand,
                "@Website",
                request.Website);

            _database.AddInParameter(
                dbCommand,
                "@RegistrationNo",
                request.RegistrationNo);

            _database.AddInParameter(
                dbCommand,
                "@GSTIN",
                request.GSTIN);

            _database.AddInParameter(
                dbCommand,
                "@PAN",
                request.PAN);

            _database.AddInParameter(
                dbCommand,
                "@TAN",
                request.TAN);

            _database.AddInParameter(
                dbCommand,
                "@LogoPath",
                request.LogoPath);

            _database.AddInParameter(
                dbCommand,
                "@CurrencyID",
                request.CurrencyID);

            _database.AddInParameter(
                dbCommand,
                "@TimeZoneID",
                request.TimeZoneID);

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
        // ORGANIZATION - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteOrganization(
            long organizationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                organizationID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY ID
        // ============================================================
        public async Task<GetOrganizationResponse?> GetOrganizationByID(
            long organizationID,
            IFINOVAServiceUser serviceUser)
        {
            GetOrganizationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                organizationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapOrganization(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY UID
        // ============================================================
        public async Task<GetOrganizationResponse?> GetOrganizationByUID(
            Guid organizationUID,
            IFINOVAServiceUser serviceUser)
        {
            GetOrganizationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetByUID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationUID",
                organizationUID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapOrganization(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY CODE
        // ============================================================
        public async Task<GetOrganizationResponse?> GetOrganizationByCode(
            string organizationCode,
            IFINOVAServiceUser serviceUser)
        {
            GetOrganizationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetByCode]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationCode",
                organizationCode);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapOrganization(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET ALL
        // ============================================================
        public async Task<List<GetOrganizationResponse>> GetAllOrganizations(
            IFINOVAServiceUser serviceUser)
        {
            List<GetOrganizationResponse> response =
                new List<GetOrganizationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapOrganization(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET ACTIVE
        // ============================================================
        public async Task<List<GetOrganizationResponse>> GetActiveOrganizations(
            IFINOVAServiceUser serviceUser)
        {
            List<GetOrganizationResponse> response =
                new List<GetOrganizationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapOrganization(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY ORGANIZATION TYPE ID
        // ============================================================
        public async Task<List<GetOrganizationResponse>>
            GetOrganizationsByOrganizationTypeID(
                int organizationTypeID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetOrganizationResponse> response =
                new List<GetOrganizationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[org].[OrganizationMaster_GetByOrganizationTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationTypeID",
                organizationTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapOrganization(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON ORGANIZATION MAPPER
        // ============================================================
        private GetOrganizationResponse MapOrganization(
            System.Data.IDataReader dataReader)
        {
            GetOrganizationResponse row =
                new GetOrganizationResponse();

            row.OrganizationID =
                GetInt64Value(
                    dataReader,
                    "OrganizationID").Value;

            row.OrganizationUID =
                dataReader["OrganizationUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["OrganizationUID"];

            row.OrganizationCode =
                GetStringValue(
                    dataReader,
                    "OrganizationCode");

            row.OrganizationName =
                GetStringValue(
                    dataReader,
                    "OrganizationName");

            row.OrganizationTypeID =
                GetInt32Value(
                    dataReader,
                    "OrganizationTypeID");

            row.DisplayName =
                GetStringValue(
                    dataReader,
                    "DisplayName");

            row.LegalName =
                GetStringValue(
                    dataReader,
                    "LegalName");

            row.Email =
                GetStringValue(
                    dataReader,
                    "Email");

            row.MobileNo =
                GetStringValue(
                    dataReader,
                    "MobileNo");

            row.PhoneNo =
                GetStringValue(
                    dataReader,
                    "PhoneNo");

            row.Website =
                GetStringValue(
                    dataReader,
                    "Website");

            row.RegistrationNo =
                GetStringValue(
                    dataReader,
                    "RegistrationNo");

            row.GSTIN =
                GetStringValue(
                    dataReader,
                    "GSTIN");

            row.PAN =
                GetStringValue(
                    dataReader,
                    "PAN");

            row.TAN =
                GetStringValue(
                    dataReader,
                    "TAN");

            row.LogoPath =
                GetStringValue(
                    dataReader,
                    "LogoPath");

            row.CurrencyID =
                GetInt32Value(
                    dataReader,
                    "CurrencyID");

            row.TimeZoneID =
                GetInt32Value(
                    dataReader,
                    "TimeZoneID");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
    }
}
