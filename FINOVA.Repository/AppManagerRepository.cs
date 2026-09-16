using FINOVA.Database;
using FINOVA.DataModel.Appmgr;
using FINOVA.DataModel.Entities.SysModel;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Masters;
using FINOVA.DataModel.Shared;
using FINOVA.Repository.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINOVA.Repository
{
    public class AppManagerRepository:BaseRepository
    {
        public readonly IFINOVADatabase _database = null;
        public AppManagerRepository()
        {
            _database = new FINOVADatabase();
        }
        public async Task<long> CreateNewApplication(CreateapplicationRequest request, string AppToken, IFINOVAServiceUser serviceUser)
        {

            long outputstr = 0;
            SimpleResponse response = new SimpleResponse();
            var dbCommand = _database.GetStoredProcCommand("[AAC].CreateApp");
            _database.AddInParameter(dbCommand, "@OrganizationID", serviceUser.UserID);
            _database.AddInParameter(dbCommand, "@ApplicationToken", AppToken);
            _database.AddInParameter(dbCommand, "@ApplicationName", request.ApplicationName);
            _database.AddInParameter(dbCommand, "@ApplicationDescription", request.ApplicationDescription);
            _database.AddInParameter(dbCommand, "@Createdby", serviceUser.UserMasterID);
            _database.AddOutParameter(dbCommand, "@Out_ID", 100);

            await _database.ExecuteNonQueryAsync(dbCommand);

            outputstr = GetIDOutputLong(dbCommand);

            return outputstr;

        }
        // ============================================================
        // APPLICATIONS - CREATE
        // ============================================================
        public async Task<long> CreateApplication(
            CreateApplicationRequesttoken request,
            IFINOVAServiceUser serviceUser)
        {
            long applicationID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationToken",
                request.ApplicationToken);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationName",
                request.ApplicationName);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationDescription",
                request.ApplicationDescription);

            _database.AddInParameter(
                dbCommand,
                "@Createdby",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            applicationID =
                GetIDOutputLong(dbCommand);

            return applicationID;
        }


        // ============================================================
        // APPLICATIONS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateApplication(
            UpdateApplicationRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                request.ApplicationID);

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                request.OrganizationID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationTypeID",
                request.ApplicationTypeID);

            _database.AddInParameter(
                dbCommand,
                "@PlatformID",
                request.PlatformID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationToken",
                request.ApplicationToken);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationName",
                request.ApplicationName);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationDescription",
                request.ApplicationDescription);

            _database.AddInParameter(
                dbCommand,
                "@TokenCreatedDate",
                request.TokenCreatedDate);

            _database.AddInParameter(
                dbCommand,
                "@TokenExpireDate",
                request.TokenExpireDate);

            _database.AddInParameter(
                dbCommand,
                "@UserTokenExpiresAfterMins",
                request.UserTokenExpiresAfterMins);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@Updatedby",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET BY ID
        // ============================================================
        public async Task<GetApplicationResponse?> GetApplicationByID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            GetApplicationResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapApplication(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ALL
        // ============================================================
        public async Task<List<GetApplicationResponse>> GetAllApplications(
            IFINOVAServiceUser serviceUser)
        {
            List<GetApplicationResponse> response =
                new List<GetApplicationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapApplication(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE
        // ============================================================
        public async Task<List<GetApplicationResponse>> GetActiveApplications(
            IFINOVAServiceUser serviceUser)
        {
            List<GetApplicationResponse> response =
                new List<GetApplicationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapApplication(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET BY ORGANIZATION ID
        // ============================================================
        public async Task<List<GetApplicationResponse>>
            GetApplicationsByOrganizationID(
                long organizationID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetApplicationResponse> response =
                new List<GetApplicationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_GetByOrganizationID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                organizationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapApplication(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // APPLICATIONS - GET ACTIVE BY ORGANIZATION ID
        // ============================================================
        public async Task<List<GetApplicationResponse>>
            GetActiveApplicationsByOrganizationID(
                long organizationID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetApplicationResponse> response =
                new List<GetApplicationResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Applications_GetActiveByOrganizationID]");

            _database.AddInParameter(
                dbCommand,
                "@OrganizationID",
                organizationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapApplication(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // APPLICATIONS - COMMON MAPPER
        // ============================================================
        private GetApplicationResponse MapApplication(
            System.Data.IDataReader dataReader)
        {
            GetApplicationResponse row =
                new GetApplicationResponse();

            row.ApplicationID =
                GetInt32Value(
                    dataReader,
                    "ApplicationID").Value;

            row.OrganizationID =
                GetInt64Value(
                    dataReader,
                    "OrganizationID").Value;

            row.ApplicationTypeID =
                GetInt32Value(
                    dataReader,
                    "ApplicationTypeID").Value;

            row.PlatformID =
                GetInt32Value(
                    dataReader,
                    "PlatformID").Value;

            row.IconID =
                GetInt64Value(
                    dataReader,
                    "IconID").Value;

            row.ApplicationToken =
                GetStringValue(
                    dataReader,
                    "ApplicationToken");

            row.ApplicationName =
                GetStringValue(
                    dataReader,
                    "ApplicationName");

            row.ApplicationDescription =
                GetStringValue(
                    dataReader,
                    "ApplicationDescription");
            row.OrganizationName =
               GetStringValue(
                   dataReader,
                   "OrganizationName");
            row.MobileNo =
              GetStringValue(
                  dataReader,
                  "MobileNo");
            row.Email =
             GetStringValue(
                 dataReader,
                 "Email");

            row.TokenCreatedDate =
                dataReader["TokenCreatedDate"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["TokenCreatedDate"];

            row.TokenExpireDate =
                dataReader["TokenExpireDate"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["TokenExpireDate"];

            row.UserTokenExpiresAfterMins =
                GetInt32Value(
                    dataReader,
                    "UserTokenExpiresAfterMins").Value;

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                GetDateTimeValue(
                    dataReader,
                    "CreatedOn");

            row.Createdby =
                GetInt64Value(
                    dataReader,
                    "Createdby").Value;

            row.UpdatedOn =
                GetDateTimeValue(
                    dataReader,
                    "UpdatedOn");

            row.Updatedby =
                GetInt64Value(
                    dataReader,
                    "Updatedby");

            return row;
        }
        // ============================================================
        // MODULES - CREATE
        // ============================================================
        public async Task<long> CreateModule(
            CreateModuleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long moduleID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                request.ModuleID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                request.ApplicationID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@ModuleName",
                request.ModuleName);

            _database.AddInParameter(
                dbCommand,
                "@ModuleDescription",
                request.ModuleDescription);

            _database.AddInParameter(
                dbCommand,
                "@DefaultMenuUrl",
                request.DefaultMenuUrl);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@Createdby",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            moduleID =
                GetIDOutputLong(dbCommand);

            return moduleID;
        }


        // ============================================================
        // MODULES - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateModule(
            UpdateModuleRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                request.ModuleID);

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                request.ApplicationID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@ModuleName",
                request.ModuleName);

            _database.AddInParameter(
                dbCommand,
                "@ModuleDescription",
                request.ModuleDescription);

            _database.AddInParameter(
                dbCommand,
                "@DefaultMenuUrl",
                request.DefaultMenuUrl);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@Updatedby",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                moduleID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // MODULES - GET BY ID
        // ============================================================
        public async Task<GetModuleResponse?> GetModuleByID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            GetModuleResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                moduleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapModule(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // MODULES - GET ALL
        // ============================================================
        public async Task<List<GetModuleResponse>> GetAllModules(
            IFINOVAServiceUser serviceUser)
        {
            List<GetModuleResponse> response =
                new List<GetModuleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapModule(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MODULES - GET ACTIVE
        // ============================================================
        public async Task<List<GetModuleResponse>> GetActiveModules(
            IFINOVAServiceUser serviceUser)
        {
            List<GetModuleResponse> response =
                new List<GetModuleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapModule(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MODULES - GET BY APPLICATION ID
        // ============================================================
        public async Task<List<GetModuleResponse>> GetModulesByApplicationID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetModuleResponse> response =
                new List<GetModuleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_GetByApplicationID]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapModule(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MODULES - GET ACTIVE BY APPLICATION ID
        // ============================================================
        public async Task<List<GetModuleResponse>> GetActiveModulesByApplicationID(
            int applicationID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetModuleResponse> response =
                new List<GetModuleResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Modules_GetActiveByApplicationID]");

            _database.AddInParameter(
                dbCommand,
                "@ApplicationID",
                applicationID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapModule(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MODULES - COMMON MAPPER
        // ============================================================
        private GetModuleResponse MapModule(
            System.Data.IDataReader dataReader)
        {
            GetModuleResponse row =
                new GetModuleResponse();

            row.ModuleID =
                GetInt32Value(
                    dataReader,
                    "ModuleID").Value;

            row.ApplicationID =
                GetInt32Value(
                    dataReader,
                    "ApplicationID").Value;

            row.ApplicationName =
                GetStringValue(
                    dataReader,
                    "ApplicationName");

            row.IconID =
                GetInt64Value(
                    dataReader,
                    "IconID");

            row.ModuleName =
                GetStringValue(
                    dataReader,
                    "ModuleName");

            row.ModuleDescription =
                GetStringValue(
                    dataReader,
                    "ModuleDescription");

            row.DefaultMenuUrl =
                GetStringValue(
                    dataReader,
                    "DefaultMenuUrl");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.Createdby =
                GetInt64Value(
                    dataReader,
                    "Createdby").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.Updatedby =
                GetInt64Value(
                    dataReader,
                    "Updatedby");

            return row;
        }
        // ============================================================
        // MENUS - CREATE
        // ============================================================
        public async Task<long> CreateMenu(
            CreateMenuRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long menuID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                request.ModuleID);

            _database.AddInParameter(
                dbCommand,
                "@ParentID",
                request.ParentID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@Title",
                request.Title);

            _database.AddInParameter(
                dbCommand,
                "@Tooltip",
                request.Tooltip);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@RoutePath",
                request.RoutePath);

            _database.AddInParameter(
                dbCommand,
                "@DisplayOrder",
                request.DisplayOrder);

            _database.AddInParameter(
                dbCommand,
                "@Target",
                request.Target);

            _database.AddInParameter(
                dbCommand,
                "@IsExternal",
                request.IsExternal);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            menuID = GetIDOutputLong(dbCommand);

            return menuID;
        }


        // ============================================================
        // MENUS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateMenu(
            UpdateMenuRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_Update]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                request.MenuID);

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                request.ModuleID);

            _database.AddInParameter(
                dbCommand,
                "@ParentID",
                request.ParentID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@Title",
                request.Title);

            _database.AddInParameter(
                dbCommand,
                "@Tooltip",
                request.Tooltip);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@RoutePath",
                request.RoutePath);

            _database.AddInParameter(
                dbCommand,
                "@DisplayOrder",
                request.DisplayOrder);

            _database.AddInParameter(
                dbCommand,
                "@Target",
                request.Target);

            _database.AddInParameter(
                dbCommand,
                "@IsExternal",
                request.IsExternal);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                menuID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // MENUS - GET BY ID
        // ============================================================
        public async Task<GetMenuResponse?> GetMenuByID(
            int menuID,
            IFINOVAServiceUser serviceUser)
        {
            GetMenuResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                menuID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapMenu(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - GET ALL
        // ============================================================
        public async Task<List<GetMenuResponse>> GetAllMenus(
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuResponse> response =
                new List<GetMenuResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenu(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - GET ACTIVE
        // ============================================================
        public async Task<List<GetMenuResponse>> GetActiveMenus(
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuResponse> response =
                new List<GetMenuResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenu(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - GET BY MODULE ID
        // ============================================================
        public async Task<List<GetMenuResponse>> GetMenusByModuleID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuResponse> response =
                new List<GetMenuResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetByModuleID]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                moduleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenu(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - GET ACTIVE BY MODULE ID
        // ============================================================
        public async Task<List<GetMenuResponse>> GetActiveMenusByModuleID(
            int moduleID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuResponse> response =
                new List<GetMenuResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetActiveByModuleID]");

            _database.AddInParameter(
                dbCommand,
                "@ModuleID",
                moduleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenu(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - GET BY PARENT ID
        // ============================================================
        public async Task<List<GetMenuResponse>> GetMenusByParentID(
            int parentID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuResponse> response =
                new List<GetMenuResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Menus_GetByParentID]");

            _database.AddInParameter(
                dbCommand,
                "@ParentID",
                parentID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenu(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENUS - COMMON MAPPER
        // ============================================================
        private GetMenuResponse MapMenu(
            System.Data.IDataReader dataReader)
        {
            GetMenuResponse row =
                new GetMenuResponse();

            row.MenuID =
                GetInt32Value(
                    dataReader,
                    "MenuID").Value;

            row.ModuleID =
                GetInt32Value(
                    dataReader,
                    "ModuleID").Value;

            row.ModuleName =
                GetStringValue(
                    dataReader,
                    "ModuleName");

            row.ParentID =
                GetInt32Value(
                    dataReader,
                    "ParentID");

            row.ParentMenuTitle =
                GetStringValue(
                    dataReader,
                    "ParentMenuTitle");

            row.IconID =
                GetInt64Value(
                    dataReader,
                    "IconID");

            row.Title =
                GetStringValue(
                    dataReader,
                    "Title");

            row.Tooltip =
                GetStringValue(
                    dataReader,
                    "Tooltip");

            row.Description =
                GetStringValue(
                    dataReader,
                    "Description");

            row.RoutePath =
                GetStringValue(
                    dataReader,
                    "RoutePath");

            row.DisplayOrder =
                GetInt32Value(
                    dataReader,
                    "DisplayOrder").Value;

            row.Target =
                GetStringValue(
                    dataReader,
                    "Target");

            row.IsExternal =
                dataReader["IsExternal"] == DBNull.Value
                    ? (bool?)null
                    : Convert.ToBoolean(
                        dataReader["IsExternal"]);

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // PERMISSION - CREATE
        // ============================================================
        public async Task<long> CreatePermission(
            CreatePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long permissionID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionName",
                request.PermissionName);

            _database.AddInParameter(
                dbCommand,
                "@PermissionDescription",
                request.PermissionDescription);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            permissionID =
                GetIDOutputLong(dbCommand);

            return permissionID;
        }


        // ============================================================
        // PERMISSION - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdatePermission(
            UpdatePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_Update]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                request.PermissionID);

            _database.AddInParameter(
                dbCommand,
                "@PermissionName",
                request.PermissionName);

            _database.AddInParameter(
                dbCommand,
                "@PermissionDescription",
                request.PermissionDescription);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                permissionID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // PERMISSION - GET BY ID
        // ============================================================
        public async Task<GetPermissionResponse?> GetPermissionByID(
            int permissionID,
            IFINOVAServiceUser serviceUser)
        {
            GetPermissionResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                permissionID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapPermission(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // PERMISSION - GET ALL
        // ============================================================
        public async Task<List<GetPermissionResponse>> GetAllPermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPermissionResponse> response =
                new List<GetPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PERMISSION - GET ACTIVE
        // ============================================================
        public async Task<List<GetPermissionResponse>> GetActivePermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetPermissionResponse> response =
                new List<GetPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Permission_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // PERMISSION - COMMON MAPPER
        // ============================================================
        private GetPermissionResponse MapPermission(
            System.Data.IDataReader dataReader)
        {
            GetPermissionResponse row =
                new GetPermissionResponse();

            row.PermissionID =
                GetInt32Value(
                    dataReader,
                    "PermissionID").Value;

            row.PermissionName =
                GetStringValue(
                    dataReader,
                    "PermissionName");

            row.PermissionDescription =
                GetStringValue(
                    dataReader,
                    "PermissionDescription");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // MENU PERMISSIONS - CREATE
        // ============================================================
        public async Task<long> CreateMenuPermission(
            CreateMenuPermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long menuPermissionID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                request.MenuID);

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                request.PermissionID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            menuPermissionID =
                GetIDOutputLong(dbCommand);

            return menuPermissionID;
        }


        // ============================================================
        // MENU PERMISSIONS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateMenuPermission(
            UpdateMenuPermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_Update]");

            _database.AddInParameter(
                dbCommand,
                "@MenuPermissionID",
                request.MenuPermissionID);

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                request.MenuID);

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                request.PermissionID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@MenuPermissionID",
                menuPermissionID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY ID
        // ============================================================
        public async Task<GetMenuPermissionResponse?> GetMenuPermissionByID(
            int menuPermissionID,
            IFINOVAServiceUser serviceUser)
        {
            GetMenuPermissionResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@MenuPermissionID",
                menuPermissionID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapMenuPermission(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ALL
        // ============================================================
        public async Task<List<GetMenuPermissionResponse>> GetAllMenuPermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuPermissionResponse> response =
                new List<GetMenuPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenuPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE
        // ============================================================
        public async Task<List<GetMenuPermissionResponse>> GetActiveMenuPermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetMenuPermissionResponse> response =
                new List<GetMenuPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenuPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY MENU ID
        // ============================================================
        public async Task<List<GetMenuPermissionResponse>>
            GetMenuPermissionsByMenuID(
                int menuID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetMenuPermissionResponse> response =
                new List<GetMenuPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetByMenuID]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                menuID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenuPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET ACTIVE BY MENU ID
        // ============================================================
        public async Task<List<GetMenuPermissionResponse>>
            GetActiveMenuPermissionsByMenuID(
                int menuID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetMenuPermissionResponse> response =
                new List<GetMenuPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetActiveByMenuID]");

            _database.AddInParameter(
                dbCommand,
                "@MenuID",
                menuID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenuPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - GET BY PERMISSION ID
        // ============================================================
        public async Task<List<GetMenuPermissionResponse>>
            GetMenuPermissionsByPermissionID(
                int permissionID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetMenuPermissionResponse> response =
                new List<GetMenuPermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[MenuPermissions_GetByPermissionID]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                permissionID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapMenuPermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // MENU PERMISSIONS - COMMON MAPPER
        // ============================================================
        private GetMenuPermissionResponse MapMenuPermission(
            System.Data.IDataReader dataReader)
        {
            GetMenuPermissionResponse row =
                new GetMenuPermissionResponse();

            row.MenuPermissionID =
                GetInt32Value(
                    dataReader,
                    "MenuPermissionID").Value;

            row.MenuID =
                GetInt32Value(
                    dataReader,
                    "MenuID").Value;

            row.MenuTitle =
                GetStringValue(
                    dataReader,
                    "MenuTitle");

            row.PermissionID =
                GetInt32Value(
                    dataReader,
                    "PermissionID").Value;

            row.PermissionName =
                GetStringValue(
                    dataReader,
                    "PermissionName");

            row.PermissionDescription =
                GetStringValue(
                    dataReader,
                    "PermissionDescription");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // ROLES - CREATE
        // ============================================================
        public async Task<long> CreateRole(
            CreateRoleRequestaac request,
            IFINOVAServiceUser serviceUser)
        {
            long roleID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@RoleName",
                request.RoleName);

            _database.AddInParameter(
                dbCommand,
                "@RoleDescription",
                request.RoleDescription);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            roleID = GetIDOutputLong(dbCommand);

            return roleID;
        }


        // ============================================================
        // ROLES - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRole(
            UpdateRoleRequestaac request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_Update]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@IconID",
                request.IconID);

            _database.AddInParameter(
                dbCommand,
                "@RoleName",
                request.RoleName);

            _database.AddInParameter(
                dbCommand,
                "@RoleDescription",
                request.RoleDescription);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ROLES - GET BY ID
        // ============================================================
        public async Task<GetRoleResponseaac?> GetRoleByID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            GetRoleResponseaac? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapRole(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ROLES - GET ALL
        // ============================================================
        public async Task<List<GetRoleResponseaac>> GetAllRoles(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleResponseaac> response =
                new List<GetRoleResponseaac>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRole(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLES - GET ACTIVE
        // ============================================================
        public async Task<List<GetRoleResponseaac>> GetActiveRoles(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleResponseaac> response =
                new List<GetRoleResponseaac>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Roles_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRole(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON ROLE MAPPER
        // ============================================================
        private GetRoleResponseaac MapRole(
            System.Data.IDataReader dataReader)
        {
            GetRoleResponseaac row =
                new GetRoleResponseaac();

            row.RoleID =
                GetInt32Value(
                    dataReader,
                    "RoleID").Value;

            row.IconID =
                GetInt64Value(
                    dataReader,
                    "IconID");

            row.RoleName =
                GetStringValue(
                    dataReader,
                    "RoleName");

            row.RoleDescription =
                GetStringValue(
                    dataReader,
                    "RoleDescription");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // TASKS - CREATE
        // ============================================================
        public async Task<long> CreateTask(
            CreateTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long taskID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@TaskName",
                request.TaskName);

            _database.AddInParameter(
                dbCommand,
                "@TaskTooltip",
                request.TaskTooltip);

            _database.AddInParameter(
                dbCommand,
                "@TaskDescription",
                request.TaskDescription);

            _database.AddInParameter(
                dbCommand,
                "@EntityTypeID",
                request.EntityTypeID);

            _database.AddInParameter(
                dbCommand,
                "@TaskURI",
                request.TaskURI);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            taskID = GetIDOutputLong(dbCommand);

            return taskID;
        }


        // ============================================================
        // TASKS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTask(
            UpdateTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_Update]");

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                request.TaskID);

            _database.AddInParameter(
                dbCommand,
                "@TaskName",
                request.TaskName);

            _database.AddInParameter(
                dbCommand,
                "@TaskTooltip",
                request.TaskTooltip);

            _database.AddInParameter(
                dbCommand,
                "@TaskDescription",
                request.TaskDescription);

            _database.AddInParameter(
                dbCommand,
                "@EntityTypeID",
                request.EntityTypeID);

            _database.AddInParameter(
                dbCommand,
                "@TaskURI",
                request.TaskURI);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                taskID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // TASKS - GET BY ID
        // ============================================================
        public async Task<GetTaskResponse?> GetTaskByID(
            int taskID,
            IFINOVAServiceUser serviceUser)
        {
            GetTaskResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                taskID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapTask(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // TASKS - GET BY UID
        // ============================================================
        public async Task<GetTaskResponse?> GetTaskByUID(
            Guid taskUID,
            IFINOVAServiceUser serviceUser)
        {
            GetTaskResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetByUID]");

            _database.AddInParameter(
                dbCommand,
                "@TaskUID",
                taskUID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapTask(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // TASKS - GET ALL
        // ============================================================
        public async Task<List<GetTaskResponse>> GetAllTasks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetTaskResponse> response =
                new List<GetTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TASKS - GET ACTIVE
        // ============================================================
        public async Task<List<GetTaskResponse>> GetActiveTasks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetTaskResponse> response =
                new List<GetTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TASKS - GET BY ENTITY TYPE ID
        // ============================================================
        public async Task<List<GetTaskResponse>> GetTasksByEntityTypeID(
            int entityTypeID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetTaskResponse> response =
                new List<GetTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetByEntityTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@EntityTypeID",
                entityTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TASKS - GET ACTIVE BY ENTITY TYPE ID
        // ============================================================
        public async Task<List<GetTaskResponse>> GetActiveTasksByEntityTypeID(
            int entityTypeID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetTaskResponse> response =
                new List<GetTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[Tasks_GetActiveByEntityTypeID]");

            _database.AddInParameter(
                dbCommand,
                "@EntityTypeID",
                entityTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON TASK MAPPER
        // ============================================================
        private GetTaskResponse MapTask(
            System.Data.IDataReader dataReader)
        {
            GetTaskResponse row =
                new GetTaskResponse();

            row.TaskID =
                GetInt32Value(
                    dataReader,
                    "TaskID").Value;

            row.TaskUID =
                dataReader["TaskUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["TaskUID"];

            row.TaskName =
                GetStringValue(
                    dataReader,
                    "TaskName");

            row.TaskTooltip =
                GetStringValue(
                    dataReader,
                    "TaskTooltip");

            row.TaskDescription =
                GetStringValue(
                    dataReader,
                    "TaskDescription");

            row.EntityTypeID =
                GetInt32Value(
                    dataReader,
                    "EntityTypeID").Value;

            row.TaskURI =
                GetStringValue(
                    dataReader,
                    "TaskURI");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // ROLE TASK - CREATE
        // ============================================================
        public async Task<long> CreateRoleTask(
            CreateRoleTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long roleTaskID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                request.TaskID);

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@TAT",
                request.TAT);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            roleTaskID = GetIDOutputLong(dbCommand);

            return roleTaskID;
        }


        // ============================================================
        // ROLE TASK - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRoleTask(
            UpdateRoleTaskRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_Update]");

            _database.AddInParameter(
                dbCommand,
                "@RoleTaskID",
                request.RoleTaskID);

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                request.TaskID);

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@TAT",
                request.TAT);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

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

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@RoleTaskID",
                roleTaskID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY ID
        // ============================================================
        public async Task<GetRoleTaskResponse?> GetRoleTaskByID(
            int roleTaskID,
            IFINOVAServiceUser serviceUser)
        {
            GetRoleTaskResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleTaskID",
                roleTaskID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapRoleTask(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY UID
        // ============================================================
        public async Task<GetRoleTaskResponse?> GetRoleTaskByUID(
            Guid roleTaskUID,
            IFINOVAServiceUser serviceUser)
        {
            GetRoleTaskResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetByUID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleTaskUID",
                roleTaskUID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapRoleTask(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ALL
        // ============================================================
        public async Task<List<GetRoleTaskResponse>> GetAllRoleTasks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleTaskResponse> response =
                new List<GetRoleTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRoleTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE
        // ============================================================
        public async Task<List<GetRoleTaskResponse>> GetActiveRoleTasks(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleTaskResponse> response =
                new List<GetRoleTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRoleTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY ROLE ID
        // ============================================================
        public async Task<List<GetRoleTaskResponse>> GetRoleTasksByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleTaskResponse> response =
                new List<GetRoleTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetByRoleID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRoleTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET ACTIVE BY ROLE ID
        // ============================================================
        public async Task<List<GetRoleTaskResponse>> GetActiveRoleTasksByRoleID(
            int roleID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleTaskResponse> response =
                new List<GetRoleTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetActiveByRoleID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRoleTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE TASK - GET BY TASK ID
        // ============================================================
        public async Task<List<GetRoleTaskResponse>> GetRoleTasksByTaskID(
            int taskID,
            IFINOVAServiceUser serviceUser)
        {
            List<GetRoleTaskResponse> response =
                new List<GetRoleTaskResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RoleTask_GetByTaskID]");

            _database.AddInParameter(
                dbCommand,
                "@TaskID",
                taskID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRoleTask(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON ROLE TASK MAPPER
        // ============================================================
        private GetRoleTaskResponse MapRoleTask(
            System.Data.IDataReader dataReader)
        {
            GetRoleTaskResponse row =
                new GetRoleTaskResponse();

            row.RoleTaskID =
                GetInt32Value(
                    dataReader,
                    "RoleTaskID").Value;

            row.RoleTaskUID =
                dataReader["RoleTaskUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["RoleTaskUID"];

            row.RoleID =
                GetInt32Value(
                    dataReader,
                    "RoleID").Value;

            row.RoleName =
                GetStringValue(
                    dataReader,
                    "RoleName");

            row.RoleDescription =
                GetStringValue(
                    dataReader,
                    "RoleDescription");

            row.TaskID =
                GetInt32Value(
                    dataReader,
                    "TaskID").Value;

            row.TaskUID =
                dataReader["TaskUID"] == DBNull.Value
                    ? Guid.Empty
                    : (Guid)dataReader["TaskUID"];

            row.TaskName =
                GetStringValue(
                    dataReader,
                    "TaskName");

            row.TaskTooltip =
                GetStringValue(
                    dataReader,
                    "TaskTooltip");

            row.TaskDescription =
                GetStringValue(
                    dataReader,
                    "TaskDescription");

            row.EntityTypeID =
                GetInt32Value(
                    dataReader,
                    "EntityTypeID").Value;

            row.TaskURI =
                GetStringValue(
                    dataReader,
                    "TaskURI");

            // SQL TIME maps to TimeSpan in C#
            row.TAT =
                dataReader["TAT"] == DBNull.Value
                    ? (TimeSpan?)null
                    : (TimeSpan)dataReader["TAT"];

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
        // ============================================================
        // ROLE PERMISSIONS - CREATE
        // ============================================================
        public async Task<long> CreateRolePermission(
            CreateRolePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long rolePermissionID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                request.PermissionID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            _database.AddOutParameter(
                dbCommand,
                "@Out_ID",
                OUTPARAMETER_SIZE);

            await _database.ExecuteNonQueryAsync(dbCommand);

            rolePermissionID =
                GetIDOutputLong(dbCommand);

            return rolePermissionID;
        }


        // ============================================================
        // ROLE PERMISSIONS - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateRolePermission(
            UpdateRolePermissionRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_Update]");

            _database.AddInParameter(
                dbCommand,
                "@RolePermissionID",
                request.RolePermissionID);

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                request.RoleID);

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                request.PermissionID);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@UpdatedBy",
                serviceUser.UserMasterID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteRolePermission(
            int rolePermissionID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@RolePermissionID",
                rolePermissionID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET BY ID
        // ============================================================
        public async Task<GetRolePermissionResponse?> GetRolePermissionByID(
            int rolePermissionID,
            IFINOVAServiceUser serviceUser)
        {
            GetRolePermissionResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@RolePermissionID",
                rolePermissionID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response =
                        MapRolePermission(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET ALL
        // ============================================================
        public async Task<List<GetRolePermissionResponse>> GetAllRolePermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRolePermissionResponse> response =
                new List<GetRolePermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRolePermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET ACTIVE
        // ============================================================
        public async Task<List<GetRolePermissionResponse>> GetActiveRolePermissions(
            IFINOVAServiceUser serviceUser)
        {
            List<GetRolePermissionResponse> response =
                new List<GetRolePermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRolePermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET BY ROLE ID
        // ============================================================
        public async Task<List<GetRolePermissionResponse>>
            GetRolePermissionsByRoleID(
                int roleID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetRolePermissionResponse> response =
                new List<GetRolePermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetByRoleID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRolePermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET ACTIVE BY ROLE ID
        // ============================================================
        public async Task<List<GetRolePermissionResponse>>
            GetActiveRolePermissionsByRoleID(
                int roleID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetRolePermissionResponse> response =
                new List<GetRolePermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetActiveByRoleID]");

            _database.AddInParameter(
                dbCommand,
                "@RoleID",
                roleID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRolePermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // ROLE PERMISSIONS - GET BY PERMISSION ID
        // ============================================================
        public async Task<List<GetRolePermissionResponse>>
            GetRolePermissionsByPermissionID(
                int permissionID,
                IFINOVAServiceUser serviceUser)
        {
            List<GetRolePermissionResponse> response =
                new List<GetRolePermissionResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[AAC].[RolePermissions_GetByPermissionID]");

            _database.AddInParameter(
                dbCommand,
                "@PermissionID",
                permissionID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapRolePermission(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // COMMON ROLE PERMISSION MAPPER
        // ============================================================
        private GetRolePermissionResponse MapRolePermission(
            System.Data.IDataReader dataReader)
        {
            GetRolePermissionResponse row =
                new GetRolePermissionResponse();

            row.RolePermissionID =
                GetInt32Value(
                    dataReader,
                    "RolePermissionID").Value;

            row.RoleID =
                GetInt32Value(
                    dataReader,
                    "RoleID").Value;

            row.RoleName =
                GetStringValue(
                    dataReader,
                    "RoleName");

            row.RoleDescription =
                GetStringValue(
                    dataReader,
                    "RoleDescription");

            row.PermissionID =
                GetInt32Value(
                    dataReader,
                    "PermissionID").Value;

            row.PermissionName =
                GetStringValue(
                    dataReader,
                    "PermissionName");

            row.PermissionDescription =
                GetStringValue(
                    dataReader,
                    "PermissionDescription");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.StatusName =
                GetStringValue(
                    dataReader,
                    "StatusName");

            row.CreatedOn =
                dataReader["CreatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["CreatedOn"];

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                dataReader["UpdatedOn"] == DBNull.Value
                    ? (DateTimeOffset?)null
                    : (DateTimeOffset)dataReader["UpdatedOn"];

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
    }
}
