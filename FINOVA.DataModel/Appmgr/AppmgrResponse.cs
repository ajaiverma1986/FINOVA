using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Appmgr
{
    public class GetApplicationResponse
    {
        public int ApplicationID { get; set; }

        public long OrganizationID { get; set; }

        public int ApplicationTypeID { get; set; }

        public int PlatformID { get; set; }

        public long IconID { get; set; }

        public string ApplicationToken { get; set; }

        public string ApplicationName { get; set; }

        public string? ApplicationDescription { get; set; }

        public DateTimeOffset? TokenCreatedDate { get; set; }

        public DateTimeOffset? TokenExpireDate { get; set; }

        public int UserTokenExpiresAfterMins { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }
        public string? OrganizationName { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long Createdby { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long? Updatedby { get; set; }
    }
    public class GetModuleResponse
    {
        public int ModuleID { get; set; }

        public int ApplicationID { get; set; }

        public string? ApplicationName { get; set; }

        public long? IconID { get; set; }

        public string ModuleName { get; set; }

        public string? ModuleDescription { get; set; }

        public string? DefaultMenuUrl { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long Createdby { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? Updatedby { get; set; }
    }
    public class GetMenuResponse
    {
        public int MenuID { get; set; }

        public int ModuleID { get; set; }

        public string? ModuleName { get; set; }

        public int? ParentID { get; set; }

        public string? ParentMenuTitle { get; set; }

        public long? IconID { get; set; }

        public string Title { get; set; }

        public string Tooltip { get; set; }

        public string Description { get; set; }

        public string RoutePath { get; set; }

        public int DisplayOrder { get; set; }

        public string? Target { get; set; }

        public bool? IsExternal { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetPermissionResponse
    {
        public int PermissionID { get; set; }

        public string PermissionName { get; set; }

        public string PermissionDescription { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetMenuPermissionResponse
    {
        public int MenuPermissionID { get; set; }

        public int MenuID { get; set; }

        public string? MenuTitle { get; set; }

        public int PermissionID { get; set; }

        public string? PermissionName { get; set; }

        public string? PermissionDescription { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetRoleResponseaac
    {
        public int RoleID { get; set; }

        public long? IconID { get; set; }

        public string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetTaskResponse
    {
        public int TaskID { get; set; }

        public Guid TaskUID { get; set; }

        public string TaskName { get; set; }

        public string TaskTooltip { get; set; }

        public string? TaskDescription { get; set; }

        public int EntityTypeID { get; set; }

        public string? TaskURI { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetRoleTaskResponse
    {
        public int RoleTaskID { get; set; }

        public Guid RoleTaskUID { get; set; }

        public int RoleID { get; set; }

        public string? RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public int TaskID { get; set; }

        public Guid TaskUID { get; set; }

        public string? TaskName { get; set; }

        public string? TaskTooltip { get; set; }

        public string? TaskDescription { get; set; }

        public int EntityTypeID { get; set; }

        public string? TaskURI { get; set; }

        public TimeSpan? TAT { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
    public class GetRolePermissionResponse
    {
        public int RolePermissionID { get; set; }

        public int RoleID { get; set; }

        public string? RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public int PermissionID { get; set; }

        public string? PermissionName { get; set; }

        public string? PermissionDescription { get; set; }

        public int Status { get; set; }

        public string? StatusName { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public long? UpdatedBy { get; set; }
    }
}
