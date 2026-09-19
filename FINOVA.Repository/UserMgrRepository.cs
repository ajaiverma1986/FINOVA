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
        // ============================================================
        // CREATE USER ADDRESS
        // ============================================================
        public async Task<long> CreateUserAddress(
            CreateUserAddressRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeId",
                request.AddressTypeId);

            _database.AddInParameter(
                dbCommand,
                "@Pincode",
                request.Pincode);

            _database.AddInParameter(
                dbCommand,
                "@PincodeDataId",
                request.PincodeDataId);

            _database.AddInParameter(
                dbCommand,
                "@Address1",
                request.Address1);

            _database.AddInParameter(
                dbCommand,
                "@Address2",
                request.Address2);

            _database.AddInParameter(
                dbCommand,
                "@Address3",
                request.Address3);

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
        // UPDATE USER ADDRESS
        // ============================================================
        public async Task<SimpleResponse> UpdateUserAddress(
            UpdateUserAddressRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserAddressID",
                request.UserAddressID);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@AddressTypeId",
                request.AddressTypeId);

            _database.AddInParameter(
                dbCommand,
                "@Pincode",
                request.Pincode);

            _database.AddInParameter(
                dbCommand,
                "@PincodeDataId",
                request.PincodeDataId);

            _database.AddInParameter(
                dbCommand,
                "@Address1",
                request.Address1);

            _database.AddInParameter(
                dbCommand,
                "@Address2",
                request.Address2);

            _database.AddInParameter(
                dbCommand,
                "@Address3",
                request.Address3);

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
        // DELETE USER ADDRESS
        // ============================================================
        public async Task<SimpleResponse> DeleteUserAddress(
            long userAddressID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserAddressID",
                userAddressID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET USER ADDRESS BY ID
        // ============================================================
        public async Task<GetUserAddressResponse?> GetUserAddressByID(
            long userAddressID,
            IFINOVAServiceUser serviceUser)
        {
            GetUserAddressResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserAddressID",
                userAddressID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapUserAddress(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL USER ADDRESSES
        // ============================================================
        public async Task<List<GetUserAddressResponse>> GetAllUserAddresses(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserAddressResponse> response =
                new List<GetUserAddressResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserAddress(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE USER ADDRESSES
        // ============================================================
        public async Task<List<GetUserAddressResponse>> GetActiveUserAddresses(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserAddressResponse> response =
                new List<GetUserAddressResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserAddress(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ADDRESSES BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserAddressResponse>>
            GetUserAddressesByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserAddressResponse> response =
                new List<GetUserAddressResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_GetByUserMasterID]");

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
                        MapUserAddress(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE ADDRESSES BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserAddressResponse>>
            GetActiveUserAddressesByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserAddressResponse> response =
                new List<GetUserAddressResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserAddressMaster_GetActiveByUserMasterID]");

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
                        MapUserAddress(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON USER ADDRESS MAPPER
        // ============================================================
        private GetUserAddressResponse MapUserAddress(
            System.Data.IDataReader dataReader)
        {
            GetUserAddressResponse row =
                new GetUserAddressResponse();

            row.UserAddressID =
                GetInt64Value(
                    dataReader,
                    "UserAddressID").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId").Value;

            row.AddressTypeId =
                GetInt32Value(
                    dataReader,
                    "AddressTypeId").Value;

            row.AddressTypeName =
                GetStringValue(
                    dataReader,
                    "AddressTypeName");

            row.Pincode =
                GetStringValue(
                    dataReader,
                    "Pincode");

            row.PincodeDataId =
                GetInt64Value(
                    dataReader,
                    "PincodeDataId").Value;

            row.Address1 =
                GetStringValue(
                    dataReader,
                    "Address1");

            row.Address2 =
                GetStringValue(
                    dataReader,
                    "Address2");

            row.Address3 =
                GetStringValue(
                    dataReader,
                    "Address3");

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
        // CREATE USER KYC
        // ============================================================
        public async Task<long> CreateUserKyc(
            CreateUserKycRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@KycID",
                request.KycID);

            _database.AddInParameter(
                dbCommand,
                "@DocumentNo",
                request.DocumentNo);

            _database.AddInParameter(
                dbCommand,
                "@FileUrl",
                request.FileUrl);

            _database.AddInParameter(
                dbCommand,
                "@MediaExtension",
                request.MediaExtension);

            _database.AddInParameter(
                dbCommand,
                "@MediaContentType",
                request.MediaContentType);

            _database.AddInParameter(
                dbCommand,
                "@RejectedReason",
                request.RejectedReason);

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
        // UPDATE USER KYC
        // ============================================================
        public async Task<SimpleResponse> UpdateUserKyc(
            UpdateUserKycRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserKYCID",
                request.UserKYCID);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@KycID",
                request.KycID);

            _database.AddInParameter(
                dbCommand,
                "@DocumentNo",
                request.DocumentNo);

            _database.AddInParameter(
                dbCommand,
                "@FileUrl",
                request.FileUrl);

            _database.AddInParameter(
                dbCommand,
                "@MediaExtension",
                request.MediaExtension);

            _database.AddInParameter(
                dbCommand,
                "@MediaContentType",
                request.MediaContentType);

            _database.AddInParameter(
                dbCommand,
                "@RejectedReason",
                request.RejectedReason);

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
        // DELETE USER KYC
        // ============================================================
        public async Task<SimpleResponse> DeleteUserKyc(
            long userKYCID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserKYCID",
                userKYCID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET USER KYC BY ID
        // ============================================================
        public async Task<GetUserKycResponse?> GetUserKycByID(
            long userKYCID,
            IFINOVAServiceUser serviceUser)
        {
            GetUserKycResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserKYCID",
                userKYCID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapUserKyc(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL USER KYC
        // ============================================================
        public async Task<List<GetUserKycResponse>> GetAllUserKyc(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserKycResponse> response =
                new List<GetUserKycResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserKyc(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE USER KYC
        // ============================================================
        public async Task<List<GetUserKycResponse>> GetActiveUserKyc(
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserKycResponse> response =
                new List<GetUserKycResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserKyc(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET USER KYC BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserKycResponse>>
            GetUserKycByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserKycResponse> response =
                new List<GetUserKycResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_GetByUserMasterID]");

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
                        MapUserKyc(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE USER KYC BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserKycResponse>>
            GetActiveUserKycByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserKycResponse> response =
                new List<GetUserKycResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserKycMaster_GetActiveByUserMasterID]");

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
                        MapUserKyc(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON USER KYC MAPPER
        // ============================================================
        private GetUserKycResponse MapUserKyc(
            System.Data.IDataReader dataReader)
        {
            GetUserKycResponse row =
                new GetUserKycResponse();

            row.UserKYCID =
                GetInt64Value(
                    dataReader,
                    "UserKYCID").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId").Value;

            row.KycID =
                GetInt32Value(
                    dataReader,
                    "KycID").Value;

            row.KycTypeName =
                GetStringValue(
                    dataReader,
                    "KycTypeName");

            row.DocumentNo =
                GetStringValue(
                    dataReader,
                    "DocumentNo");

            row.FileUrl =
                GetStringValue(
                    dataReader,
                    "FileUrl");

            row.MediaExtension =
                GetStringValue(
                    dataReader,
                    "MediaExtension");

            row.MediaContentType =
                GetStringValue(
                    dataReader,
                    "MediaContentType");

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
        // CREATE USER BANK ACCOUNT
        // ============================================================
        public async Task<long> CreateUserBankAccount(
            CreateUserBankAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@BankId",
                request.BankId);

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
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@Filename",
                request.FileUrl);

            _database.AddInParameter(
                dbCommand,
                "@RejectedReason",
                request.RejectedReason);

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
        // UPDATE USER BANK ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> UpdateUserBankAccount(
            UpdateUserBankAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@OriginatorAccountID",
                request.OriginatorAccountID);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@BankId",
                request.BankId);

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
                "@BranchAddress",
                request.BranchAddress);

            _database.AddInParameter(
                dbCommand,
                "@Filename",
                request.FileUrl);

            _database.AddInParameter(
                dbCommand,
                "@RejectedReason",
                request.RejectedReason);

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
        // DELETE USER BANK ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> DeleteUserBankAccount(
            long originatorAccountID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@OriginatorAccountID",
                originatorAccountID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET USER BANK ACCOUNT BY ID
        // ============================================================
        public async Task<GetUserBankAccountResponse?> GetUserBankAccountByID(
            long originatorAccountID,
            IFINOVAServiceUser serviceUser)
        {
            GetUserBankAccountResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@OriginatorAccountID",
                originatorAccountID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapUserBankAccount(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL USER BANK ACCOUNTS
        // ============================================================
        public async Task<List<GetUserBankAccountResponse>>
            GetAllUserBankAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserBankAccountResponse> response =
                new List<GetUserBankAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserBankAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE USER BANK ACCOUNTS
        // ============================================================
        public async Task<List<GetUserBankAccountResponse>>
            GetActiveUserBankAccounts(
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserBankAccountResponse> response =
                new List<GetUserBankAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserBankAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserBankAccountResponse>>
            GetUserBankAccountsByUserMasterID(
                long userMasterID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserBankAccountResponse> response =
                new List<GetUserBankAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_GetByUserMasterID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserBankAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserBankAccountResponse>>
            GetActiveUserBankAccountsByUserMasterID(
                long userMasterID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserBankAccountResponse> response =
                new List<GetUserBankAccountResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserBankAccountMaster_GetActiveByUserMasterID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserBankAccount(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON USER BANK ACCOUNT MAPPER
        // ============================================================
        private GetUserBankAccountResponse MapUserBankAccount(
            System.Data.IDataReader dataReader)
        {
            GetUserBankAccountResponse row =
                new GetUserBankAccountResponse();

            row.OriginatorAccountID =
                GetInt64Value(
                    dataReader,
                    "OriginatorAccountID").Value;

            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID").Value;

            row.BankId =
                GetInt64Value(
                    dataReader,
                    "BankId").Value;

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

            row.BranchAddress =
                GetStringValue(
                    dataReader,
                    "BranchAddress");

            row.Filename =
                GetStringValue(
                    dataReader,
                    "Filename");

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

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.CreatedOn =
                GetDateTimeValue(
                    dataReader,
                    "CreatedOn");

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            row.UpdatedOn =
                GetDateTimeValue(
                    dataReader,
                    "UpdatedOn");

            return row;
        }
        // ============================================================
        // CREATE USER CONFIGURATION
        // ============================================================
        public async Task<long> CreateUserConfiguration(
            CreateUserConfigurationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@MinTxn",
                request.MinTxn);

            _database.AddInParameter(
                dbCommand,
                "@MaxTxn",
                request.MaxTxn);

            _database.AddInParameter(
                dbCommand,
                "@ChargeTypeOn",
                request.ChargeTypeOn);

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@MaxPayinamount",
                request.MaxPayinamount);

            _database.AddInParameter(
                dbCommand,
                "@MaxNoofcountPayin",
                request.MaxNoofcountPayin);

            _database.AddInParameter(
                dbCommand,
                "@SameAmountPayinAllowed",
                request.SameAmountPayinAllowed);

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
        // UPDATE USER CONFIGURATION
        // ============================================================
        public async Task<SimpleResponse> UpdateUserConfiguration(
            UpdateUserConfigurationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ConfigurationId",
                request.ConfigurationId);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@MinTxn",
                request.MinTxn);

            _database.AddInParameter(
                dbCommand,
                "@MaxTxn",
                request.MaxTxn);

            _database.AddInParameter(
                dbCommand,
                "@ChargeTypeOn",
                request.ChargeTypeOn);

            _database.AddInParameter(
                dbCommand,
                "@PlanId",
                request.PlanId);

            _database.AddInParameter(
                dbCommand,
                "@MaxPayinamount",
                request.MaxPayinamount);

            _database.AddInParameter(
                dbCommand,
                "@MaxNoofcountPayin",
                request.MaxNoofcountPayin);

            _database.AddInParameter(
                dbCommand,
                "@SameAmountPayinAllowed",
                request.SameAmountPayinAllowed);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // DELETE USER CONFIGURATION
        // ============================================================
        public async Task<SimpleResponse> DeleteUserConfiguration(
            long configurationId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ConfigurationId",
                configurationId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET USER CONFIGURATION BY ID
        // ============================================================
        public async Task<GetUserConfigurationResponse?>
            GetUserConfigurationByID(
                long configurationId,
                IFINOVAServiceUser serviceUser)
        {
            GetUserConfigurationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ConfigurationId",
                configurationId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserConfiguration(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL USER CONFIGURATIONS
        // ============================================================
        public async Task<List<GetUserConfigurationResponse>>
            GetAllUserConfigurations(
                IFINOVAServiceUser serviceUser)
        {
            List<GetUserConfigurationResponse> response =
                new List<GetUserConfigurationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserConfiguration(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET USER CONFIGURATION BY USER MASTER ID
        // ============================================================
        public async Task<GetUserConfigurationResponse?>
            GetUserConfigurationByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            GetUserConfigurationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserConfiguration_GetByUserMasterID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                userMasterId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserConfiguration(dataReader);
                }
            }

            return response;
        }
        private GetUserConfigurationResponse MapUserConfiguration(
    System.Data.IDataReader dataReader)
        {
            GetUserConfigurationResponse row =
                new GetUserConfigurationResponse();

            row.ConfigurationId =
                GetInt64Value(
                    dataReader,
                    "ConfigurationId").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId").Value;

            row.MinTxn =
                dataReader["MinTxn"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["MinTxn"]);

            row.MaxTxn =
                dataReader["MaxTxn"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["MaxTxn"]);

            row.ChargeTypeOn =
                GetInt32Value(
                    dataReader,
                    "ChargeTypeOn").Value;

            row.PlanId =
                GetInt32Value(
                    dataReader,
                    "PlanId").Value;

            row.PlanName =
                GetStringValue(
                    dataReader,
                    "PlanName");

            row.MaxPayinamount =
                dataReader["MaxPayinamount"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(dataReader["MaxPayinamount"]);

            row.MaxNoofcountPayin =
                GetInt32Value(
                    dataReader,
                    "MaxNoofcountPayin").Value;

            row.SameAmountPayinAllowed =
                GetInt32Value(
                    dataReader,
                    "SameAmountPayinAllowed").Value;

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
        // CREATE OTHER DETAILS
        // ============================================================
        public async Task<long> CreateOtherDetails(
            CreateOtherDetailsRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@Pancard",
                request.Pancard);

            _database.AddInParameter(
                dbCommand,
                "@AadharCard",
                request.AadharCard);

            _database.AddInParameter(
                dbCommand,
                "@GSTNo",
                request.GSTNo);

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
        // UPDATE OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> UpdateOtherDetails(
            UpdateOtherDetailsRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_Update]");

            _database.AddInParameter(
                dbCommand,
                "@OtherDetailId",
                request.OtherDetailId);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@Pancard",
                request.Pancard);

            _database.AddInParameter(
                dbCommand,
                "@AadharCard",
                request.AadharCard);

            _database.AddInParameter(
                dbCommand,
                "@GSTNo",
                request.GSTNo);

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
        // DELETE OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> DeleteOtherDetails(
            long otherDetailId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@OtherDetailId",
                otherDetailId);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // GET OTHER DETAILS BY ID
        // ============================================================
        public async Task<GetOtherDetailsResponse?> GetOtherDetailsByID(
            long otherDetailId,
            IFINOVAServiceUser serviceUser)
        {
            GetOtherDetailsResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@OtherDetailId",
                otherDetailId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapOtherDetails(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // GET ALL OTHER DETAILS
        // ============================================================
        public async Task<List<GetOtherDetailsResponse>>
            GetAllOtherDetails(
                IFINOVAServiceUser serviceUser)
        {
            List<GetOtherDetailsResponse> response =
                new List<GetOtherDetailsResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapOtherDetails(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS
        // ============================================================
        public async Task<List<GetOtherDetailsResponse>>
            GetActiveOtherDetails(
                IFINOVAServiceUser serviceUser)
        {
            List<GetOtherDetailsResponse> response =
                new List<GetOtherDetailsResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapOtherDetails(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET OTHER DETAILS BY USER MASTER ID
        // ============================================================
        public async Task<List<GetOtherDetailsResponse>>
            GetOtherDetailsByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetOtherDetailsResponse> response =
                new List<GetOtherDetailsResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_GetByUserMasterID]");

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
                        MapOtherDetails(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS BY USER MASTER ID
        // ============================================================
        public async Task<List<GetOtherDetailsResponse>>
            GetActiveOtherDetailsByUserMasterID(
                long userMasterId,
                IFINOVAServiceUser serviceUser)
        {
            List<GetOtherDetailsResponse> response =
                new List<GetOtherDetailsResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[OtherDetails_GetActiveByUserMasterID]");

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
                        MapOtherDetails(dataReader));
                }
            }

            return response;
        }
        private GetOtherDetailsResponse MapOtherDetails(
    System.Data.IDataReader dataReader)
        {
            GetOtherDetailsResponse row =
                new GetOtherDetailsResponse();

            row.OtherDetailId =
                GetInt64Value(
                    dataReader,
                    "OtherDetailId").Value;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId");

            row.Pancard =
                GetStringValue(
                    dataReader,
                    "Pancard");

            row.AadharCard =
                GetStringValue(
                    dataReader,
                    "AadharCard");

            row.GSTNo =
                GetStringValue(
                    dataReader,
                    "GSTNo");

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
    }
}
