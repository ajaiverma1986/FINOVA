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
        // USER MASTER - GENERATE USER CODE
        // ============================================================
        public async Task<GenerateUserCodeResponse?> GenerateUserCode(
            int userTypeID,
            IFINOVAServiceUser serviceUser)
        {
            GenerateUserCodeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[usp_generateusercode]");

            _database.AddInParameter(
                dbCommand,
                "@UserTypeID",
                userTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        new GenerateUserCodeResponse
                        {
                            UserCode =
                                GetStringValue(
                                    dataReader,
                                    "UserCode")
                        };
                }
            }

            return response;
        }
        // ============================================================
        // USER MASTER - CREATE
        // ============================================================
        public async Task<long> CreateUserMaster(
            CreateUserMasterRequest request,string passwo,string username,
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
                username);

           
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

            // =========================================================
            // USER DETAILS
            // =========================================================

            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID").Value;

            row.ParentId =
                GetInt64Value(
                    dataReader,
                    "ParentId");

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
                    "FirstName") ?? string.Empty;

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


            // =========================================================
            // DISTRIBUTOR DETAILS
            // =========================================================

            row.DSUserMasterID =
                GetInt64Value(
                    dataReader,
                    "DSUserMasterID");

            row.DSCode =
                GetStringValue(
                    dataReader,
                    "DSCode");

            row.DSName =
                GetStringValue(
                    dataReader,
                    "DSName");

            row.DSEmail =
                GetStringValue(
                    dataReader,
                    "DSEmail");

            row.DSMobileNo =
                GetStringValue(
                    dataReader,
                    "DSMobileNo");


            // =========================================================
            // MASTER DISTRIBUTOR DETAILS
            // =========================================================

            row.MDSUserMasterID =
                GetInt64Value(
                    dataReader,
                    "MDSUserMasterID");

            row.MDSCode =
                GetStringValue(
                    dataReader,
                    "MDSCode");

            row.MDSName =
                GetStringValue(
                    dataReader,
                    "MDSName");

            row.MDSEmail =
                GetStringValue(
                    dataReader,
                    "MDSEmail");

            row.MDSMobileNo =
                GetStringValue(
                    dataReader,
                    "MDSMobileNo");

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
        // ============================================================
        // CREATE USER ROLE
        // ============================================================
        public async Task<long> CreateUserRole(
            CreateUserRoleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long outputId = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                request.ApplicationID);

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

            await _database.ExecuteNonQueryAsync(
                dbCommand);

            outputId =
                GetIDOutputLong(dbCommand);

            return outputId;
        }
        // ============================================================
        // UPDATE USER ROLE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserRole(
            UpdateUserRoleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response =
                new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserRoleID",
                request.UserRoleID);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                request.UserMasterID);

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                request.ApplicationID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(
                dbCommand);

            response.Result = request.UserRoleID;

            return response;
        }
        // ============================================================
        // DELETE USER ROLE
        // ============================================================
        public async Task<SimpleResponse> DeleteUserRole(
            long userRoleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response =
                new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserRoleID",
                userRoleID);

            await _database.ExecuteNonQueryAsync(
                dbCommand);

            response.Result = userRoleID;

            return response;
        }
        // ============================================================
        // GET USER ROLE BY ID
        // ============================================================
        public async Task<GetUserRoleResponse?> GetUserRoleByID(
            long userRoleID,
            IFINOVAServiceUser serviceUser)
        {
            GetUserRoleResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserRoleID",
                userRoleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserRole(dataReader);
                }
            }

            return response;
        }
        // ============================================================
        // GET ALL USER ROLES
        // ============================================================
        public async Task<List<GetUserRoleResponse>> GetAllUserRoles(
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserRoleResponse> response =
                new List<GetUserRoleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_GetAll]");

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
                        MapUserRole(dataReader));
                }
            }

            return response;
        }
        // ============================================================
        // GET USER ROLES BY USER MASTER ID
        // ============================================================
        public async Task<List<GetUserRoleResponse>> GetUserRolesByUserMasterID(
            long userMasterID,
            byte? applicationID,
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserRoleResponse> response =
                new List<GetUserRoleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_GetByUserMasterID]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

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
                        MapUserRole(dataReader));
                }
            }

            return response;
        }
        // ============================================================
        // GET USERS BY ROLE
        // ============================================================
        public async Task<List<GetUserRoleResponse>> GetUserRolesByRoleID(
            short roleID,
            byte? applicationID,
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserRoleResponse> response =
                new List<GetUserRoleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_GetByRoleID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

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
                        MapUserRole(dataReader));
                }
            }

            return response;
        }
        // ============================================================
        // GET ACTIVE USER ROLES
        // USED FOR AUTHORIZATION
        // ============================================================
        public async Task<List<GetActiveUserRoleResponse>> GetActiveUserRoles(
            long userMasterID,
            byte applicationID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetActiveUserRoleResponse> response =
                new List<GetActiveUserRoleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[UserRole_GetActiveRoles]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    GetActiveUserRoleResponse row =
                        new GetActiveUserRoleResponse();

                    row.UserRoleID =
                        GetInt64Value(
                            dataReader,
                            "UserRoleID").Value;

                    row.UserMasterID =
                        GetInt64Value(
                            dataReader,
                            "UserMasterID").Value;

                    row.RoleID =
                        Convert.ToInt16(
                            dataReader["RoleID"]);

                    row.RoleName =
                        GetStringValue(
                            dataReader,
                            "RoleName");

                    row.ApplicationID =
                        Convert.ToByte(
                            dataReader["ApplicationID"]);

                    response.Add(row);
                }
            }

            return response;
        }
        // ============================================================
        // MAP USER ROLE
        // ============================================================
        private GetUserRoleResponse MapUserRole(
            System.Data.IDataReader dataReader)
        {
            GetUserRoleResponse row =
                new GetUserRoleResponse();

            row.UserRoleID =
                GetInt64Value(
                    dataReader,
                    "UserRoleID").Value;

            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID").Value;

            row.UserName =
                GetStringValue(
                    dataReader,
                    "UserName");

            row.DisplayName =
                GetStringValue(
                    dataReader,
                    "DisplayName");


            // ========================================================
            // OPTIONAL USER INFORMATION
            // ========================================================

            if (ColumnExists(dataReader, "FirstName"))
            {
                row.FirstName =
                    GetStringValue(
                        dataReader,
                        "FirstName");
            }

            if (ColumnExists(dataReader, "MiddleName"))
            {
                row.MiddleName =
                    GetStringValue(
                        dataReader,
                        "MiddleName");
            }

            if (ColumnExists(dataReader, "LastName"))
            {
                row.LastName =
                    GetStringValue(
                        dataReader,
                        "LastName");
            }

            if (ColumnExists(dataReader, "EmailId"))
            {
                row.EmailId =
                    GetStringValue(
                        dataReader,
                        "EmailId");
            }

            if (ColumnExists(dataReader, "MobileNo"))
            {
                row.MobileNo =
                    GetStringValue(
                        dataReader,
                        "MobileNo");
            }


            // ========================================================
            // ROLE
            // ========================================================

            row.RoleID =
                Convert.ToInt16(
                    dataReader["RoleID"]);

            row.RoleName =
                GetStringValue(
                    dataReader,
                    "RoleName");

            if (ColumnExists(
                dataReader,
                "RoleDescription"))
            {
                row.RoleDescription =
                    GetStringValue(
                        dataReader,
                        "RoleDescription");
            }


            // ========================================================
            // APPLICATION
            // ========================================================

            row.ApplicationID =
                Convert.ToByte(
                    dataReader["ApplicationID"]);


            // ========================================================
            // STATUS
            // ========================================================

            row.Status =
                Convert.ToByte(
                    dataReader["Status"]);

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");


            // ========================================================
            // CREATED
            // ========================================================

            if (ColumnExists(dataReader, "CreatedOn"))
            {
                row.CreatedOn =
                    GetDateTimeOffsetValue(
                        dataReader,
                        "CreatedOn").Value;
            }

            if (ColumnExists(dataReader, "Createdby"))
            {
                row.CreatedBy =
                    GetInt64Value(
                        dataReader,
                        "Createdby").Value;
            }

            if (ColumnExists(
                dataReader,
                "CreatedByName"))
            {
                row.CreatedByName =
                    GetStringValue(
                        dataReader,
                        "CreatedByName");
            }


            // ========================================================
            // UPDATED
            // ========================================================

            if (ColumnExists(dataReader, "UpdatedOn"))
            {
                row.UpdatedOn =
                    GetNullableDateTimeOffset(
                        dataReader,
                        "UpdatedOn");
            }

            if (ColumnExists(dataReader, "Updatedby"))
            {
                row.UpdatedBy =
                    GetInt64Value(
                        dataReader,
                        "Updatedby");
            }

            if (ColumnExists(
                dataReader,
                "UpdatedByName"))
            {
                row.UpdatedByName =
                    GetStringValue(
                        dataReader,
                        "UpdatedByName");
            }

            return row;
        }
        private bool ColumnExists(
    System.Data.IDataReader dataReader,
    string columnName)
        {
            for (int i = 0;
                 i < dataReader.FieldCount;
                 i++)
            {
                if (string.Equals(
                    dataReader.GetName(i),
                    columnName,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        // ============================================================
        // USER MASTER - RESET PASSWORD
        // ============================================================
        public async Task<ResetUserPasswordResponse>
            ResetUserPassword(
                long userMasterID,
                string password,
                IFINOVAServiceUser serviceUser)
        {
            ResetUserPasswordResponse response =
                new ResetUserPasswordResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_ResetPassword]");


            // ========================================================
            // USER MASTER ID
            // ========================================================
            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);


            // ========================================================
            // PASSWORD
            // Password should already be hashed/encrypted by provider
            // ========================================================
            _database.AddInParameter(
                dbCommand,
                "@Password",
                password);


            // ========================================================
            // EXECUTE
            // ========================================================
            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response.IsPasswordReset =
                        dataReader["IsPasswordReset"] != DBNull.Value &&
                        Convert.ToBoolean(
                            dataReader["IsPasswordReset"]);

                    response.UserMasterID =
                        GetInt64Value(
                            dataReader,
                            "UserMasterID").Value;

                    response.Message =
                        GetStringValue(
                            dataReader,
                            "Message");
                }
            }

            return response;
        }
        // ============================================================
        // USER MASTER - MAP PARENT
        // ============================================================
        public async Task<MapUserParentResponse?> MapUserParent(
            long userMasterID,
            long parentId,
            IFINOVAServiceUser serviceUser)
        {
            MapUserParentResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_MapParent]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterID",
                userMasterID);

            _database.AddInParameter(
                dbCommand,
                "@ParentId",
                parentId);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = new MapUserParentResponse
                    {
                        UserMasterID =
                            GetInt64Value(
                                dataReader,
                                "UserMasterID").Value,

                        ParentId =
                            GetInt64Value(
                                dataReader,
                                "ParentId"),

                        UserTypeId =
                            GetInt32Value(
                                dataReader,
                                "UserTypeId"),

                        OrganizationID =
                            GetInt32Value(
                                dataReader,
                                "OrganizationID").Value,

                        UserName =
                            GetStringValue(
                                dataReader,
                                "UserName"),

                        FirstName =
                            GetStringValue(
                                dataReader,
                                "FirstName"),

                        MiddleName =
                            GetStringValue(
                                dataReader,
                                "MiddleName"),

                        LastName =
                            GetStringValue(
                                dataReader,
                                "LastName"),

                        DisplayName =
                            GetStringValue(
                                dataReader,
                                "DisplayName"),

                        UpdatedOn =
                            GetDateTimeOffsetValue(
                                dataReader,
                                "UpdatedOn"),

                        UpdatedBy =
                            GetInt64Value(
                                dataReader,
                                "UpdatedBy")
                    };
                }
            }

            return response;
        }
        // ============================================================
        // USER MASTER - GET USERS BY PARENT ID
        // ============================================================
        public async Task<List<GetUserMasterResponse>> GetUsersByParentId(
            long parentId,
            int? userTypeId,
            IFINOVAServiceUser serviceUser)
        {
            List<GetUserMasterResponse> response =
                new List<GetUserMasterResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserMasters_GetByParentId]");

            _database.AddInParameter(
                dbCommand,
                "@ParentId",
                parentId);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                userTypeId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    GetUserMasterResponse user =
                        MapUserMaster(dataReader);

                    response.Add(user);
                }
            }

            return response;
        }
        public async Task<long> CreateUserWallet(
    CreateUserWalletRequest request,
    IFINOVAServiceUser serviceUser)
        {
            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_Create]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@AvailableLimit",
                request.AvailableLimit);

            _database.AddInParameter(
                dbCommand,
                "@ThresoldLimit",
                request.ThresoldLimit);

            _database.AddInParameter(
                dbCommand,
                "@RemarkReason",
                request.RemarkReason);

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
                System.Data.DbType.Int64,
                sizeof(long));

            await _database.ExecuteNonQueryAsync(dbCommand);

            return Convert.ToInt64(
                _database.GetParameterValue(
                    dbCommand,
                    "@Out_ID"));
        }
        public async Task<UpdateUserWalletResponse?>
    UpdateUserWallet(
        UpdateUserWalletRequest request,
        IFINOVAServiceUser serviceUser)
        {
            UpdateUserWalletResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_Update]");

            _database.AddInParameter(
                dbCommand,
                "@UserDetailId",
                request.UserDetailId);

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@AvailableLimit",
                request.AvailableLimit);

            _database.AddInParameter(
                dbCommand,
                "@ThresoldLimit",
                request.ThresoldLimit);

            _database.AddInParameter(
                dbCommand,
                "@RemarkReason",
                request.RemarkReason);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = new UpdateUserWalletResponse
                    {
                        UserDetailId =
                            GetInt64Value(
                                dataReader,
                                "UserDetailId") ?? 0,

                        IsUpdated =
                            dataReader["IsUpdated"] != DBNull.Value &&
                            Convert.ToBoolean(
                                dataReader["IsUpdated"]),

                        Message =
                            GetStringValue(
                                dataReader,
                                "Message")
                    };
                }
            }

            return response;
        }
        public async Task<DeleteUserWalletResponse?>
    DeleteUserWallet(
        long userDetailId,
        IFINOVAServiceUser serviceUser)
        {
            DeleteUserWalletResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@UserDetailId",
                userDetailId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = new DeleteUserWalletResponse
                    {
                        UserDetailId =
                            GetInt64Value(
                                dataReader,
                                "UserDetailId") ?? 0,

                        IsDeleted =
                            dataReader["IsDeleted"] != DBNull.Value &&
                            Convert.ToBoolean(
                                dataReader["IsDeleted"]),

                        Message =
                            GetStringValue(
                                dataReader,
                                "Message")
                    };
                }
            }

            return response;
        }
        public async Task<GetUserWalletResponse?>
    GetUserWalletByID(
        long userDetailId,
        IFINOVAServiceUser serviceUser)
        {
            GetUserWalletResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@UserDetailId",
                userDetailId);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapUserWallet(dataReader);
                }
            }

            return response;
        }
        public async Task<List<GetUserWalletResponse>>
    GetUserWallets(
        GetUserWalletRequest request,
        IFINOVAServiceUser serviceUser)
        {
            List<GetUserWalletResponse> response =
                new List<GetUserWalletResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_GetAll]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapUserWallet(dataReader));
                }
            }

            return response;
        }
        private GetUserWalletResponse MapUserWallet(
    System.Data.IDataReader dataReader)
        {
            GetUserWalletResponse row =
                new GetUserWalletResponse();

            row.UserDetailId =
                GetInt64Value(
                    dataReader,
                    "UserDetailId") ?? 0;

            row.UserMasterId =
                GetInt64Value(
                    dataReader,
                    "UserMasterId");

            row.UserName =
                GetStringValue(
                    dataReader,
                    "UserName");

            row.AvailableLimit =
                dataReader["AvailableLimit"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["AvailableLimit"]);

            row.ThresoldLimit =
                dataReader["ThresoldLimit"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["ThresoldLimit"]);

            row.RemarkReason =
                GetStringValue(
                    dataReader,
                    "RemarkReason");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status") ?? 0;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(
                        dataReader["CreatedOn"]);

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy") ?? 0;

            row.CreatedByName =
                GetStringValue(
                    dataReader,
                    "CreatedByName");

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(
                        dataReader["UpdatedOn"]);

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            row.UpdatedByName =
                GetStringValue(
                    dataReader,
                    "UpdatedByName");

            return row;
        }
        public async Task<UpdateUserWalletThresoldLimitResponse?>
    UpdateUserWalletThresoldLimit(
        UpdateUserWalletThresoldLimitRequest request,
        IFINOVAServiceUser serviceUser)
        {
            UpdateUserWalletThresoldLimitResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_UpdateThresoldLimit]");

            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@ThresoldLimit",
                request.ThresoldLimit);

            _database.AddInParameter(
                dbCommand,
                "@ThresoldReason",
                request.ThresoldReason);

            _database.AddInParameter(
                dbCommand,
                "@ThresoldBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        new UpdateUserWalletThresoldLimitResponse
                        {
                            UserDetailId =
                                GetInt64Value(
                                    dataReader,
                                    "UserDetailId") ?? 0,

                            UserMasterId =
                                GetInt64Value(
                                    dataReader,
                                    "UserMasterId") ?? 0,

                            AvailableLimit =
                                dataReader["AvailableLimit"] == DBNull.Value
                                    ? 0
                                    : Convert.ToDecimal(
                                        dataReader["AvailableLimit"]),

                            ThresoldLimit =
                                dataReader["ThresoldLimit"] == DBNull.Value
                                    ? 0
                                    : Convert.ToDecimal(
                                        dataReader["ThresoldLimit"]),

                            ThresoldOn =
                                dataReader["ThresoldOn"] == DBNull.Value
                                    ? (DateTime?)null
                                    : Convert.ToDateTime(
                                        dataReader["ThresoldOn"]),

                            ThresoldBy =
                                GetInt64Value(
                                    dataReader,
                                    "ThresoldBy"),

                            ThresoldReason =
                                GetStringValue(
                                    dataReader,
                                    "ThresoldReason"),

                            IsUpdated =
                                dataReader["IsUpdated"] != DBNull.Value &&
                                Convert.ToBoolean(
                                    dataReader["IsUpdated"]),

                            Message =
                                GetStringValue(
                                    dataReader,
                                    "Message")
                        };
                }
            }

            return response;
        }
        public async Task<List<GetThresoldUserListResponse>>
    GetThresoldUserList(
        GetThresoldUserListRequest request,
        IFINOVAServiceUser serviceUser)
        {
            List<GetThresoldUserListResponse> response =
                new List<GetThresoldUserListResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[USR].[UserWallet_GetThresoldUserList]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@UserTypeId",
                request.UserTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ParentId",
                request.ParentId);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@SearchText",
                request.SearchText);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapThresoldUserList(dataReader));
                }
            }

            return response;
        }
        private GetThresoldUserListResponse MapThresoldUserList(
    System.Data.IDataReader dataReader)
        {
            GetThresoldUserListResponse row =
                new GetThresoldUserListResponse();

            // User Details
            row.UserMasterID =
                GetInt64Value(
                    dataReader,
                    "UserMasterID") ?? 0;

            row.ParentId =
                GetInt64Value(
                    dataReader,
                    "ParentId");

            row.UserTypeId =
                GetInt32Value(
                    dataReader,
                    "UserTypeId");

            row.OrganizationID =
                GetInt32Value(
                    dataReader,
                    "OrganizationID") ?? 0;

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

            row.FullName =
                GetStringValue(
                    dataReader,
                    "FullName");

            row.DisplayName =
                GetStringValue(
                    dataReader,
                    "DisplayName");

            row.EmailId =
                GetStringValue(
                    dataReader,
                    "EmailId");

            row.MobileNo =
                GetStringValue(
                    dataReader,
                    "MobileNo");

            // User Status
            row.UserStatus =
                GetInt32Value(
                    dataReader,
                    "UserStatus") ?? 0;

            row.UserStatusName =
                GetStringValue(
                    dataReader,
                    "UserStatusName");

            // Wallet Details
            row.UserDetailId =
                GetInt64Value(
                    dataReader,
                    "UserDetailId");

            row.AvailableLimit =
                dataReader["AvailableLimit"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["AvailableLimit"]);

            row.ThresoldLimit =
                dataReader["ThresoldLimit"] == DBNull.Value
                    ? 0
                    : Convert.ToDecimal(
                        dataReader["ThresoldLimit"]);

            // Threshold Details
            row.ThresoldOn =
                dataReader["ThresoldOn"] == DBNull.Value
                    ? (DateTime?)null
                    : Convert.ToDateTime(
                        dataReader["ThresoldOn"]);

            row.ThresoldBy =
                GetInt64Value(
                    dataReader,
                    "ThresoldBy");

            row.ThresoldReason =
                GetStringValue(
                    dataReader,
                    "ThresoldReason");

            // Wallet Status
            row.WalletStatus =
                GetInt32Value(
                    dataReader,
                    "WalletStatus");

            row.WalletStatusName =
                GetStringValue(
                    dataReader,
                    "WalletStatusName");

            // Threshold Changed By
            row.ThresoldByUserName =
                GetStringValue(
                    dataReader,
                    "ThresoldByUserName");

            row.UserTypeName =
               GetStringValue(
                   dataReader,
                   "UserTypeName");

            row.ThresoldByName =
                GetStringValue(
                    dataReader,
                    "ThresoldByName");

            return row;
        }
        // ============================================================
        // GET PARENT CODE LIST
        // ============================================================
        public async Task<List<GetParentCodeListResponse>> GetParentCodeList(
            GetParentCodeListRequest request)
        {
            List<GetParentCodeListResponse> response =
                new List<GetParentCodeListResponse>();

            // ========================================================
            // STORED PROCEDURE
            // ========================================================
            var dbCommand = _database.GetStoredProcCommand(
                "[USR].[usp_getParentCodelist]");

            // ========================================================
            // INPUT PARAMETERS
            // ========================================================
            _database.AddInParameter(
                dbCommand,
                "@UserMasterId",
                request.UserMasterId);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            // ========================================================
            // EXECUTE AND READ RESULT
            // ========================================================
            using (var dataReader =
                await _database.ExecuteReaderAsync(dbCommand))
            {
                while (await dataReader.ReadAsync())
                {
                    response.Add(new GetParentCodeListResponse
                    {
                        UserMasterID = GetInt64Value(dataReader, "UserMasterID").Value,

                        UserName = GetStringValue(
                            dataReader,
                            "UserName")
                    });
                }
            }

            return response;
        }
    }
}
