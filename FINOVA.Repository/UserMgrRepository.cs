using FINOVA.Database;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.UserMgr;
using FINOVA.Repository.Shared;



namespace FINOVA.Repository
{
    public class UserMgrRepository: BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public UserMgrRepository()
        {
            _database = new FINOVADatabase();
        }
        // ============================================================
        // USER MASTER - CREATE
        // ============================================================
        public async Task<long> CreateUserMaster(
            CreateUserMasterRequest request,string passwo,
            IFINOVAServiceUser serviceUser)
        {
            long userMasterID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                request.UserTypeId);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

           
            _database.AddInParameter(
                dbCommand,
                "@Password",
                passwo);

            _database.AddInParameter(
                dbCommand,
                "@Title",
                request.Title);

            _database.AddInParameter(
                dbCommand,
                "@FirstName",
                request.FirstName);

            _database.AddInParameter(
                dbCommand,
                "@MiddleName",
                request.MiddleName);

            _database.AddInParameter(
                dbCommand,
                "@LastName",
                request.LastName);

            _database.AddInParameter(
                dbCommand,
                "@GenderID",
                request.GenderID);

            _database.AddInParameter(
                dbCommand,
                "@IsPasswordExpired",
                request.IsPasswordExpired);

            _database.AddInParameter(
                dbCommand,
                "@UserId",
                request.UserId);

            _database.AddInParameter(
                dbCommand,
                "@IsLocked",
                request.IsLocked);

            _database.AddInParameter(
                dbCommand,
                "@LockedTill",
                request.LockedTill);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@EmailId",
                request.EmailId);

            _database.AddInParameter(
                dbCommand,
                "@MobileNo",
                request.MobileNo);

            _database.AddInParameter(
                dbCommand,
                "@RemarkReason",
                request.RemarkReason);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            userMasterID =
                GetIDOutputLong(dbCommand);

            return userMasterID;
        }


        // ============================================================
        // USER MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserMaster(
            UpdateUserMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                request.UserTypeId);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@Title",
                request.Title);

            _database.AddInParameter(
                dbCommand,
                "@FirstName",
                request.FirstName);

            _database.AddInParameter(
                dbCommand,
                "@MiddleName",
                request.MiddleName);

            _database.AddInParameter(
                dbCommand,
                "@LastName",
                request.LastName);

            _database.AddInParameter(
                dbCommand,
                "@GenderID",
                request.GenderID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@EmailId",
                request.EmailId);

            _database.AddInParameter(
                dbCommand,
                "@MobileNo",
                request.MobileNo);

            _database.AddInParameter(
                dbCommand,
                "@RemarkReason",
                request.RemarkReason);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // USER MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteUserMaster(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }
        // ============================================================
        // USER MASTER - LOCK USER
        // ============================================================
        public async Task<SimpleResponse> LockUserMaster(
            LockUserMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_Lock]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@LockedTill",
                request.LockedTill);

            _database.AddInParameter(
                dbCommand,
                "@RemarkReason",
                request.RemarkReason);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }
        public async Task<SimpleResponse> ChangeUserPassword(
    ChangeUserPasswordRequest request,string pass,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_ChangePassword]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@Password",
                pass);

            _database.AddInParameter(
                dbCommand,
                "@IsPasswordExpired",
                request.IsPasswordExpired);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }
        public async Task<SimpleResponse> UnlockUserMaster(
    long userMasterID,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_Unlock]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }

        // ============================================================
        // USER MASTER - GET BY ID
        // ============================================================
        public async Task<GetUserMasterResponse?> GetUserMasterByID(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            GetUserMasterResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserMaster(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // USER MASTER - GET ALL
        // ============================================================
        public async Task<List<GetUserMasterResponse>> GetAllUserMasters(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserMasterResponse> response =
                new List<GetUserMasterResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserMaster(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetUserMasterResponse>> GetActiveUserMasters(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserMasterResponse> response =
                new List<GetUserMasterResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserMaster(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY ORGANIZATION ID
        // ============================================================
        public async Task<List<GetUserMasterResponse>>
            GetUserMastersByOrganizationID(
                long organizationID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserMasterResponse> response =
                new List<GetUserMasterResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetByOrganizationID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                organizationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserMaster(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY USER TYPE ID
        // ============================================================
        public async Task<List<GetUserMasterResponse>>
            GetUserMastersByUserTypeID(
                int userTypeID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserMasterResponse> response =
                new List<GetUserMasterResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetByUserTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                userTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserMaster(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY USER NAME
        // ============================================================
        public async Task<GetUserMasterResponse?> GetUserMasterByUserName(
            string userName,
            IFINOVAServiceUser serviceUser)
        {
            GetUserMasterResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetByUserName]");

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                userName);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserMaster(dataReader);
                }
            }

            return response;
        }
        private GetUserMasterResponse MapUserMaster(
    System.Data.IDataReader dataReader)
        {
            GetUserMasterResponse row =
                new GetUserMasterResponse();

            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID").Value;

            row.UserTypeId =
                GetInt32Value(
                    dataReader,
                    "UserTypeId");

            row.UserTypeName =
                GetStringValue(
                    dataReader,
                    "UserTypeName");

            row.OrganizationID =
                GetInt32Value(
                    dataReader,
                    "OrganizationID");

            row.OrganizationName =
                GetStringValue(
                    dataReader,
                    "OrganizationName");

            row.DomainUserName =
                GetStringValue(
                    dataReader,
                    "DomainUserName");

            row.UserName =
                GetStringValue(
                    dataReader,
                    "UserName");

            row.Title =
                GetStringValue(
                    dataReader,
                    "Title");

            row.FirstName =
                GetStringValue(
                    dataReader,
                    "FirstName");

            row.MiddleName =
                GetStringValue(
                    dataReader,
                    "MiddleName");

            row.LastName =
                GetStringValue(
                    dataReader,
                    "LastName");

            row.DisplayName =
                GetStringValue(
                    dataReader,
                    "DisplayName");

            row.GenderID =
                GetInt32Value(
                    dataReader,
                    "GenderID").Value;

            row.IsPasswordExpired =
                dataReader["IsPasswordExpired"] != DBNull.Value
                && Convert.ToBoolean(
                    dataReader["IsPasswordExpired"]);

            row.UserId =
                GetInt64Value(
                    dataReader,
                    "UserId").Value;

            row.IsLocked =
                dataReader["IsLocked"] != DBNull.Value
                && Convert.ToBoolean(
                    dataReader["IsLocked"]);

            row.LockedTill =
                dataReader["LockedTill"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["LockedTill"];

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.EmailId =
                GetStringValue(
                    dataReader,
                    "EmailId");

            row.MobileNo =
                GetStringValue(
                    dataReader,
                    "MobileNo");

            row.RemarkReason =
                GetStringValue(
                    dataReader,
                    "RemarkReason");

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
