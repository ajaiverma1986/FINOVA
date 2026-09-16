using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.WebApi;
using FINOVA.API.Common;
using Microsoft.Extensions.FileProviders;
using System.Text;
using System.Text.Json.Serialization;
using FINOVA.Configuration;
using FINOVA.Logging;
using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Common;
using FINOVA.Commonlib.Cache;
using FINOVA.DataModel.DTO.Request;
using FINOVA.DataModel.Entities.Application;
using FINOVA.DataModel.Entities.Authorization;
using FINOVA.Provider;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi;


namespace FINOVA.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            FINOVAApplicationConfiguration.Instance.Initialize(builder.Configuration);


            System.Net.ServicePointManager.DefaultConnectionLimit = 10000;

            var configuration = builder.Configuration;

            var authenticationProvider = new AuthenticationProvider();



            builder.Services
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.Converters.Add(
                        new JsonStringEnumConverter());
                });



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });




            builder.Services.AddSingleton<FINOVExceptionFilterService>();

            builder.Services.AddSingleton<ILoggingService, LoggingService>();

            builder.Services.AddScoped<IFINOVAServiceUser, FINOVAServiceUser>();

            builder.Services.AddMemoryCache();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(c =>
            {
                c.OperationFilter<SwaggerHeaderOperationFilter>();
            });



            Audit.Core.Configuration.DataProvider = new SqlDataProvider
            {
                ConnectionString =
                    FINOVAApplicationConfiguration.Instance.FIADB,

                Schema = "dbo",

                TableName = "Event",

                IdColumnName = "EventId",

                JsonColumnName = "Data",

                LastUpdatedDateColumnName = "LastUpdatedDate"
            };


            Audit.Core.Configuration.AddCustomAction(
                ActionType.OnEventSaving,
                scope =>
                {
                    if (scope?.Event == null)
                        return;

                    if (scope.Event is AuditEventWebApi auditEvent)
                    {
                        AuditApiAction mvc =
                            auditEvent.GetWebApiAuditAction();

                        if (mvc?.ActionParameters == null)
                            return;

                        if (mvc.ActionParameters.ContainsKey("userLoginRequest"))
                        {
                            if (mvc.ActionParameters["userLoginRequest"] is UserLoginRequest userLoginRequest)
                            {
                                userLoginRequest.Password = "***NOT-LOGGED***";
                            }
                        }
                    }
                });




            var app = builder.Build();
            Console.WriteLine("1. Application built");
            var memoryCache = app.Services.GetRequiredService<IMemoryCache>();
            Console.WriteLine("2. IMemoryCache resolved");
            MemoryCachingService.Initialize(memoryCache);
            Console.WriteLine("3. MemoryCachingService initialized");

            app.UseSwagger();
            app.UseSwaggerUI();

            Console.WriteLine("4. Swagger configured");

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            app.UseDefaultFiles();

            app.UseStaticFiles();

            Console.WriteLine("5. Static files configured");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "images")),

                RequestPath = "/Images"
            });



            app.UseRouting();


            Console.WriteLine("6. Routing configured");

            app.UseCors("AllowAll");

            Console.WriteLine("7. CORS configured");

            app.Use(async (context, next) =>
            {
                var serviceUser =
                    context.RequestServices
                        .GetRequiredService<IFINOVAServiceUser>();




                serviceUser.ApiToken =
                    context.Request.Headers["apitoken"];

                serviceUser.UserToken =
                    context.Request.Headers["usertoken"];



                if (string.IsNullOrEmpty(serviceUser.ApiToken))
                {
                    serviceUser.ApiToken =
                        context.Request.Query["apitoken"];
                }

                if (string.IsNullOrEmpty(serviceUser.UserToken))
                {
                    serviceUser.UserToken =
                        context.Request.Query["usertoken"];
                }



                long userMasterId = 0;

                int userId = 0;

                int userTypeId = 0;


                ApplicationUserMappingResponse? applicationUserDetails = null;



                if (!string.IsNullOrEmpty(serviceUser.UserToken))
                {
                    applicationUserDetails =
                        await MemoryCachingService
                            .Get<ApplicationUserMappingResponse>(
                                string.Format(
                                    CacheKeys.APPLICATION_USER_DETAIL,
                                    serviceUser.UserToken));
                }




                if (!string.IsNullOrEmpty(serviceUser.UserToken))
                {
                    userMasterId =
                        await MemoryCachingService.Get<int>(
                            string.Format(
                                CacheKeys.USERMASTER_ID,
                                serviceUser.UserToken));

                    userId =
                        await MemoryCachingService.Get<int>(
                            string.Format(
                                CacheKeys.USER_ID,
                                serviceUser.UserToken));
                }



                if (applicationUserDetails == null ||
                    (!string.IsNullOrEmpty(serviceUser.UserToken)
                     && userMasterId == 0))
                {
                    applicationUserDetails =
                        await authenticationProvider
                            .GetApplicationAndUserDetails(serviceUser);


                    await MemoryCachingService.Put(
                        string.Format(
                            CacheKeys.APPLICATION_USER_DETAIL,
                            serviceUser.UserToken),
                        applicationUserDetails);


                    if (applicationUserDetails != null &&
                        applicationUserDetails.UserMasterID.HasValue)
                    {
                        await MemoryCachingService.Put(
                            string.Format(
                                CacheKeys.USERMASTER_ID,
                                serviceUser.UserToken),
                            applicationUserDetails.UserMasterID);


                        userMasterId =
                            applicationUserDetails.UserMasterID.Value;


                        await MemoryCachingService.Put(
                            string.Format(
                                CacheKeys.USER_ID,
                                serviceUser.UserToken),
                            applicationUserDetails.UserID);


                        if (applicationUserDetails.UserID.HasValue)
                        {
                            userId =
                                applicationUserDetails.UserID.Value;
                        }


                        await MemoryCachingService.Put(
                            string.Format(
                                CacheKeys.USER_Type,
                                serviceUser.UserToken),
                            applicationUserDetails.UserTypeID);


                        if (applicationUserDetails.UserTypeID.HasValue)
                        {
                            userTypeId =
                                applicationUserDetails.UserTypeID.Value;
                        }
                    }
                }



                if (applicationUserDetails != null)
                {
                    serviceUser.ApplicationID =
                        applicationUserDetails.ApplicationId;

                    serviceUser.ApplicationName =
                        applicationUserDetails.ApplicationName;

                    serviceUser.AppType =
                        applicationUserDetails.AppType;

                    serviceUser.UserMasterID =
                        userMasterId;

                    serviceUser.OrganizationID =
                        applicationUserDetails.OrganizationID;

                    serviceUser.WorkOrganizationID =
                        applicationUserDetails.OrganizationID;

                    serviceUser.UserID =
                        applicationUserDetails.UserID;

                    serviceUser.UserTypeId =
                        applicationUserDetails.UserTypeID;




                    serviceUser.RequestUrl =
                        string.Concat(
                            context.Request.Scheme,
                            "://",
                            context.Request.Host,
                            context.Request.PathBase,
                            context.Request.Path,
                            context.Request.QueryString);




                    serviceUser.ReferrerUrl = context.Request.Headers["Referer"];

                    var headers = new StringBuilder();

                    foreach (var header in context.Request.Headers)
                    {
                        headers.AppendLine(
                            $"{header.Key}:{header.Value}");
                    }

                    serviceUser.Headers = headers.ToString();

                    serviceUser.IPAddress = context.Connection.RemoteIpAddress?.ToString();

                    if (string.IsNullOrEmpty(serviceUser.IPAddress))
                    {
                        serviceUser.IPAddress = context.Request.Headers["X-Forwarded-For"];
                    }


                    if (!string.IsNullOrEmpty(
                        serviceUser.IPAddress))
                    {
                        serviceUser.IPAddress =
                            serviceUser.IPAddress
                                .Split(',')[0]
                                .Split(';')[0]
                                .Trim();
                        if (serviceUser.IPAddress.Contains(".") &&
                            serviceUser.IPAddress.Contains(":"))
                        {
                            serviceUser.IPAddress =
                                serviceUser.IPAddress
                                    .Substring(
                                        0,
                                        serviceUser.IPAddress
                                            .LastIndexOf(':'));
                        }
                    }

                    serviceUser.ClientIPAddress = context.Request.Headers["ClientIPAddress"];
                }


                if (applicationUserDetails != null &&
                    applicationUserDetails.UserMasterID > 0)
                {
                    if (serviceUser.UserMasterID == 0)
                    {
                        serviceUser.UserMasterID =
                            applicationUserDetails.UserMasterID;
                    }


                    if (serviceUser.UserMasterID > 0 &&
                        !string.IsNullOrEmpty(
                            serviceUser.UserToken))
                    {
                        var userPermissions =
                            await MemoryCachingService
                                .Get<List<UserApplicationAccessPermissions>>(
                                    string.Format(
                                        CacheKeys.USER_ROLES_API,
                                        serviceUser.ApplicationID,
                                        serviceUser.UserToken));


                        if (userPermissions == null ||
                            userPermissions.Count == 0)
                        {
                            var permissions =
                                await authenticationProvider
                                    .GetUserAccessPermissions(
                                        serviceUser);

                            await MemoryCachingService.Put(
                                string.Format(
                                    CacheKeys.USER_ROLES_API,
                                    serviceUser.ApplicationID,
                                    serviceUser.UserToken),
                                permissions);
                        }
                    }
                }


                await next();
            });

            app.MapControllers();

            Console.WriteLine("9. Controllers mapped");

            Console.WriteLine("10. Starting application...");

            await app.RunAsync();
        }
    }
}

