using FINOVA.API.Common;
using FINOVA.API.Security;
using FINOVA.DataModel.Appmgr;
using FINOVA.DataModel.Entities.SysModel;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Provider;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FINOVA.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowAll")]
    [ResponseCache(
       Duration = -1,
       Location = ResponseCacheLocation.None,
       NoStore = true)]
    [ServiceFilter(typeof(FINOVExceptionFilterService))]
    public class AppManagerController: BaseApiController
    {
        public readonly AppManagerProvider _Provider;

        private AuthenticationHelper _callValidator = null;
        private readonly AuthenticationProvider _authenticationProvider;

        public AppManagerController()
        {
            _authenticationProvider = new AuthenticationProvider();
            _Provider = new AppManagerProvider();
            _callValidator = new AuthenticationHelper();
        }
        //[HttpPost("CreateNewApplication")]
        //public async Task<IActionResult> CreateNewApplication(
        //   [FromBody] CreateapplicationRequest request)
        //{
        //    SimpleResponse response = new SimpleResponse();

        //    ErrorResponse error =
        //        await _callValidator.AuthenticateAndAuthorize(CallerUser, true);

        //    if (error.HasError)
        //    {
        //        response.SetError(error);
        //        return Json(response);
        //    }

        //    response = await _Provider.CreateNewApplication(request, CallerUser);

        //    return Json(response);
        //}
        // ============================================================
        // APPLICATIONS - CREATE
        // ============================================================
        [HttpPost("CreateApplication")]
        public async Task<IActionResult> CreateApplication(
            [FromBody] CreateApplicationRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateApplication(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - UPDATE
        // ============================================================
        [HttpPost("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication(
            [FromBody] UpdateApplicationRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateApplication(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - DELETE
        // ============================================================
        [HttpDelete("DeleteApplication/{applicationID}")]
        public async Task<IActionResult> DeleteApplication(
            int applicationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteApplication(
                applicationID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - GET BY ID
        // ============================================================
        [HttpGet("GetApplicationByID")]
        public async Task<IActionResult> GetApplicationByID(
            int applicationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetApplicationByID(
                applicationID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - GET ALL
        // ============================================================
        [HttpGet("GetAllApplications")]
        public async Task<IActionResult> GetAllApplications()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllApplications(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveApplications")]
        public async Task<IActionResult> GetActiveApplications()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveApplications(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - GET BY ORGANIZATION ID
        // ============================================================
        [HttpGet("GetApplicationsByOrganizationID")]
        public async Task<IActionResult> GetApplicationsByOrganizationID(
            long organizationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetApplicationsByOrganizationID(
                    organizationID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE BY ORGANIZATION ID
        // ============================================================
        [HttpGet("GetActiveApplicationsByOrganizationID")]
        public async Task<IActionResult> GetActiveApplicationsByOrganizationID(
            long organizationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveApplicationsByOrganizationID(
                    organizationID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // MODULES - CREATE
        // ============================================================
        [HttpPost("CreateModule")]
        public async Task<IActionResult> CreateModule(
            [FromBody] CreateModuleRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateModule(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - UPDATE
        // ============================================================
        [HttpPost("UpdateModule")]
        public async Task<IActionResult> UpdateModule(
            [FromBody] UpdateModuleRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateModule(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - DELETE
        // ============================================================
        [HttpDelete("DeleteModule/{moduleID}")]
        public async Task<IActionResult> DeleteModule(
            int moduleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteModule(
                moduleID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - GET BY ID
        // ============================================================
        [HttpGet("GetModuleByID")]
        public async Task<IActionResult> GetModuleByID(
            int moduleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetModuleByID(
                moduleID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - GET ALL
        // ============================================================
        [HttpGet("GetAllModules")]
        public async Task<IActionResult> GetAllModules()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllModules(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveModules")]
        public async Task<IActionResult> GetActiveModules()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveModules(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - GET BY APPLICATION ID
        // ============================================================
        [HttpGet("GetModulesByApplicationID")]
        public async Task<IActionResult> GetModulesByApplicationID(
            int applicationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetModulesByApplicationID(
                applicationID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MODULES - GET ACTIVE BY APPLICATION ID
        // ============================================================
        [HttpGet("GetActiveModulesByApplicationID")]
        public async Task<IActionResult> GetActiveModulesByApplicationID(
            int applicationID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveModulesByApplicationID(
                    applicationID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // MENUS - CREATE
        // ============================================================
        [HttpPost("CreateMenu")]
        public async Task<IActionResult> CreateMenu(
            [FromBody] CreateMenuRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreateMenu(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - UPDATE
        // ============================================================
        [HttpPost("UpdateMenu")]
        public async Task<IActionResult> UpdateMenu(
            [FromBody] UpdateMenuRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdateMenu(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - DELETE
        // ============================================================
        [HttpDelete("DeleteMenu/{menuID}")]
        public async Task<IActionResult> DeleteMenu(
            int menuID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeleteMenu(
                menuID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET BY ID
        // ============================================================
        [HttpGet("GetMenuByID")]
        public async Task<IActionResult> GetMenuByID(
            int menuID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetMenuByID(
                menuID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET ALL
        // ============================================================
        [HttpGet("GetAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllMenus(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveMenus")]
        public async Task<IActionResult> GetActiveMenus()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActiveMenus(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET BY MODULE ID
        // ============================================================
        [HttpGet("GetMenusByModuleID")]
        public async Task<IActionResult> GetMenusByModuleID(
            int moduleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetMenusByModuleID(
                moduleID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET ACTIVE BY MODULE ID
        // ============================================================
        [HttpGet("GetActiveMenusByModuleID")]
        public async Task<IActionResult> GetActiveMenusByModuleID(
            int moduleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveMenusByModuleID(
                    moduleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENUS - GET BY PARENT ID
        // ============================================================
        [HttpGet("GetMenusByParentID")]
        public async Task<IActionResult> GetMenusByParentID(
            int parentID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetMenusByParentID(
                    parentID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // PERMISSION - CREATE
        // ============================================================
        [HttpPost("CreatePermission")]
        public async Task<IActionResult> CreatePermission(
            [FromBody] CreatePermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.CreatePermission(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PERMISSION - UPDATE
        // ============================================================
        [HttpPost("UpdatePermission")]
        public async Task<IActionResult> UpdatePermission(
            [FromBody] UpdatePermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.UpdatePermission(
                request,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PERMISSION - DELETE
        // ============================================================
        [HttpDelete("DeletePermission/{permissionID}")]
        public async Task<IActionResult> DeletePermission(
            int permissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.DeletePermission(
                permissionID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PERMISSION - GET BY ID
        // ============================================================
        [HttpGet("GetPermissionByID")]
        public async Task<IActionResult> GetPermissionByID(
            int permissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetPermissionByID(
                permissionID,
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PERMISSION - GET ALL
        // ============================================================
        [HttpGet("GetAllPermissions")]
        public async Task<IActionResult> GetAllPermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetAllPermissions(
                CallerUser);

            return Json(response);
        }


        // ============================================================
        // PERMISSION - GET ACTIVE
        // ============================================================
        [HttpGet("GetActivePermissions")]
        public async Task<IActionResult> GetActivePermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response = await _Provider.GetActivePermissions(
                CallerUser);

            return Json(response);
        }
        // ============================================================
        // MENU PERMISSIONS - CREATE
        // ============================================================
        [HttpPost("CreateMenuPermission")]
        public async Task<IActionResult> CreateMenuPermission(
            [FromBody] CreateMenuPermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateMenuPermission(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - UPDATE
        // ============================================================
        [HttpPost("UpdateMenuPermission")]
        public async Task<IActionResult> UpdateMenuPermission(
            [FromBody] UpdateMenuPermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateMenuPermission(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - DELETE
        // ============================================================
        [HttpDelete("DeleteMenuPermission/{menuPermissionID}")]
        public async Task<IActionResult> DeleteMenuPermission(
            int menuPermissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteMenuPermission(
                    menuPermissionID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY ID
        // ============================================================
        [HttpGet("GetMenuPermissionByID")]
        public async Task<IActionResult> GetMenuPermissionByID(
            int menuPermissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetMenuPermissionByID(
                    menuPermissionID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET ALL
        // ============================================================
        [HttpGet("GetAllMenuPermissions")]
        public async Task<IActionResult> GetAllMenuPermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllMenuPermissions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveMenuPermissions")]
        public async Task<IActionResult> GetActiveMenuPermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveMenuPermissions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY MENU ID
        // ============================================================
        [HttpGet("GetMenuPermissionsByMenuID")]
        public async Task<IActionResult> GetMenuPermissionsByMenuID(
            int menuID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetMenuPermissionsByMenuID(
                    menuID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE BY MENU ID
        // ============================================================
        [HttpGet("GetActiveMenuPermissionsByMenuID")]
        public async Task<IActionResult> GetActiveMenuPermissionsByMenuID(
            int menuID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveMenuPermissionsByMenuID(
                    menuID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY PERMISSION ID
        // ============================================================
        [HttpGet("GetMenuPermissionsByPermissionID")]
        public async Task<IActionResult> GetMenuPermissionsByPermissionID(
            int permissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetMenuPermissionsByPermissionID(
                    permissionID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // ROLES - CREATE
        // ============================================================
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(
            [FromBody] CreateRoleRequestaac request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateRole(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLES - UPDATE
        // ============================================================
        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(
            [FromBody] UpdateRoleRequestaac request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateRole(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLES - DELETE
        // ============================================================
        [HttpDelete("DeleteRole/{roleID}")]
        public async Task<IActionResult> DeleteRole(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteRole(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLES - GET BY ID
        // ============================================================
        [HttpGet("GetRoleByID")]
        public async Task<IActionResult> GetRoleByID(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRoleByID(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLES - GET ALL
        // ============================================================
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllRoles(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLES - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveRoles")]
        public async Task<IActionResult> GetActiveRoles()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveRoles(
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // TASKS - CREATE
        // ============================================================
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(
            [FromBody] CreateTaskRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateTask(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - UPDATE
        // ============================================================
        [HttpPost("UpdateTask")]
        public async Task<IActionResult> UpdateTask(
            [FromBody] UpdateTaskRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateTask(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - DELETE
        // ============================================================
        [HttpDelete("DeleteTask/{taskID}")]
        public async Task<IActionResult> DeleteTask(
            int taskID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteTask(
                    taskID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET BY ID
        // ============================================================
        [HttpGet("GetTaskByID")]
        public async Task<IActionResult> GetTaskByID(
            int taskID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetTaskByID(
                    taskID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET BY UID
        // ============================================================
        [HttpGet("GetTaskByUID")]
        public async Task<IActionResult> GetTaskByUID(
            Guid taskUID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetTaskByUID(
                    taskUID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET ALL
        // ============================================================
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllTasks(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveTasks")]
        public async Task<IActionResult> GetActiveTasks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveTasks(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET BY ENTITY TYPE ID
        // ============================================================
        [HttpGet("GetTasksByEntityTypeID")]
        public async Task<IActionResult> GetTasksByEntityTypeID(
            int entityTypeID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetTasksByEntityTypeID(
                    entityTypeID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // TASKS - GET ACTIVE BY ENTITY TYPE ID
        // ============================================================
        [HttpGet("GetActiveTasksByEntityTypeID")]
        public async Task<IActionResult> GetActiveTasksByEntityTypeID(
            int entityTypeID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveTasksByEntityTypeID(
                    entityTypeID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // ROLE TASK - CREATE
        // ============================================================
        [HttpPost("CreateRoleTask")]
        public async Task<IActionResult> CreateRoleTask(
            [FromBody] CreateRoleTaskRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateRoleTask(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - UPDATE
        // ============================================================
        [HttpPost("UpdateRoleTask")]
        public async Task<IActionResult> UpdateRoleTask(
            [FromBody] UpdateRoleTaskRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateRoleTask(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - DELETE
        // ============================================================
        [HttpDelete("DeleteRoleTask/{roleTaskID}")]
        public async Task<IActionResult> DeleteRoleTask(
            int roleTaskID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteRoleTask(
                    roleTaskID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET BY ID
        // ============================================================
        [HttpGet("GetRoleTaskByID")]
        public async Task<IActionResult> GetRoleTaskByID(
            int roleTaskID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRoleTaskByID(
                    roleTaskID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET BY UID
        // ============================================================
        [HttpGet("GetRoleTaskByUID")]
        public async Task<IActionResult> GetRoleTaskByUID(
            Guid roleTaskUID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRoleTaskByUID(
                    roleTaskUID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET ALL
        // ============================================================
        [HttpGet("GetAllRoleTasks")]
        public async Task<IActionResult> GetAllRoleTasks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllRoleTasks(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveRoleTasks")]
        public async Task<IActionResult> GetActiveRoleTasks()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveRoleTasks(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET BY ROLE ID
        // ============================================================
        [HttpGet("GetRoleTasksByRoleID")]
        public async Task<IActionResult> GetRoleTasksByRoleID(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRoleTasksByRoleID(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE BY ROLE ID
        // ============================================================
        [HttpGet("GetActiveRoleTasksByRoleID")]
        public async Task<IActionResult> GetActiveRoleTasksByRoleID(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveRoleTasksByRoleID(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE TASK - GET BY TASK ID
        // ============================================================
        [HttpGet("GetRoleTasksByTaskID")]
        public async Task<IActionResult> GetRoleTasksByTaskID(
            int taskID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRoleTasksByTaskID(
                    taskID,
                    CallerUser);

            return Json(response);
        }
        // ============================================================
        // ROLE PERMISSION - CREATE
        // ============================================================
        [HttpPost("CreateRolePermission")]
        public async Task<IActionResult> CreateRolePermission(
            [FromBody] CreateRolePermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.CreateRolePermission(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - UPDATE
        // ============================================================
        [HttpPost("UpdateRolePermission")]
        public async Task<IActionResult> UpdateRolePermission(
            [FromBody] UpdateRolePermissionRequest request)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.UpdateRolePermission(
                    request,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - DELETE
        // ============================================================
        [HttpDelete("DeleteRolePermission/{rolePermissionID}")]
        public async Task<IActionResult> DeleteRolePermission(
            int rolePermissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.DeleteRolePermission(
                    rolePermissionID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET BY ID
        // ============================================================
        [HttpGet("GetRolePermissionByID")]
        public async Task<IActionResult> GetRolePermissionByID(
            int rolePermissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRolePermissionByID(
                    rolePermissionID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET ALL
        // ============================================================
        [HttpGet("GetAllRolePermissions")]
        public async Task<IActionResult> GetAllRolePermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetAllRolePermissions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET ACTIVE
        // ============================================================
        [HttpGet("GetActiveRolePermissions")]
        public async Task<IActionResult> GetActiveRolePermissions()
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveRolePermissions(
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET BY ROLE ID
        // ============================================================
        [HttpGet("GetRolePermissionsByRoleID")]
        public async Task<IActionResult> GetRolePermissionsByRoleID(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRolePermissionsByRoleID(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET ACTIVE BY ROLE ID
        // ============================================================
        [HttpGet("GetActiveRolePermissionsByRoleID")]
        public async Task<IActionResult> GetActiveRolePermissionsByRoleID(
            int roleID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetActiveRolePermissionsByRoleID(
                    roleID,
                    CallerUser);

            return Json(response);
        }


        // ============================================================
        // ROLE PERMISSION - GET BY PERMISSION ID
        // ============================================================
        [HttpGet("GetRolePermissionsByPermissionID")]
        public async Task<IActionResult> GetRolePermissionsByPermissionID(
            int permissionID)
        {
            SimpleResponse response = new SimpleResponse();

            ErrorResponse error =
                await _callValidator.AuthenticateAndAuthorize(
                    CallerUser,
                    true);

            if (error.HasError)
            {
                response.SetError(error);
                return Json(response);
            }

            response =
                await _Provider.GetRolePermissionsByPermissionID(
                    permissionID,
                    CallerUser);

            return Json(response);
        }
    }
}
