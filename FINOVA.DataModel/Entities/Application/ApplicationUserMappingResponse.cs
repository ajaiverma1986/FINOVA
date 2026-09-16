using FINOVA.DataModel.Common;


namespace FINOVA.DataModel.Entities.Application
{
    public class ApplicationUserMappingResponse
    {
        public string? ApplicationName { get; set; }
        public int ApplicationId { get; set; }
        public Int32? UserMasterID { get; set; }

        public Int32? OrganizationID { get; set; }
        public Int32? UserID { get; set; }
        public Int32? UserTypeID { get; set; }

        public ApplicationTypes AppType { get; set; }
    }
}
