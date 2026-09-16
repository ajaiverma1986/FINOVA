using FINOVA.Database;
using FINOVA.DataModel.Entities.Notification;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Repository.Shared;
using System.Data;

namespace FINOVA.Repository
{
    public class NotificationRepository : BaseRepository
    {
        public readonly IFINOVADatabase _database = null;

        public NotificationRepository()
        {
            _database = new FINOVADatabase();
        }

        /// <summary>
        /// Create new Email Gateway configuration.
        /// </summary>
        public async Task<int> CreateEmailGateway(
            CreateEmailGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int emailGatewayID = 0;

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[EmailGateway_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@SMTPServer",
                request.SMTPServer);

            _database.AddInParameter(
                dbCommand,
                "@SMTPPort",
                request.SMTPPort);

            _database.AddInParameter(
                dbCommand,
                "@SMTPEnableSSL",
                request.SMTPEnableSSL);

            _database.AddInParameter(
                dbCommand,
                "@SMTPUsername",
                request.SMTPUsername);

            _database.AddInParameter(
                dbCommand,
                "@SMTPPassword",
                request.SMTPPassword);

            _database.AddInParameter(
                dbCommand,
                "@SMTPSenderEmail",
                request.SMTPSenderEmail);

            _database.AddInParameter(
                dbCommand,
                "@SMTPSenderName",
                request.SMTPSenderName);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    emailGatewayID =
                        GetInt32Value(dataReader, "EmailGatewayID").Value;
                }
            }

