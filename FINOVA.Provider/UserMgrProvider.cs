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
    }
}
