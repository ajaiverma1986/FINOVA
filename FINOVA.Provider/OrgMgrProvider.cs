using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.OrgMgr;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;


namespace FINOVA.Provider
{
   public class OrgMgrProvider: BaseProvider
    {
        public readonly OrgMgrRepository _repository = null;
        public OrgMgrProvider() 
        {
            _repository = new OrgMgrRepository();
        }
        // ============================================================
        // ORGANIZATION - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateOrganization(
            CreateOrganizationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.OrganizationCode) ||
                string.IsNullOrWhiteSpace(request.OrganizationName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateOrganization(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateOrganization(
            UpdateOrganizationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.OrganizationID <= 0 ||
                string.IsNullOrWhiteSpace(request.OrganizationCode) ||
                string.IsNullOrWhiteSpace(request.OrganizationName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateOrganization(
                    request,
                    serviceUser);

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

            if (organizationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteOrganization(
                    organizationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetOrganizationByID(
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
                await _repository.GetOrganizationByID(
                    organizationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY UID
        // ============================================================
        public async Task<SimpleResponse> GetOrganizationByUID(
            Guid organizationUID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (organizationUID == Guid.Empty)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetOrganizationByUID(
                    organizationUID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY CODE
        // ============================================================
        public async Task<SimpleResponse> GetOrganizationByCode(
            string organizationCode,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (string.IsNullOrWhiteSpace(organizationCode))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetOrganizationByCode(
                    organizationCode,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllOrganizations(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllOrganizations(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveOrganizations(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveOrganizations(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ORGANIZATION - GET BY ORGANIZATION TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetOrganizationsByOrganizationTypeID(
            int organizationTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (organizationTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetOrganizationsByOrganizationTypeID(
                    organizationTypeID,
                    serviceUser);

            return response;
        }
    }
}
