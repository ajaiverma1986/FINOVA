using FINOVA.DataModel.Interfaces;
using FINOVA.DataModel.Shared;
using FINOVA.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Text;

namespace FINOVA.API.Common
{
    public class FINOVExceptionFilterService : ExceptionFilterAttribute
    {
        private readonly ILoggingService _loggingService;

        public FINOVExceptionFilterService(
            ILoggingService loggingService)
        {
            _loggingService = loggingService;
        }

        public override void OnException(ExceptionContext context)
        {
            var httpContext = context.HttpContext;


            var serviceUser =
                httpContext.RequestServices
                    .GetService<IFINOVAServiceUser>();



            var log = new Log();

            if (serviceUser != null)
            {
                log.ApiToken = serviceUser.ApiToken;
                log.UserToken = serviceUser.UserToken;
            }

            log.IpAddress =
                GetClientIpAddress(httpContext);

            log.Url =
                GetRequestUrl(httpContext.Request);

            log.ReferrerUrl =
                GetRequestReferrerUrl(httpContext.Request);

            log.Headers =
                GetRequestHeaders(httpContext.Request);


            _loggingService.LogError(
                context.Exception,
                log,
                this);



            var response = new BaseResponse();

            response.SetError(
                ErrorCodes.SERVER_ERROR);


            context.Result =
                new ObjectResult(response)
                {
                    StatusCode =
                        StatusCodes.Status500InternalServerError
                };


            context.HttpContext.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            context.ExceptionHandled = true;
        }


        private string GetClientIpAddress(
            HttpContext httpContext)
        {
            var ipAddress =
                httpContext.Connection
                    .RemoteIpAddress?
                    .ToString();


            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                return ipAddress;
            }


            var forwardedFor =
                httpContext.Request.Headers[
                    "X-Forwarded-For"]
                    .FirstOrDefault();


            if (!string.IsNullOrWhiteSpace(forwardedFor))
            {
                ipAddress =
                    forwardedFor
                        .Split(',')
                        .FirstOrDefault()?
                        .Trim();


                if (!string.IsNullOrWhiteSpace(ipAddress))
                {
                    return ipAddress;
                }
            }


            return string.Empty;
        }


        private string GetRequestUrl(
            HttpRequest request)
        {
            return string.Concat(
                request.Scheme,
                "://",
                request.Host.ToUriComponent(),
                request.PathBase.ToUriComponent(),
                request.Path.ToUriComponent(),
                request.QueryString.ToUriComponent());
        }

        private string GetRequestReferrerUrl(
            HttpRequest request)
        {
            return request.Headers["Referer"]
                .FirstOrDefault()
                ?? string.Empty;
        }

        private string GetRequestHeaders(
            HttpRequest request)
        {
            var headers = new StringBuilder();

            foreach (var header in request.Headers)
            {
                headers.AppendLine(
                    $"{header.Key}:{header.Value}");
            }

            return headers.ToString();
        }
    }
}