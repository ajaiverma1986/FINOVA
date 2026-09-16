using FINOVA.DataModel.Entities.Users;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;

namespace FINOVA.Provider
{
    public class UserDetailsProvider : BaseProvider
    {
        public readonly UsersRepository _repository = null;
        public UserDetailsProvider()
        {
            _repository = new UsersRepository();
        }

        public async Task<bool> CheckAvailableBalance(decimal Amount, decimal txnFee, IFINOVAServiceUser serviceUser)
        {
            UsersDetailsResponse response = new UsersDetailsResponse();
            bool avail = false;
            response = await _repository.CheckAvailbleLimit(serviceUser);
            if (response == null)
            {
                avail = true;
            }
            if (response.AvailableLimit <= 0)
            {
                avail = true;
            }
            else if (response.AvailableLimit < Amount)
            {
                avail = true;
            }
            else if (response.AvailableLimit <= response.ThresoldLimit)
            {
                avail = true;
            }
            else if (response.AvailableLimit < Amount + response.ThresoldLimit)
            {
                avail = true;
            }
            else
            {
                avail = false;
            }
            return avail;
        }
        public async Task<SimpleResponse> CheckBalalnce(IFINOVAServiceUser serviceUser)
        {
            UsersDetailsResponse response = new UsersDetailsResponse();
            SimpleResponse response1 = new SimpleResponse();

            response1.Result = await _repository.CheckPartnerAvailbleLimit(serviceUser);
            return response1;
        }
        public async Task<UserConfigResponse> GetUserConfig(IFINOVAServiceUser serviceUser)
        {
            UserConfigResponse response = new UserConfigResponse();

            response = await _repository.GetUserConfig(serviceUser);
            return response;
        }
       
       
        public async Task<List<ApplicationListResponse>> Getallapplication(IFINOVAServiceUser serviceUser)
        {
            return await _repository.Getallapplication(serviceUser);
        }
        public async Task<List<ApplicationListResponse>> GetallapplicationforAdmin(long UserId, IFINOVAServiceUser serviceUser)
        {
            return await _repository.GetallapplicationForAdmin(UserId, serviceUser);
        }
       
      
        public async Task<long> UpdateUserOrgLogo(UploadOrgLogo request, string Filename, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;
            UploadLogoRequest request1 = new UploadLogoRequest();
            request1.Logourl = Filename;
            request1.UserId = request.UserId;


            outputresponse = await _repository.UpdateUserLogo(request1, serviceUser);

            return outputresponse;
        }
        public async Task<long> AddOriginatorAccounts(CreateOriginatorAccountRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;

            outputresponse = await _repository.AddOriginatorAccounts(request, serviceUser);

            return outputresponse;
        }
        public async Task<long> ApproveRejectOriAccounts(ApproveRejectOriAccountRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;

            outputresponse = await _repository.ApproveRejectOriginatorAccounts(request, serviceUser);

            return outputresponse;
        }
        public async Task<SimpleResponse> GetallOriginatorsAccount(IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetallOriginatorsAccount(serviceUser);
            return response;
        }
        public async Task<List<OriginatorListAccountResponse>> GetallOriginatorsAccountByID(long AccountID, IFINOVAServiceUser serviceUser)
        {
            List<OriginatorListAccountResponse> response = new List<OriginatorListAccountResponse>();

            response = await _repository.GetallOriginatorsAccountByID(AccountID, serviceUser);
            return response;
        }
        public async Task<UserAccountsChecueFileResponse> DocumentViewOriginatorAcc_Search(long AccountID, IFINOVAServiceUser serviceUser)
        {
            List<OriginatorListAccountResponse> response = new List<OriginatorListAccountResponse>();
            response = await GetallOriginatorsAccountByID(AccountID, serviceUser);


            FileManager fileManager = new FileManager();
            UserAccountsChecueFileResponse resp = new UserAccountsChecueFileResponse();
            if (response[0].Filename != null && response[0].Filename != "")
            {
                resp.OriginatorAccountID = response[0].OriginatorAccountID;
                resp.FileUrl = response[0].Filename;
                resp.FileBytes = fileManager.ReadFileOther(response[0].Filename, "AccountCheque");
                resp.Base64String = Convert.ToBase64String(resp.FileBytes);
                resp.MediaExtension = System.IO.Path.GetExtension(response[0].Filename).ToLower();
            }

            return resp;

        }
        public async Task<SimpleResponse> ListAllOriginatorsAccounts(OriginatorListAccountRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.ListAllOriginatorsAccounts(request, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> ListAllOriginatorsAccountsforAdmin(OriginatorListAccountforadminRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.ListAllOriginatorsAccountsforAdmin(request, serviceUser);
            return response;
        }
        public async Task<long> AddUserAddress(CreateUserDetailAddressRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;

            outputresponse = await _repository.AddUserAddress(request, serviceUser);

            return outputresponse;
        }
        public async Task<long> CreateOrgAPIPartner(CreateNewPartnerRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;


            string pwd = BCrypt.Net.BCrypt.HashPassword(request.Password);

            //SyatemConfig obj = new SyatemConfig();
            //obj.SendEmail("Test", "Hello how are You", "ajaibit@gmail.com");

            outputresponse = await _repository.CreateOrgAPIPartner(request, pwd, serviceUser);
            //if (outputresponse>0)
            //{
            //    SyatemConfig obj =new SyatemConfig();
            //    obj.SendEmail("Test", "Hello how are You", "ajaibit@gmail.com");
            //}

            return outputresponse;
        }
        public async Task<long> CreateNewUser(CreateNewUserRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;


            string pwd = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // SyatemConfig obj = new SyatemConfig();
            // obj.SendEmail("Test", "Hello how are You", "ajaibit@gmail.com");
            // return 0;
            outputresponse = await _repository.CreateNewUser(request, pwd, serviceUser);
            //if (outputresponse>0)
            //{
            //    SyatemConfig obj =new SyatemConfig();
            //    obj.SendEmail("Test", "Hello how are You", "ajaibit@gmail.com");
            //}

            return outputresponse;
        }
        public async Task<SimpleResponse> GetAllUserAddress(IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserAddress(serviceUser);
            return response;
        }

        public async Task<long> AddUserDeatilKYC(CreateUserDetailKyc1 request, string Filename, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;
            CreateUserDetailKyc request1 = new CreateUserDetailKyc();
            request1.FileUrl = Filename.ToString();
            request1.DocumentNo = request.DocumentNo;
            request1.KycID = request.KycID;


            outputresponse = await _repository.AddUserDeatilKYC(request1, serviceUser);

            return outputresponse;
        }
        public async Task<SimpleResponse> GetAllUserKyc(IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserKyc(serviceUser);
            return response;
        }
        public async Task<SimpleResponse> GetAllUserKycByUserId(long UserId, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserKycByUserId(UserId, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> GetAllUserKycById(long KycId, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserKycById(KycId, serviceUser);
            return response;
        }
        public async Task<List<UserrListResponse>> GetallUserByOrg(IFINOVAServiceUser serviceUser)
        {
            return await _repository.GetallUserByOrg(serviceUser);
        }
        public async Task<long> UploadUserKYC(UploadUserKYCFileRequest request, string Filename, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;
            UploadUserKYCRequest request1 = new UploadUserKYCRequest();
            request1.fileurl = Filename;
            request1.KycID = request.KycID;
            request1.DocumentNo = request.DocumentNo;


            outputresponse = await _repository.UploadUserKYC(request1, serviceUser);

            return outputresponse;
        }
        public async Task<SimpleResponse> DocumentView_Search(long KYCID, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();
            List<UserKYYCResponse> list = new List<UserKYYCResponse>();
            list = await _repository.GetAllUserKycById(KYCID, serviceUser);

            FileManager fileManager = new FileManager();
            UserKycdownloadListResponse resp = new UserKycdownloadListResponse();


            foreach (UserKYYCResponse item in list)
            {
                if (item.FileUrl != null && item.FileUrl != "")
                {
                    resp.UserKYCID = item.UserKYCID;
                    resp.DocumentNo = item.DocumentNo;
                    resp.KycID = item.KycID;
                    resp.ContentType = "image";
                    resp.MediaContentType = "png";
                    resp.FileBytes = fileManager.ReadFile(item.FileUrl, "PartnerDocument", item.UserId.ToString());
                    if (resp.FileBytes == null)
                    {
                        resp.Base64String = "";
                    }
                    else
                    {
                        resp.Base64String = Convert.ToBase64String(resp.FileBytes);
                    }

                    resp.MediaExtension = System.IO.Path.GetExtension(item.FileUrl).ToLower();
                    resp.FileUrl = item.FileUrl;

                }
                else
                {
                    response.SetError("File not Exists");
                }


            }

            response.Result = resp;
            return response;
        }
        public async Task<SimpleResponse> GetUserLogo(long UsserID, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();
            PartnerDeatilsResponse list = new PartnerDeatilsResponse();
            list = await _repository.GetAllUserDeatilsForAdmin(UsserID, serviceUser);

            FileManager fileManager = new FileManager();
            GetUserLogoRequest resp = new GetUserLogoRequest();

            resp.UserId = list.UserId;
            resp.FileUrl = list.LogoUrl;
            resp.ContentType = "image";
            resp.MediaContentType = "png";
            resp.FileBytes = fileManager.ReadFile(list.LogoUrl, "PartnerDocument", list.UserId.ToString());
            if (resp.FileBytes == null)
            {
                resp.Base64String = "";
                resp.FileUrl = "";
                response.SetError(ErrorCodes.SP_153);
                return response;
            }
            else
            {
                resp.Base64String = Convert.ToBase64String(resp.FileBytes);
            }
            resp.MediaExtension = System.IO.Path.GetExtension(list.LogoUrl).ToLower();


            response.Result = resp;
            return response;
        }
        public async Task<SimpleResponse> UpdateOriginatorChequeFile(PayinAccountRegistrationChequeRequest request, IFINOVAServiceUser serviceUser)
        {

            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.UpdateOriginatorChequeFile(request, serviceUser);

            return response;
        }
        public async Task<List<ApplicationParentMenuResponse>> GetallMenu(IFINOVAServiceUser serviceUser)
        {
            List<ApplicationParentMenuResponse> response = new List<ApplicationParentMenuResponse>();

            response = await _repository.GetAllMenu(serviceUser);
            return response;
        }
        public async Task<List<ApplicationMenuResponse>> GetallSubMenu(int Menuid, IFINOVAServiceUser serviceUser)
        {
            List<ApplicationMenuResponse> response = new List<ApplicationMenuResponse>();

            response = await _repository.GetAllSubMenu(Menuid, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> GetAllUserDetails(IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserDeatils(serviceUser);
            return response;
        }
        public async Task<long> ApproveRejectUserDocument(ApproveRejectUserDocumentRequest request, IFINOVAServiceUser serviceUser)
        {
            long outputresponse = 0;


            outputresponse = await _repository.ApproveRejectUserDocument(request, serviceUser);

            return outputresponse;
        }
        public async Task<SimpleResponse> GetAllUserConfigration(long UserId, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.GetAllUserConfigration(UserId, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> UpDateUserConfigrationDetails(UserConfigrationRequest request, IFINOVAServiceUser serviceUser)
        {

            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.UpDateUserConfigrationDetails(request, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> ActivateDeactivateApiUser(ActivateAPIUserRequest request, IFINOVAServiceUser serviceUser)
        {

            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.ActivateDeactivateApiUser(request, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> ActivateDeactivateUserMaster(ActivateAPIUserMasterRequest request, IFINOVAServiceUser serviceUser)
        {

            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.ActivateDeactivateUserMaster(request, serviceUser);

            return response;
        }
        public async Task<ListResponse> GetAllUserMasterList(ListUserMasterRequest request, IFINOVAServiceUser serviceUser)
        {
            ListResponse response = new ListResponse();

            response = await _repository.GetAllUserMasterList(request, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> GetUserMasterDetailsforConfig(string UserName, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response = await _repository.GetUserMasterDetailsforConfig(UserName, serviceUser);
            return response;
        }
        public async Task<ListResponse> ListUserAddress(ListUserAddressRequest request, IFINOVAServiceUser serviceUser)
        {
            ListResponse response = new ListResponse();

            response = await _repository.ListUserAddress(request, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> ChangePassword(ChangePasswordRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            string pwd = BCrypt.Net.BCrypt.HashPassword(request.Password);

            response.Result = await _repository.ChangePassword(request, pwd, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> AddIPAddress(AddIPAddressRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.AddIPAddress(request, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> GetallIPAdress(long userid, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response = await _repository.GetallIPAddress(userid, serviceUser);
            return response;
        }
        public async Task<SimpleResponse> ApproveRejectIP(ApproveRejectIPAddressRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.ApproveRejectIP(request, serviceUser);

            return response;
        }
        public async Task<ListResponse> GetAllIPAddressforAdmin(IPAddressListDetail request, IFINOVAServiceUser serviceUser)
        {
            ListResponse response = new ListResponse();

            response = await _repository.GetAllIPAddressforAdmin(request, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> AddUserOtherDetails(AddUserOtherDetailRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result = await _repository.AddUserOtherDetail(request, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> GetUserOtherDetails(long UserId, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response = await _repository.GetUserOtherDetails(UserId, serviceUser);

            return response;
        }
        public async Task<SimpleResponse> AddNewOutLet(CreateNewOutLetRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            string pwd = BCrypt.Net.BCrypt.HashPassword(request.MobileNo);

            if (request.UserTypeId == 5)
            {
                request.ParentID = serviceUser.UserID;
            }


            response.Result = await _repository.AddNewOutLet(request, pwd, serviceUser);

            return response;
        }
        public async Task<ListResponse> GetAllOutLetList(ListRetailorRequest request, IFINOVAServiceUser serviceUser)
        {
            ListResponse response = new ListResponse();

            response = await _repository.GetAllOutLetList(request, serviceUser);
            return response;
        }
    }
}
