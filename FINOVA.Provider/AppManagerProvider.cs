using FINOVA.DataModel.Appmgr;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider.Shared;
using FINOVA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Provider
{

    public class AppManagerProvider:BaseProvider
    {
        public readonly AppManagerRepository _repository = null;
        public AppManagerProvider()
        {
            _repository = new AppManagerRepository();
        }
        public async Task<SimpleResponse> CreateNewApplication(CreateapplicationRequest request, IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();
            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
            if (request.ApplicationName == "")
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            Guid specificGuid = Guid.NewGuid();
            string apiKey = specificGuid.ToString();

            response.Result = await _repository.CreateNewApplication(request, apiKey.ToUpper(), serviceUser);
            return response;
        }
        // ============================================================
        // APPLICATIONS - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateApplication(
            CreateApplicationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();
            CreateApplicationRequesttoken createApplication=new CreateApplicationRequesttoken ();
           

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
            
            if (request.OrganizationID <= 0 || string.IsNullOrWhiteSpace(request.ApplicationName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }
            Guid specificGuid = Guid.NewGuid();
            string apiKey = specificGuid.ToString();
            createApplication.ApplicationDescription = request.ApplicationDescription;
            createApplication.ApplicationName = request.ApplicationName;
            createApplication.ApplicationToken = apiKey;
            createApplication.OrganizationID = request.OrganizationID;
            response.Result =
                await _repository.CreateApplication(
                    createApplication,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateApplication(
            UpdateApplicationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ApplicationID <= 0 ||
                request.OrganizationID <= 0 ||
                string.IsNullOrWhiteSpace(request.ApplicationToken) ||
                string.IsNullOrWhiteSpace(request.ApplicationName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateApplication(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteApplication(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (applicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteApplication(
                    applicationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetApplicationByID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (applicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetApplicationByID(
                    applicationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllApplications(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllApplications(
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveApplications(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveApplications(
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET BY ORGANIZATION ID
        // ============================================================
        public async Task<SimpleResponse> GetApplicationsByOrganizationID(
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
                await _repository.GetApplicationsByOrganizationID(
                    organizationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE BY ORGANIZATION ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveApplicationsByOrganizationID(
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
                await _repository.GetActiveApplicationsByOrganizationID(
                    organizationID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // MODULES - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateModule(
            CreateModuleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ModuleID <= 0 ||
                request.ApplicationID <= 0 ||
                string.IsNullOrWhiteSpace(request.ModuleName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateModule(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateModule(
            UpdateModuleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ModuleID <= 0 ||
                request.ApplicationID <= 0 ||
                string.IsNullOrWhiteSpace(request.ModuleName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateModule(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteModule(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (moduleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteModule(
                    moduleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetModuleByID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (moduleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetModuleByID(
                    moduleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllModules(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllModules(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveModules(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveModules(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - GET BY APPLICATION ID
        // ============================================================
        public async Task<SimpleResponse> GetModulesByApplicationID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (applicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetModulesByApplicationID(
                    applicationID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MODULES - GET ACTIVE BY APPLICATION ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveModulesByApplicationID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (applicationID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveModulesByApplicationID(
                    applicationID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // MENUS - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateMenu(
            CreateMenuRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ModuleID <= 0 ||
                string.IsNullOrWhiteSpace(request.Title) ||
                string.IsNullOrWhiteSpace(request.Tooltip) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.RoutePath))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ParentID.HasValue &&
                request.ParentID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateMenu(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateMenu(
            UpdateMenuRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MenuID <= 0 ||
                request.ModuleID <= 0 ||
                string.IsNullOrWhiteSpace(request.Title) ||
                string.IsNullOrWhiteSpace(request.Tooltip) ||
                string.IsNullOrWhiteSpace(request.Description) ||
                string.IsNullOrWhiteSpace(request.RoutePath))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ParentID.HasValue &&
                request.ParentID.Value <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.ParentID.HasValue &&
                request.ParentID.Value == request.MenuID)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateMenu(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteMenu(
            int menuID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteMenu(
                    menuID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetMenuByID(
            int menuID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenuByID(
                    menuID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllMenus(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllMenus(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveMenus(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveMenus(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET BY MODULE ID
        // ============================================================
        public async Task<SimpleResponse> GetMenusByModuleID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (moduleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenusByModuleID(
                    moduleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET ACTIVE BY MODULE ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveMenusByModuleID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (moduleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveMenusByModuleID(
                    moduleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENUS - GET BY PARENT ID
        // ============================================================
        public async Task<SimpleResponse> GetMenusByParentID(
            int parentID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (parentID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenusByParentID(
                    parentID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // PERMISSION - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreatePermission(
            CreatePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.PermissionName) ||
                string.IsNullOrWhiteSpace(request.PermissionDescription))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreatePermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PERMISSION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePermission(
            UpdatePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.PermissionID <= 0 ||
                string.IsNullOrWhiteSpace(request.PermissionName) ||
                string.IsNullOrWhiteSpace(request.PermissionDescription))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdatePermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PERMISSION - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeletePermission(
            int permissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (permissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeletePermission(
                    permissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PERMISSION - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetPermissionByID(
            int permissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (permissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetPermissionByID(
                    permissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // PERMISSION - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllPermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllPermissions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // PERMISSION - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActivePermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActivePermissions(
                    serviceUser);

            return response;
        }
        // ============================================================
        // MENU PERMISSIONS - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateMenuPermission(
            CreateMenuPermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MenuID <= 0 ||
                request.PermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateMenuPermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateMenuPermission(
            UpdateMenuPermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.MenuPermissionID <= 0 ||
                request.MenuID <= 0 ||
                request.PermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateMenuPermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteMenuPermission(
            int menuPermissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuPermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteMenuPermission(
                    menuPermissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetMenuPermissionByID(
            int menuPermissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuPermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenuPermissionByID(
                    menuPermissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllMenuPermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllMenuPermissions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveMenuPermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveMenuPermissions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY MENU ID
        // ============================================================
        public async Task<SimpleResponse> GetMenuPermissionsByMenuID(
            int menuID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenuPermissionsByMenuID(
                    menuID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE BY MENU ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveMenuPermissionsByMenuID(
            int menuID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (menuID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveMenuPermissionsByMenuID(
                    menuID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY PERMISSION ID
        // ============================================================
        public async Task<SimpleResponse> GetMenuPermissionsByPermissionID(
            int permissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (permissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetMenuPermissionsByPermissionID(
                    permissionID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // ROLES - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateRole(
            CreateRoleRequestaac request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.RoleName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateRole(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLES - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRole(
            UpdateRoleRequestaac request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.RoleID <= 0 ||
                string.IsNullOrWhiteSpace(request.RoleName))
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateRole(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLES - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteRole(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteRole(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLES - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetRoleByID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRoleByID(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLES - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllRoles(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllRoles(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLES - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveRoles(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveRoles(
                    serviceUser);

            return response;
        }
        // ============================================================
        // TASKS - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateTask(
            CreateTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (string.IsNullOrWhiteSpace(request.TaskName) ||
                string.IsNullOrWhiteSpace(request.TaskTooltip) ||
                request.EntityTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateTask(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTask(
            UpdateTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TaskID <= 0 ||
                string.IsNullOrWhiteSpace(request.TaskName) ||
                string.IsNullOrWhiteSpace(request.TaskTooltip) ||
                request.EntityTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateTask(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTask(
            int taskID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (taskID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteTask(
                    taskID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetTaskByID(
            int taskID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (taskID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTaskByID(
                    taskID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET BY UID
        // ============================================================
        public async Task<SimpleResponse> GetTaskByUID(
            Guid taskUID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (taskUID == Guid.Empty)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTaskByUID(
                    taskUID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllTasks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllTasks(
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveTasks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveTasks(
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET BY ENTITY TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetTasksByEntityTypeID(
            int entityTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (entityTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetTasksByEntityTypeID(
                    entityTypeID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // TASKS - GET ACTIVE BY ENTITY TYPE ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveTasksByEntityTypeID(
            int entityTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (entityTypeID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveTasksByEntityTypeID(
                    entityTypeID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // ROLE TASK - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateRoleTask(
            CreateRoleTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.TaskID <= 0 ||
                request.RoleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateRoleTask(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRoleTask(
            UpdateRoleTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.RoleTaskID <= 0 ||
                request.TaskID <= 0 ||
                request.RoleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateRoleTask(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteRoleTask(
            int roleTaskID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleTaskID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteRoleTask(
                    roleTaskID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetRoleTaskByID(
            int roleTaskID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleTaskID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRoleTaskByID(
                    roleTaskID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY UID
        // ============================================================
        public async Task<SimpleResponse> GetRoleTaskByUID(
            Guid roleTaskUID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleTaskUID == Guid.Empty)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRoleTaskByUID(
                    roleTaskUID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllRoleTasks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllRoleTasks(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveRoleTasks(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveRoleTasks(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY ROLE ID
        // ============================================================
        public async Task<SimpleResponse> GetRoleTasksByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRoleTasksByRoleID(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE BY ROLE ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveRoleTasksByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveRoleTasksByRoleID(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY TASK ID
        // ============================================================
        public async Task<SimpleResponse> GetRoleTasksByTaskID(
            int taskID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (taskID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRoleTasksByTaskID(
                    taskID,
                    serviceUser);

            return response;
        }
        // ============================================================
        // ROLE PERMISSION - CREATE
        // ============================================================
        public async Task<SimpleResponse> CreateRolePermission(
            CreateRolePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.RoleID <= 0 ||
                request.PermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.CreateRolePermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRolePermission(
            UpdateRolePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (request == null)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            if (request.RolePermissionID <= 0 ||
                request.RoleID <= 0 ||
                request.PermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.UpdateRolePermission(
                    request,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteRolePermission(
            int rolePermissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (rolePermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response =
                await _repository.DeleteRolePermission(
                    rolePermissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET BY ID
        // ============================================================
        public async Task<SimpleResponse> GetRolePermissionByID(
            int rolePermissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (rolePermissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRolePermissionByID(
                    rolePermissionID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET ALL
        // ============================================================
        public async Task<SimpleResponse> GetAllRolePermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetAllRolePermissions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET ACTIVE
        // ============================================================
        public async Task<SimpleResponse> GetActiveRolePermissions(
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            response.Result =
                await _repository.GetActiveRolePermissions(
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET BY ROLE ID
        // ============================================================
        public async Task<SimpleResponse> GetRolePermissionsByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRolePermissionsByRoleID(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET ACTIVE BY ROLE ID
        // ============================================================
        public async Task<SimpleResponse> GetActiveRolePermissionsByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (roleID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetActiveRolePermissionsByRoleID(
                    roleID,
                    serviceUser);

            return response;
        }


        // ============================================================
        // ROLE PERMISSION - GET BY PERMISSION ID
        // ============================================================
        public async Task<SimpleResponse> GetRolePermissionsByPermissionID(
            int permissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            if (permissionID <= 0)
            {
                response.SetError(ErrorCodes.SP_133);
                return response;
            }

            response.Result =
                await _repository.GetRolePermissionsByPermissionID(
                    permissionID,
                    serviceUser);

            return response;
        }
    }
}
