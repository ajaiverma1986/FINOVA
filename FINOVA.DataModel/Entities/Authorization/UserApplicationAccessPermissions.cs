using FINOVA.DataModel.Common;


namespace FINOVA.DataModel.Entities.Authorization
{
    public class UserApplicationAccessPermissions
    {
        public Int32 RoleID { get; set; }
        public Permissions PermissionID { get; set; }
        public Int32 ApplicationID { get; set; }
        public Int32 UserMasterID { get; set; }
    }
}
