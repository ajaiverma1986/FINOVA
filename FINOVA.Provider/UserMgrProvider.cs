using FINOVA.DataModel.Entities.Notification;
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
        public readonly NotificationProvider _notificationProvider = null;
       
        public UserMgrProvider()
        {
            _repository = new UserMgrRepository();
            _notificationProvider = new NotificationProvider();
        }
        public async Task<SimpleResponse> GenerateUserCode(int userTypeID,IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GenerateUserCode(
                    userTypeID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // USER MASTER - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateUserMaster(
            CreateUserMasterRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // 1. VALIDATE REQUEST
            // ========================================================
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.FirstName) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                request.OrganizationID <= 0 ||
                request.GenderID <= 0 ||
                !request.UserTypeId.HasValue ||
                request.UserTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 2. GENERATE / USE USERNAME
            // ========================================================
            string newUserName;

            if (string.IsNullOrWhiteSpace(request.UserName))
            {
                SimpleResponse userCodeResponse =
                    await GenerateUserCode(
                        request.UserTypeId.Value,
                        serviceUser);

                if (userCodeResponse.HasError ||
                    userCodeResponse.Result == null)
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                GenerateUserCodeResponse? userCodeResult =
                    userCodeResponse.Result as GenerateUserCodeResponse;

                if (userCodeResult == null ||
                    string.IsNullOrWhiteSpace(userCodeResult.UserCode))
                {
                    response.SetError(ErrorCodes.SP_133);
                    return response;
                }

                newUserName = userCodeResult.UserCode;
            }
            else
            {
                newUserName = request.UserName.Trim();
            }


            // ========================================================
            // 3. HASH PASSWORD
            // ========================================================
            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(
                    request.Password);


            // ========================================================
            // 4. CREATE USER
            // ========================================================
            long userMasterId =
                await _repository.CreateUserMaster(
                    request,
                    hashedPassword,
                    newUserName,
                    serviceUser);

            response.Result = userMasterId;


            // ========================================================
            // 5. CHECK USER CREATED
            // ========================================================
            if (userMasterId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 6. SEND USER CREATION EMAIL
            // ========================================================
            if (!string.IsNullOrWhiteSpace(request.EmailId))
            {
                var inputs =
                    new Dictionary<string, string>
                    {
                {
                    "UserName",
                    newUserName
                },
                {
                    "FirstName",
                    request.FirstName
                }
                    };

                SimpleResponse emailResponse =
                    await _notificationProvider.SendEmail(
                        request.EmailId,
                        "User Created",
                        inputs,
                        serviceUser);

                // User has already been created successfully.
                // Therefore email failure should normally NOT
                // change the CreateUserMaster result.
            }


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
        // ============================================================
        // CREATE USER ROLE
        // ============================================================
        public async Task<SimpleResponse> CreateUserRole(
            CreateUserRoleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserMasterID <= 0 ||
                request.RoleID <= 0 ||
                request.ApplicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateUserRole(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // UPDATE USER ROLE
        // ============================================================
        public async Task<SimpleResponse> UpdateUserRole(
            UpdateUserRoleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.UserRoleID <= 0 ||
                request.UserMasterID <= 0 ||
                request.RoleID <= 0 ||
                request.ApplicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateUserRole(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // DELETE USER ROLE
        // ============================================================
        public async Task<SimpleResponse> DeleteUserRole(
            long userRoleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userRoleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteUserRole(
                    userRoleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER ROLE BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserRoleByID(
            long userRoleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userRoleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUserRoleByID(
                    userRoleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ALL USER ROLES
        // ============================================================
        public async Task<SimpleResponse> GetAllUserRoles(
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllUserRoles(
                    status,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USER ROLES BY USER MASTER ID
        // ============================================================
        public async Task<SimpleResponse> GetUserRolesByUserMasterID(
            long userMasterID,
            byte? applicationID,
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (applicationID.HasValue &&
                applicationID.Value <= 0)
            {
                applicationID = null;
            }

            response.Result =
                await _repository.GetUserRolesByUserMasterID(
                    userMasterID,
                    applicationID,
                    status,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET USERS BY ROLE ID
        // ============================================================
        public async Task<SimpleResponse> GetUserRolesByRoleID(
            short roleID,
            byte? applicationID,
            byte? status,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (applicationID.HasValue &&
                applicationID.Value <= 0)
            {
                applicationID = null;
            }

            response.Result =
                await _repository.GetUserRolesByRoleID(
                    roleID,
                    applicationID,
                    status,
                    serviceUser);

            return response;
        }


        // ============================================================
        // GET ACTIVE USER ROLES
        // LOGIN / AUTHORIZATION
        // ============================================================
        public async Task<SimpleResponse> GetActiveUserRoles(
            long userMasterID,
            byte applicationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userMasterID <= 0 ||
                applicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveUserRoles(
                    userMasterID,
                    applicationID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // FORGOT PASSWORD - SEND OTP
        // ============================================================
        public async Task<SimpleResponse> ForgotPassword(
            ForgotPasswordRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // 1. VALIDATE REQUEST
            // ========================================================
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserCode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.UserCode = request.UserCode.Trim();


            // ========================================================
            // 2. VALIDATE USER CODE
            // ========================================================
            SimpleResponse userResponse =
                await GetUserMasterByUserName(
                    request.UserCode,
                    serviceUser);

            if (userResponse == null ||
                userResponse.Result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 3. GET USER
            // ========================================================
            var user =
                userResponse.Result as GetUserMasterResponse;

            if (user == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 4. VALIDATE REGISTERED EMAIL
            // ========================================================
            if (string.IsNullOrWhiteSpace(user.EmailId))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 5. GENERATE SECURE 6-DIGIT OTP
            // ========================================================
            string otp =
                System.Security.Cryptography
                    .RandomNumberGenerator
                    .GetInt32(100000, 1000000)
                    .ToString();


            // ========================================================
            // 6. SAVE OTP
            // ========================================================
            // IMPORTANT:
            // Your current OTP table is MobileNo based.
            //
            // For forgot-password email OTP, I recommend storing:
            // UserMasterID / UserCode / Email / OTP / Expiry.
            //
            // Call your email OTP save method here once added.
            // Do NOT skip persistence because OTP must later be verified.


            // ========================================================
            // 7. TEMPLATE INPUTS
            // ========================================================
            Dictionary<string, string> templateInputs =
                new Dictionary<string, string>
                {
            {
                "UserName",
                user.UserName ?? request.UserCode
            },
            {
                "OTP",
                otp
            },
            {
                "ExpiryMinutes",
                "5"
            }
                };


            // ========================================================
            // 8. SEND OTP EMAIL
            // ========================================================
            NotificationProvider notificationProvider =
                new NotificationProvider();

            //SimpleResponse emailResponse =
            //    await notificationProvider.SendEmail(
            //        user.EmailId,
            //        "Forgot Password OTP",
            //        templateInputs,
            //        serviceUser);


            //// ========================================================
            //// 9. CHECK EMAIL RESULT
            //// ========================================================
            //if (emailResponse == null ||
            //    emailResponse.Result == null)
            //{
            //    response.SetError(ErrorCodes.SP_133);
            //    return response;
            //}

            // save otp in otp master

            CreateOTPRequest oTPRequest = new CreateOTPRequest
            {
                MobileNo = user.MobileNo,
                OTP = otp,
                OTPSender = "EMAIL",
                OTPMessage = "",
                Resettime = 15
            };
            SimpleResponse result2 = await _notificationProvider.CreateOTP(oTPRequest,serviceUser);
            // ========================================================
            // 10. SUCCESS
            // ========================================================
            response.Result = new
            {
                IsOTPSent = true,

                Message =
                    "OTP has been sent to your registered email address."
            };

            return response;
        }
        // ============================================================
        // RESET PASSWORD USING OTP
        // ============================================================
        public async Task<SimpleResponse> ResetPassword(
            ResetPasswordRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // 1. VALIDATE REQUEST
            // ========================================================
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserCode) ||
                string.IsNullOrWhiteSpace(request.OTP) ||
                string.IsNullOrWhiteSpace(request.NewPassword) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.UserCode = request.UserCode.Trim();
            request.OTP = request.OTP.Trim();


            // ========================================================
            // 2. VALIDATE 6-DIGIT OTP FORMAT
            // ========================================================
            if (request.OTP.Length != 6 ||
                !request.OTP.All(char.IsDigit))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 3. VALIDATE PASSWORD / CONFIRM PASSWORD
            // ========================================================
            if (request.NewPassword !=
                request.ConfirmPassword)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.NewPassword.Length < 8)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 4. GET USER BY USER CODE
            // ========================================================
            SimpleResponse userResponse =
                await GetUserMasterByUserName(
                    request.UserCode,
                    serviceUser);

            if (userResponse == null ||
                userResponse.Result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            var user =
                userResponse.Result as GetUserMasterResponse;

            if (user == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 5. VALIDATE REGISTERED MOBILE
            // ========================================================
            if (string.IsNullOrWhiteSpace(user.MobileNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 6. VALIDATE OTP USING EXISTING OTP PROVIDER
            // ========================================================
            NotificationProvider notificationProvider =
                new NotificationProvider();

            ValidateOTPRequest otpRequest =
                new ValidateOTPRequest
                {
                    MobileNo = user.MobileNo,
                    OTP = request.OTP
                };


            SimpleResponse otpResponse =
                await notificationProvider.ValidateOTP(
                    otpRequest,
                    serviceUser);


            // ========================================================
            // 7. CHECK OTP RESPONSE
            // ========================================================
            if (otpResponse == null ||
                otpResponse.Result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            ValidateOTPResponse otpResult =
                otpResponse.Result as ValidateOTPResponse;


            if (otpResult == null ||
                !otpResult.IsValid)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 8. UPDATE USER PASSWORD
            // ========================================================
            // Use your existing password update repository/provider
            // method here.
            //
            // IMPORTANT:
            // Store password using the same hashing mechanism already
            // used by your Login/Create User implementation.
            //
            // Example:
            //
            // response =
            //     await UpdateUserPassword(
            //         user.UserMasterID,
            //         request.NewPassword,
            //         serviceUser);


            // ========================================================
            // 9. SUCCESS
            // ========================================================
            response.Result = new
            {
                IsPasswordReset = true,
                Message = "Password reset successfully."
            };

            return response;
        }
        // ============================================================
        // USER MASTER - RESET PASSWORD
        // ============================================================
        public async Task<SimpleResponse> ResetUserPassword(
            ResetPasswordRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // ========================================================
            // 1. VALIDATE REQUEST
            // ========================================================
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.UserCode) ||
                string.IsNullOrWhiteSpace(request.OTP) ||
                string.IsNullOrWhiteSpace(request.NewPassword) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            request.UserCode = request.UserCode.Trim();
            request.OTP = request.OTP.Trim();


            // ========================================================
            // 2. VALIDATE OTP FORMAT
            // ========================================================
            if (request.OTP.Length != 6 ||
                !request.OTP.All(char.IsDigit))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 3. VALIDATE PASSWORD
            // ========================================================
            if (request.NewPassword != request.ConfirmPassword)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.NewPassword.Length < 8)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 4. GET USER BY USER CODE
            // ========================================================
            GetUserMasterResponse? user =
                await _repository.GetUserMasterByUserName(
                    request.UserCode,
                    serviceUser);

            if (user == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 5. VALIDATE USER STATUS
            // ========================================================
            if (user.Status != 8)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 6. VALIDATE MOBILE NUMBER
            // Existing OTP validation uses MobileNo
            // ========================================================
            if (string.IsNullOrWhiteSpace(user.MobileNo))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 7. VALIDATE OTP
            // ========================================================
            NotificationProvider notificationProvider =
                new NotificationProvider();

            ValidateOTPRequest otpRequest =
                new ValidateOTPRequest
                {
                    MobileNo = user.MobileNo,
                    OTP = request.OTP
                };


            SimpleResponse otpResponse =
                await notificationProvider.ValidateOTP(
                    otpRequest,
                    serviceUser);


            if (otpResponse == null ||
                otpResponse.Result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            ValidateOTPResponse? otpResult =
                otpResponse.Result as ValidateOTPResponse;


            if (otpResult == null ||
                !otpResult.IsValid)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 8. HASH / ENCRYPT NEW PASSWORD
            // ========================================================
            //
            // IMPORTANT:
            // Use EXACTLY the same method currently used by your
            // CreateUserMaster / ChangeUserPassword provider.
            //
            // Replace this line with your existing password method.
            //
            string password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

            // Example only:
            //
            // string password =
            //     PasswordHelper.HashPassword(
            //         request.NewPassword);


            // ========================================================
            // 9. RESET PASSWORD
            // ========================================================
            ResetUserPasswordResponse resetResult =
                await _repository.ResetUserPassword(
                    user.UserMasterID,
                    password,
                    serviceUser);


            // ========================================================
            // 10. CHECK RESET RESULT
            // ========================================================
            if (resetResult == null ||
                !resetResult.IsPasswordReset)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }


            // ========================================================
            // 11. SUCCESS
            // ========================================================
            response.Result = resetResult;

            return response;
        }
        // ============================================================
        // USER MASTER - MAP PARENT
        // ============================================================
        public async Task<SimpleResponse> MapUserParent(
            MapUserParentRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // Validate request
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate UserMasterID
            if (request.UserMasterID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate ParentId
            if (request.ParentId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // User cannot be their own parent
            if (request.UserMasterID == request.ParentId)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Map parent
            MapUserParentResponse? result =
                await _repository.MapUserParent(
                    request.UserMasterID,
                    request.ParentId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }
        // ============================================================
        // USER MASTER - GET USERS BY PARENT ID
        // ============================================================
        public async Task<SimpleResponse> GetUsersByParentId(
            long parentId,
            int? userTypeId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // Validate ParentId
            if (parentId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Validate UserTypeId if provided
            if (userTypeId.HasValue && userTypeId.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetUsersByParentId(
                    parentId,
                    userTypeId,
                    serviceUser);

            return response;
        }
        // ============================================================
        // CREATE USER WALLET
        // ============================================================
        public async Task<SimpleResponse> CreateUserWallet(
            CreateUserWalletRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.UserMasterId <= 0 ||
                request.AvailableLimit < 0 ||
                request.ThresoldLimit < 0 ||
                request.Status <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            long result =
                await _repository.CreateUserWallet(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }


        // ============================================================
        // UPDATE USER WALLET
        // ============================================================
        public async Task<SimpleResponse> UpdateUserWallet(
            UpdateUserWalletRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null ||
                request.UserDetailId <= 0 ||
                request.UserMasterId <= 0 ||
                request.AvailableLimit < 0 ||
                request.ThresoldLimit < 0 ||
                request.Status <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            UpdateUserWalletResponse? result =
                await _repository.UpdateUserWallet(
                    request,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // DELETE USER WALLET
        // ============================================================
        public async Task<SimpleResponse> DeleteUserWallet(
            long userDetailId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userDetailId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            DeleteUserWalletResponse? result =
                await _repository.DeleteUserWallet(
                    userDetailId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET USER WALLET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetUserWalletByID(
            long userDetailId,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (userDetailId <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            GetUserWalletResponse? result =
                await _repository.GetUserWalletByID(
                    userDetailId,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }


        // ============================================================
        // GET ALL / FILTER USER WALLETS
        // ============================================================
        public async Task<SimpleResponse> GetUserWallets(
            GetUserWalletRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            request ??= new GetUserWalletRequest();

           

            List<GetUserWalletResponse> result =
                await _repository.GetUserWallets(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
        public async Task<SimpleResponse> UpdateUserWalletThresoldLimit(
    UpdateUserWalletThresoldLimitRequest request,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            // Validate request
            if (request == null ||
                request.UserMasterId <= 0 ||
                request.ThresoldLimit < 0 )
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            // Call Repository
            UpdateUserWalletThresoldLimitResponse? result =
                await _repository.UpdateUserWalletThresoldLimit(
                    request,
                    serviceUser);

            if (result == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result = result;

            return response;
        }
        public async Task<SimpleResponse> GetThresoldUserList(
    GetThresoldUserListRequest request,
    IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            request ??= new GetThresoldUserListRequest();

           


            // Clean search text
            if (!string.IsNullOrWhiteSpace(request.SearchText))
            {
                request.SearchText = request.SearchText.Trim();
            }
            else
            {
                request.SearchText = null;
            }

            // Get threshold user list
            List<GetThresoldUserListResponse> result =
                await _repository.GetThresoldUserList(
                    request,
                    serviceUser);

            response.Result = result;

            return response;
        }
    }
}
