using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.DataModel.UserMgr;
using FINOVA.Provider.Shared;
using FINOVA.Repository;


namespace FINOVA.Provider
{
   public class UserMgrProvider: BaseProvider
    {
        public readonly UserMgrRepository _repository = null;
        public UserMgrProvider()
        {
            _repository = new UserMgrRepository();
        }
        // ============================================================
        // USER MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateUserMaster(
            CreateUserMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.FirstName) ||
                request.OrganizationID <= 0 ||
                request.GenderID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserTypeId.HasValue &&
                request.UserTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
            string pwd = BCrypt.Net.BCrypt.HashPassword(request.Password);
            response.Result =
                await _repository.CreateUserMaster(
                    request, pwd,
                    serviceUser);

            return response;
        }
        // ============================================================
        // USER MASTER - CHANGE PASSWORD
        // ============================================================
        public async Task<SimpleResponse> ChangeUserPassword(
            ChangeUserPasswordRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterID <= 0 ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
            string pwd = BCrypt.Net.BCrypt.HashPassword(request.Password);
            response = await _repository.ChangeUserPassword(
                request,pwd,
                serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - UNLOCK USER
        // ============================================================
        public async Task<SimpleResponse> UnlockUserMaster(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response = await _repository.UnlockUserMaster(
                userMasterID,
                serviceUser);

            return response;
        }
        public async Task<SimpleResponse> LockUserMaster(
    LockUserMasterRequest request,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response = await _repository.LockUserMaster(
                request,
                serviceUser);

            return response;
        }

        // ============================================================
        // USER MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserMaster(
            UpdateUserMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterID <= 0 ||
                string.IsNullOrWhiteSpace(request.FirstName) ||
                request.OrganizationID <= 0 ||
                request.GenderID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserTypeId.HasValue &&
                request.UserTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserMaster(
                    request,
                    serviceUser);

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

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserMaster(
                    userMasterID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserMasterByID(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserMasterByID(
                    userMasterID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllUserMasters(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserMasters(
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserMasters(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveUserMasters(
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY ORGANIZATION ID
        // ============================================================
        public async Task<SimpleResponse> GetUserMastersByOrganizationID(
            long organizationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (organizationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserMastersByOrganizationID(
                    organizationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY USER TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetUserMastersByUserTypeID(
            int userTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserMastersByUserTypeID(
                    userTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // USER MASTER - GET BY USER NAME
        // ============================================================
        public async Task<SimpleResponse> GetUserMasterByUserName(
            string userName,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (string.IsNullOrWhiteSpace(userName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserMasterByUserName(
                    userName,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE USER ADDRESS
        // ============================================================
        public async Task<SimpleResponse> CreateUserAddress(
            CreateUserAddressRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId <= 0 ||
                request.AddressTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.Pincode) ||
                request.Pincode.Length != 6 ||
                request.PincodeDataId <= 0 ||
                string.IsNullOrWhiteSpace(request.Address1))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserAddress(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE USER ADDRESS
        // ============================================================
        public async Task<SimpleResponse> UpdateUserAddress(
            UpdateUserAddressRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserAddressID <= 0 ||
                request.UserMasterId <= 0 ||
                request.AddressTypeId <= 0 ||
                string.IsNullOrWhiteSpace(request.Pincode) ||
                request.Pincode.Length != 6 ||
                request.PincodeDataId <= 0 ||
                string.IsNullOrWhiteSpace(request.Address1))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserAddress(
                    request,
                    serviceUser);

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

            if (userAddressID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserAddress(
                    userAddressID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER ADDRESS BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserAddressByID(
            long userAddressID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userAddressID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserAddressByID(
                    userAddressID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL USER ADDRESSES
        // ============================================================
        public async Task<SimpleResponse> GetAllUserAddresses(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserAddresses(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER ADDRESSES
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserAddresses(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveUserAddresses(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER ADDRESSES BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetUserAddressesByUserMasterID(
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
                await _repository.GetUserAddressesByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER ADDRESSES BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserAddressesByUserMasterID(
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
                await _repository.GetActiveUserAddressesByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE USER KYC
        // ============================================================
        public async Task<SimpleResponse> CreateUserKyc(
            CreateUserKycRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId <= 0 ||
                request.KycID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserKyc(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE USER KYC
        // ============================================================
        public async Task<SimpleResponse> UpdateUserKyc(
            UpdateUserKycRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserKYCID <= 0 ||
                request.UserMasterId <= 0 ||
                request.KycID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserKyc(
                    request,
                    serviceUser);

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

            if (userKYCID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserKyc(
                    userKYCID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER KYC BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserKycByID(
            long userKYCID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userKYCID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserKycByID(
                    userKYCID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL USER KYC
        // ============================================================
        public async Task<SimpleResponse> GetAllUserKyc(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserKyc(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER KYC
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserKyc(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveUserKyc(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER KYC BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetUserKycByUserMasterID(
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
                await _repository.GetUserKycByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER KYC BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserKycByUserMasterID(
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
                await _repository.GetActiveUserKycByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE USER BANK ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> CreateUserBankAccount(
            CreateUserBankAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterID <= 0 ||
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo) ||
                string.IsNullOrWhiteSpace(request.Ifsccode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserBankAccount(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE USER BANK ACCOUNT
        // ============================================================
        public async Task<SimpleResponse> UpdateUserBankAccount(
            UpdateUserBankAccountRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.OriginatorAccountID <= 0 ||
                request.UserMasterID <= 0 ||
                request.BankId <= 0 ||
                string.IsNullOrWhiteSpace(request.AccountName) ||
                string.IsNullOrWhiteSpace(request.AccountNo) ||
                string.IsNullOrWhiteSpace(request.Ifsccode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserBankAccount(
                    request,
                    serviceUser);

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

            if (originatorAccountID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserBankAccount(
                    originatorAccountID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER BANK ACCOUNT BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserBankAccountByID(
            long originatorAccountID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (originatorAccountID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserBankAccountByID(
                    originatorAccountID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL USER BANK ACCOUNTS
        // ============================================================
        public async Task<SimpleResponse> GetAllUserBankAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserBankAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER BANK ACCOUNTS
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserBankAccounts(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveUserBankAccounts(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetUserBankAccountsByUserMasterID(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserBankAccountsByUserMasterID(
                    userMasterID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE BANK ACCOUNTS BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserBankAccountsByUserMasterID(
            long userMasterID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveUserBankAccountsByUserMasterID(
                    userMasterID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE USER CONFIGURATION
        // ============================================================
        public async Task<SimpleResponse> CreateUserConfiguration(
            CreateUserConfigurationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId <= 0 ||
                request.MinTxn < 0 ||
                request.MaxTxn < 0 ||
                request.ChargeTypeOn <= 0 ||
                request.PlanId <= 0 ||
                request.MaxPayinamount < 0 ||
                request.MaxNoofcountPayin < 0 ||
                request.SameAmountPayinAllowed < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MaxTxn > 0 &&
                request.MaxTxn < request.MinTxn)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserConfiguration(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE USER CONFIGURATION
        // ============================================================
        public async Task<SimpleResponse> UpdateUserConfiguration(
            UpdateUserConfigurationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ConfigurationId <= 0 ||
                request.UserMasterId <= 0 ||
                request.MinTxn < 0 ||
                request.MaxTxn < 0 ||
                request.ChargeTypeOn <= 0 ||
                request.PlanId <= 0 ||
                request.MaxPayinamount < 0 ||
                request.MaxNoofcountPayin < 0 ||
                request.SameAmountPayinAllowed < 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MaxTxn > 0 &&
                request.MaxTxn < request.MinTxn)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserConfiguration(
                    request,
                    serviceUser);

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

            if (configurationId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserConfiguration(
                    configurationId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER CONFIGURATION BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserConfigurationByID(
            long configurationId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (configurationId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserConfigurationByID(
                    configurationId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL USER CONFIGURATIONS
        // ============================================================
        public async Task<SimpleResponse> GetAllUserConfigurations(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserConfigurations(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER CONFIGURATION BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetUserConfigurationByUserMasterID(
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
                await _repository.GetUserConfigurationByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> CreateOtherDetails(
            CreateOtherDetailsRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId.HasValue &&
                request.UserMasterId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (!string.IsNullOrWhiteSpace(request.Pancard) &&
                request.Pancard.Trim().Length != 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (!string.IsNullOrWhiteSpace(request.AadharCard) &&
                request.AadharCard.Trim().Length != 12)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateOtherDetails(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> UpdateOtherDetails(
            UpdateOtherDetailsRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.OtherDetailId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterId.HasValue &&
                request.UserMasterId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (!string.IsNullOrWhiteSpace(request.Pancard) &&
                request.Pancard.Trim().Length != 10)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (!string.IsNullOrWhiteSpace(request.AadharCard) &&
                request.AadharCard.Trim().Length != 12)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateOtherDetails(
                    request,
                    serviceUser);

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

            if (otherDetailId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteOtherDetails(
                    otherDetailId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET OTHER DETAILS BY ID
        // ============================================================
        public async Task<SimpleResponse> GetOtherDetailsByID(
            long otherDetailId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (otherDetailId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetOtherDetailsByID(
                    otherDetailId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> GetAllOtherDetails(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllOtherDetails(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS
        // ============================================================
        public async Task<SimpleResponse> GetActiveOtherDetails(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveOtherDetails(
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET OTHER DETAILS BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetOtherDetailsByUserMasterID(
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
                await _repository.GetOtherDetailsByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE OTHER DETAILS BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveOtherDetailsByUserMasterID(
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
                await _repository.GetActiveOtherDetailsByUserMasterID(
                    userMasterId,
                    serviceUser);

            return response;
        }
    }
}
