using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.DataModel.Appmgr
{
    public class CreateApplicationRequest
    {
        public long OrganizationID { get; set; }

        public string ApplicationName { get; set; }

        public string? ApplicationDescription { get; set; }
    }
    public class CreateApplicationRequesttoken
    {
        public long OrganizationID { get; set; }

        public string ApplicationToken { get; set; }

        public string ApplicationName { get; set; }

        public string? ApplicationDescription { get; set; }
    }
    public class UpdateApplicationRequest
    {
        public int ApplicationID { get; set; }

        public long OrganizationID { get; set; }

        public int ApplicationTypeID { get; set; }

        public int PlatformID { get; set; }

        public long IconID { get; set; }

        public string ApplicationToken { get; set; }

        public string ApplicationName { get; set; }

        public string? ApplicationDescription { get; set; }

        public DateTimeOffset TokenCreatedDate { get; set; }

        public DateTimeOffset? TokenExpireDate { get; set; }

        public int UserTokenExpiresAfterMins { get; set; }

        public int Status { get; set; }
    }
    public class CreateModuleRequest
    {
        public int ModuleID { get; set; }

        public int ApplicationID { get; set; }

        public long? IconID { get; set; }

        public string ModuleName { get; set; }

        public string? ModuleDescription { get; set; }

        public string? DefaultMenuUrl { get; set; }

        public int Status { get; set; }
    }


    public class UpdateModuleRequest
    {
        public int ModuleID { get; set; }

        public int ApplicationID { get; set; }

        public long? IconID { get; set; }

        public string ModuleName { get; set; }

        public string? ModuleDescription { get; set; }

        public string? DefaultMenuUrl { get; set; }

        public int Status { get; set; }
    }
    public class CreateMenuRequest
    {
        public int ModuleID { get; set; }

        public int? ParentID { get; set; }

        public long? IconID { get; set; }

        public string Title { get; set; }

        public string Tooltip { get; set; }

        public string Description { get; set; }

        public string RoutePath { get; set; }

        public int DisplayOrder { get; set; }

        public string? Target { get; set; }

        public bool? IsExternal { get; set; }

        public int Status { get; set; }
    }
    public class UpdateMenuRequest
    {
        public int MenuID { get; set; }

        public int ModuleID { get; set; }

        public int? ParentID { get; set; }

        public long? IconID { get; set; }

        public string Title { get; set; }

        public string Tooltip { get; set; }

        public string Description { get; set; }

        public string RoutePath { get; set; }

        public int DisplayOrder { get; set; }

        public string? Target { get; set; }

        public bool? IsExternal { get; set; }

        public int Status { get; set; }
    }
    public class CreatePermissionRequest
    {
        public string PermissionName { get; set; }

        public string PermissionDescription { get; set; }

        public int Status { get; set; }
    }


    public class UpdatePermissionRequest
    {
        public int PermissionID { get; set; }

        public string PermissionName { get; set; }

        public string PermissionDescription { get; set; }

        public int Status { get; set; }
    }
    public class CreateMenuPermissionRequest
    {
        public int MenuID { get; set; }

        public int PermissionID { get; set; }

        public int Status { get; set; }
    }


    public class UpdateMenuPermissionRequest
    {
        public int MenuPermissionID { get; set; }

        public int MenuID { get; set; }

        public int PermissionID { get; set; }

        public int Status { get; set; }
    }
    public class CreateRoleRequestaac
    {
        public long? IconID { get; set; }

        public string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public int Status { get; set; }
    }


    public class UpdateRoleRequestaac
    {
        public int RoleID { get; set; }

        public long? IconID { get; set; }

        public string RoleName { get; set; }

        public string? RoleDescription { get; set; }

        public int Status { get; set; }
    }
    public class CreateTaskRequest
    {
        public string TaskName { get; set; }

        public string TaskTooltip { get; set; }

        public string? TaskDescription { get; set; }

        public int EntityTypeID { get; set; }

        public string? TaskURI { get; set; }

        public int Status { get; set; }
    }


    public class UpdateTaskRequest
    {
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public string TaskTooltip { get; set; }

        public string? TaskDescription { get; set; }

        public int EntityTypeID { get; set; }

        public string? TaskURI { get; set; }

        public int Status { get; set; }
    }
    public class CreateRoleTaskRequest
    {
        public int TaskID { get; set; }

        public int RoleID { get; set; }

        public TimeSpan? TAT { get; set; }

        public int Status { get; set; }
    }


    public class UpdateRoleTaskRequest
    {
        public int RoleTaskID { get; set; }

        public int TaskID { get; set; }

        public int RoleID { get; set; }

        public TimeSpan? TAT { get; set; }

        public int Status { get; set; }
    }
    public class CreateRolePermissionRequest
    {
        public int RoleID { get; set; }

        public int PermissionID { get; set; }

        public int Status { get; set; }
    }


    public class UpdateRolePermissionRequest
    {
        public int RolePermissionID { get; set; }

        public int RoleID { get; set; }

        public int PermissionID { get; set; }

        public int Status { get; set; }
    }

}