            return emailGatewayID;
        }


        /// <summary>
        /// Update Email Gateway configuration.
        /// </summary>
        public async Task<SimpleResponse> UpdateEmailGateway(
            UpdateEmailGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[EmailGateway_Update]");

            _database.AddInParameter(
                dbCommand,
                "@EmailGatewayID",
                request.EmailGatewayID);

            _database.AddInParameter(
                dbCommand,
                "@SMTPServer",
                request.SMTPServer);

            _database.AddInParameter(
                dbCommand,
                "@SMTPPort",
                request.SMTPPort);

            _database.AddInParameter(
                dbCommand,
                "@SMTPEnableSSL",
                request.SMTPEnableSSL);

            _database.AddInParameter(
                dbCommand,
                "@SMTPUsername",
                request.SMTPUsername);

            _database.AddInParameter(
                dbCommand,
                "@SMTPPassword",
                request.SMTPPassword);

            _database.AddInParameter(
                dbCommand,
                "@SMTPSenderEmail",
                request.SMTPSenderEmail);

            _database.AddInParameter(
                dbCommand,
                "@SMTPSenderName",
                request.SMTPSenderName);

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


        /// <summary>
        /// Delete Email Gateway.
        /// </summary>
        public async Task<SimpleResponse> DeleteEmailGateway(
            int emailGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[EmailGateway_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@EmailGatewayID",
                emailGatewayID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        /// <summary>
        /// Get Email Gateway by ID.
        /// </summary>
        public async Task<GetEmailGatewayResponse?> GetEmailGatewayByID(
            int emailGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            GetEmailGatewayResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[EmailGateway_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@EmailGatewayID",
                emailGatewayID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapEmailGateway(dataReader);
                }
            }

            return response;
        }


        /// <summary>
        /// Get all Email Gateways.
        /// </summary>
        public async Task<List<GetEmailGatewayResponse>> GetAllEmailGateways(
            IFINOVAServiceUser serviceUser)
        {
            List<GetEmailGatewayResponse> response =
                new List<GetEmailGatewayResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[EmailGateway_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapEmailGateway(dataReader));
                }
            }

            return response;
        }


        /// <summary>
        /// Get currently active Email Gateway.
        /// </summary>
        public async Task<GetActiveEmailGatewayResponse?>
            GetActiveEmailGateway(
                IFINOVAServiceUser serviceUser)
        {
            GetActiveEmailGatewayResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[EmailGateway_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = new GetActiveEmailGatewayResponse
                    {
                        EmailGatewayID =
                            GetInt32Value(
                                dataReader,
                                "EmailGatewayID").Value,

                        SMTPServer =
                            GetStringValue(
                                dataReader,
                                "SMTPServer"),

                        SMTPPort =
                            GetInt32Value(
                                dataReader,
                                "SMTPPort").Value,

                        SMTPEnableSSL =
                            GetBoolValue(
                                dataReader,
                                "SMTPEnableSSL"),

                        SMTPUsername =
                            GetStringValue(
                                dataReader,
                                "SMTPUsername"),

                        SMTPPassword =
                            GetStringValue(
                                dataReader,
                                "SMTPPassword"),

                        SMTPSenderEmail =
                            GetStringValue(
                                dataReader,
                                "SMTPSenderEmail"),

                        SMTPSenderName =
                            GetStringValue(
                                dataReader,
                                "SMTPSenderName")
                    };
                }
            }

            return response;
        }


        /// <summary>
        /// Common mapping for Email Gateway.
        /// </summary>
        private GetEmailGatewayResponse MapEmailGateway(
            System.Data.IDataReader dataReader)
        {
            return new GetEmailGatewayResponse
            {
                EmailGatewayID =
                    GetInt32Value(
                        dataReader,
                        "EmailGatewayID").Value,

                SMTPServer =
                    GetStringValue(
                        dataReader,
                        "SMTPServer"),

                SMTPPort =
                    GetInt32Value(
                        dataReader,
                        "SMTPPort").Value,

                SMTPEnableSSL =
                    GetBoolValue(
                        dataReader,
                        "SMTPEnableSSL"),

                SMTPUsername =
                    GetStringValue(
                        dataReader,
                        "SMTPUsername"),

                SMTPSenderEmail =
                    GetStringValue(
                        dataReader,
                        "SMTPSenderEmail"),

                SMTPSenderName =
                    GetStringValue(
                        dataReader,
                        "SMTPSenderName"),

                Status =
                    GetInt32Value(
                        dataReader,
                        "Status").Value,

                CreatedOn =
                    GetDateValue(
                        dataReader,
                        "CreatedOn").Value,

                CreatedBy =
                    GetInt64Value(
                        dataReader,
                        "CreatedBy").Value,

                UpdatedOn =
                    GetDateValue(
                        dataReader,
                        "UpdatedOn"),

                UpdatedBy =
                    GetInt64Value(
                        dataReader,
                        "UpdatedBy")
            };
        }
        // ============================================================
        // SMS GATEWAY - CREATE
        // ============================================================
        public async Task<int> CreateSMSGateway(
            CreateSMSGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int smsGatewayID = 0;

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[SMSGateway_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@SMSGatewayName",
                request.SMSGatewayName);

            _database.AddInParameter(
                dbCommand,
                "@GatewayURL",
                request.GatewayURL);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@Password",
                request.Password);

            _database.AddInParameter(
                dbCommand,
                "@SenderID",
                request.SenderID);

            _database.AddInParameter(
                dbCommand,
                "@ReponseSuccess",
                request.ReponseSuccess);

            _database.AddInParameter(
                dbCommand,
                "@ReponseError",
                request.ReponseError);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    smsGatewayID =
                        GetInt32Value(
                            dataReader,
                            "SMSGatewayID").Value;
                }
            }

            return smsGatewayID;
        }


        // ============================================================
        // SMS GATEWAY - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateSMSGateway(
            UpdateSMSGatewayRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[SMSGateway_Update]");

            _database.AddInParameter(
                dbCommand,
                "@SMSGatewayID",
                request.SMSGatewayID);

            _database.AddInParameter(
                dbCommand,
                "@SMSGatewayName",
                request.SMSGatewayName);

            _database.AddInParameter(
                dbCommand,
                "@GatewayURL",
                request.GatewayURL);

            _database.AddInParameter(
                dbCommand,
                "@UserName",
                request.UserName);

            _database.AddInParameter(
                dbCommand,
                "@Password",
                request.Password);

            _database.AddInParameter(
                dbCommand,
                "@SenderID",
                request.SenderID);

            _database.AddInParameter(
                dbCommand,
                "@ReponseSuccess",
                request.ReponseSuccess);

            _database.AddInParameter(
                dbCommand,
                "@ReponseError",
                request.ReponseError);

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
        // SMS GATEWAY - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteSMSGateway(
            int smsGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[SMSGateway_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@SMSGatewayID",
                smsGatewayID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET BY ID
        // ============================================================
        public async Task<GetSMSGatewayResponse?> GetSMSGatewayByID(
            int smsGatewayID,
            IFINOVAServiceUser serviceUser)
        {
            GetSMSGatewayResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[SMSGateway_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@SMSGatewayID",
                smsGatewayID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapSMSGateway(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET ALL
        // ============================================================
        public async Task<List<GetSMSGatewayResponse>> GetAllSMSGateways(
            IFINOVAServiceUser serviceUser)
        {
            List<GetSMSGatewayResponse> response =
                new List<GetSMSGatewayResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[SMSGateway_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapSMSGateway(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SMS GATEWAY - GET ACTIVE
        // ============================================================
        public async Task<GetActiveSMSGatewayResponse?>
            GetActiveSMSGateway(
                IFINOVAServiceUser serviceUser)
        {
            GetActiveSMSGatewayResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[SMSGateway_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = new GetActiveSMSGatewayResponse
                    {
                        SMSGatewayID =
                            GetInt32Value(
                                dataReader,
                                "SMSGatewayID").Value,

                        SMSGatewayName =
                            GetStringValue(
                                dataReader,
                                "SMSGatewayName"),

                        GatewayURL =
                            GetStringValue(
                                dataReader,
                                "GatewayURL"),

                        UserName =
                            GetStringValue(
                                dataReader,
                                "UserName"),

                        Password =
                            GetStringValue(
                                dataReader,
                                "Password"),

                        SenderID =
                            GetStringValue(
                                dataReader,
                                "SenderID"),

                        ReponseSuccess =
                            GetStringValue(
                                dataReader,
                                "ReponseSuccess"),

                        ReponseError =
                            GetStringValue(
                                dataReader,
                                "ReponseError")
                    };
                }
            }

            return response;
        }


        // ============================================================
        // COMMON SMS GATEWAY MAPPER
        // ============================================================
        private GetSMSGatewayResponse MapSMSGateway(
            IDataReader dataReader)
        {
            return new GetSMSGatewayResponse
            {
                SMSGatewayID =
                    GetInt32Value(
                        dataReader,
                        "SMSGatewayID").Value,

                SMSGatewayName =
                    GetStringValue(
                        dataReader,
                        "SMSGatewayName"),

                GatewayURL =
                    GetStringValue(
                        dataReader,
                        "GatewayURL"),

                UserName =
                    GetStringValue(
                        dataReader,
                        "UserName"),

                SenderID =
                    GetStringValue(
                        dataReader,
                        "SenderID"),

                ReponseSuccess =
                    GetStringValue(
                        dataReader,
                        "ReponseSuccess"),

                ReponseError =
                    GetStringValue(
                        dataReader,
                        "ReponseError"),

                Status =
                    GetInt32Value(
                        dataReader,
                        "Status").Value,

                CreatedOn =
                    GetDateValue(
                        dataReader,
                        "CreatedOn").Value,

                CreatedBy =
                    GetInt64Value(
                        dataReader,
                        "CreatedBy").Value,

                UpdatedOn =
                    GetDateValue(
                        dataReader,
                        "UpdatedOn"),

                UpdatedBy =
                    GetInt64Value(
                        dataReader,
                        "UpdatedBy")
            };
        }
        // ============================================================
        // TEMPLATE MASTER - CREATE
        // ============================================================
        public async Task<long> CreateTemplate(
            CreateTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            long templateID = 0;

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[TemplateMaster_Insert]");


            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeId",
                request.TemplateTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceType",
                request.ServiceType);

            _database.AddInParameter(
                dbCommand,
                "@TemplateName",
                request.TemplateName);

            _database.AddInParameter(
                dbCommand,
                "@TemplateMsg",
                request.TemplateMsg);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    templateID =
                        GetInt64Value(
                            dataReader,
                            "TemplateID").Value;
                }
            }

            return templateID;
        }


        // ============================================================
        // TEMPLATE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTemplate(
            UpdateTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[TemplateMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateID",
                request.TemplateID);

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeId",
                request.TemplateTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceType",
                request.ServiceType);

            _database.AddInParameter(
                dbCommand,
                "@TemplateName",
                request.TemplateName);

            _database.AddInParameter(
                dbCommand,
                "@TemplateMsg",
                request.TemplateMsg);

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
        // TEMPLATE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTemplate(
            long templateID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand("[NOTI].[TemplateMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateID",
                templateID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET BY ID
        // ============================================================
        public async Task<GetTemplateResponse?> GetTemplateByID(
            long templateID,
            IFINOVAServiceUser serviceUser)
        {
            GetTemplateResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateID",
                templateID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapTemplate(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetTemplateResponse>> GetAllTemplates(
            GetTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            List<GetTemplateResponse> response =
                new List<GetTemplateResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateMaster_GetAll]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeId",
                request.TemplateTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceType",
                request.ServiceType);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTemplate(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetTemplateResponse>> GetActiveTemplates(
            GetActiveTemplateRequest request,
            IFINOVAServiceUser serviceUser)
        {
            List<GetTemplateResponse> response =
                new List<GetTemplateResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateMaster_GetActive]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeId",
                request.TemplateTypeId);

            _database.AddInParameter(
                dbCommand,
                "@ServiceType",
                request.ServiceType);

            _database.AddInParameter(
                dbCommand,
                "@TemplateName",
                request.TemplateName);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    GetTemplateResponse row =
                        new GetTemplateResponse();

                    row.TemplateID =
                        GetInt64Value(
                            dataReader,
                            "TemplateID").Value;

                    row.TemplateTypeId =
                        GetInt32Value(
                            dataReader,
                            "TemplateTypeId");

                    row.ServiceType =
                        GetStringValue(
                            dataReader,
                            "ServiceType");

                    row.TemplateName =
                        GetStringValue(
                            dataReader,
                            "TemplateName");

                    row.TemplateMsg =
                        GetStringValue(
                            dataReader,
                            "TemplateMsg");

                    row.Status =
                        GetInt32Value(
                            dataReader,
                            "Status").Value;

                    response.Add(row);
                }
            }

            return response;
        }


        // ============================================================
        // TEMPLATE MASTER - COMMON MAPPER
        // ============================================================
        private GetTemplateResponse MapTemplate(
            System.Data.IDataReader dataReader)
        {
            return new GetTemplateResponse
            {
                TemplateID =
                    GetInt64Value(
                        dataReader,
                        "TemplateID").Value,

                TemplateTypeId =
                    GetInt32Value(
                        dataReader,
                        "TemplateTypeId"),

                ServiceType =
                    GetStringValue(
                        dataReader,
                        "ServiceType"),

                TemplateName =
                    GetStringValue(
                        dataReader,
                        "TemplateName"),

                TemplateMsg =
                    GetStringValue(
                        dataReader,
                        "TemplateMsg"),

                Status =
                    GetInt32Value(
                        dataReader,
                        "Status").Value,

                CreatedOn =
                    GetDateValue(
                        dataReader,
                        "CreatedOn").Value,

                CreatedBy =
                    GetInt64Value(
                        dataReader,
                        "CreatedBy").Value,

                UpdatedOn =
                    GetDateValue(
                        dataReader,
                        "UpdatedOn"),

                UpdatedBy =
                    GetInt64Value(
                        dataReader,
                        "UpdatedBy")
            };
        }
        // ============================================================
        // TEMPLATE TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateTemplateType(
            CreateTemplateTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int templateTypeID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeName",
                request.TemplateTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    templateTypeID =
                        GetInt32Value(
                            dataReader,
                            "TemplateTypeID").Value;
                }
            }

            return templateTypeID;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateTemplateType(
            UpdateTemplateTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeID",
                request.TemplateTypeID);

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeName",
                request.TemplateTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

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
        // TEMPLATE TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteTemplateType(
            int templateTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeID",
                templateTypeID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetTemplateTypeResponse?> GetTemplateTypeByID(
            int templateTypeID,
            IFINOVAServiceUser serviceUser)
        {
            GetTemplateTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@TemplateTypeID",
                templateTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapTemplateType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetTemplateTypeResponse>> GetAllTemplateTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetTemplateTypeResponse> response =
                new List<GetTemplateTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[TemplateTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(
                        MapTemplateType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // TEMPLATE TYPE MASTER - COMMON MAPPER
        // ============================================================
        private GetTemplateTypeResponse MapTemplateType(
            System.Data.IDataReader dataReader)
        {
            return new GetTemplateTypeResponse
            {
                TemplateTypeID =
                    GetInt32Value(
                        dataReader,
                        "TemplateTypeID").Value,

                TemplateTypeName =
                    GetStringValue(
                        dataReader,
                        "TemplateTypeName"),

                Description =
                    GetStringValue(
                        dataReader,
                        "Description"),

                Status =
                    GetInt32Value(
                        dataReader,
                        "Status").Value,

                CreatedOn =
                    GetDateValue(
                        dataReader,
                        "CreatedOn").Value,

                CreatedBy =
                    GetInt64Value(
                        dataReader,
                        "CreatedBy").Value,

                UpdatedOn =
                    GetDateValue(
                        dataReader,
                        "UpdatedOn"),

                UpdatedBy =
                    GetInt64Value(
                        dataReader,
                        "UpdatedBy")
            };
        }
        // ============================================================
        // SERVICE TYPE MASTER - CREATE
        // ============================================================
        public async Task<int> CreateServiceType(
            CreateServiceTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            int serviceTypeID = 0;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_Insert]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeName",
                request.ServiceTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

            _database.AddInParameter(
                dbCommand,
                "@Status",
                request.Status);

            _database.AddInParameter(
                dbCommand,
                "@CreatedBy",
                serviceUser.UserMasterID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    serviceTypeID =
                        GetInt32Value(
                            dataReader,
                            "ServiceTypeID").Value;
                }
            }

            return serviceTypeID;
        }


        // ============================================================
        // SERVICE TYPE MASTER - UPDATE
        // ============================================================
        public async Task<SimpleResponse> UpdateServiceType(
            UpdateServiceTypeRequest request,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_Update]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeID",
                request.ServiceTypeID);

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeName",
                request.ServiceTypeName);

            _database.AddInParameter(
                dbCommand,
                "@Description",
                request.Description);

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
        // SERVICE TYPE MASTER - DELETE
        // ============================================================
        public async Task<SimpleResponse> DeleteServiceType(
            int serviceTypeID,
            IFINOVAServiceUser serviceUser)
        {
            SimpleResponse response = new SimpleResponse();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_Delete]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeID",
                serviceTypeID);

            await _database.ExecuteNonQueryAsync(dbCommand);

            response.Result = 1;

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET BY ID
        // ============================================================
        public async Task<GetServiceTypeResponse?> GetServiceTypeByID(
            int serviceTypeID,
            IFINOVAServiceUser serviceUser)
        {
            GetServiceTypeResponse? response = null;

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_GetByID]");

            _database.AddInParameter(
                dbCommand,
                "@ServiceTypeID",
                serviceTypeID);

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                if (dataReader.Read())
                {
                    response = MapServiceType(dataReader);
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ALL
        // ============================================================
        public async Task<List<GetServiceTypeResponse>> GetAllServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetServiceTypeResponse> response =
                new List<GetServiceTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_GetAll]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    response.Add(MapServiceType(dataReader));
                }
            }

            return response;
        }


        // ============================================================
        // SERVICE TYPE MASTER - GET ACTIVE
        // ============================================================
        public async Task<List<GetActiveServiceTypeResponse>> GetActiveServiceTypes(
            IFINOVAServiceUser serviceUser)
        {
            List<GetActiveServiceTypeResponse> response =
                new List<GetActiveServiceTypeResponse>();

            var dbCommand =
                _database.GetStoredProcCommand(
                    "[NOTI].[ServiceTypeMaster_GetActive]");

            using (var dataReader =
                   await _database.ExecuteReaderAsync(dbCommand))
            {
                while (dataReader.Read())
                {
                    GetActiveServiceTypeResponse row =
                        new GetActiveServiceTypeResponse();

                    row.ServiceTypeID =
                        GetInt32Value(
                            dataReader,
                            "ServiceTypeID").Value;

                    row.ServiceTypeName =
                        GetStringValue(
                            dataReader,
                            "ServiceTypeName");

                    row.Description =
                        GetStringValue(
                            dataReader,
                            "Description");

                    response.Add(row);
                }
            }

            return response;
        }


        // ============================================================
        // COMMON MAPPER
        // ============================================================
        private GetServiceTypeResponse MapServiceType(
            System.Data.IDataReader dataReader)
        {
            GetServiceTypeResponse row =
                new GetServiceTypeResponse();

            row.ServiceTypeID =
                GetInt32Value(
                    dataReader,
                    "ServiceTypeID").Value;

            row.ServiceTypeName =
                GetStringValue(
                    dataReader,
                    "ServiceTypeName");

            row.Description =
                GetStringValue(
                    dataReader,
                    "Description");

            row.Status =
                GetInt32Value(
                    dataReader,
                    "Status").Value;

            row.CreatedOn =
                GetDateValue(
                    dataReader,
                    "CreatedOn").Value;

            row.CreatedBy =
                GetInt64Value(
                    dataReader,
                    "CreatedBy").Value;

            row.UpdatedOn =
                GetDateValue(
                    dataReader,
                    "UpdatedOn");

            row.UpdatedBy =
                GetInt64Value(
                    dataReader,
                    "UpdatedBy");

            return row;
        }
    }
}