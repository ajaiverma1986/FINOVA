using Swashbuckle.AspNetCore.SwaggerGen;

namespace FINOVA.API.Common
{
    public class SwaggerHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Microsoft.OpenApi.OpenApiOperation operation,OperationFilterContext context)
        {
            operation.Parameters.Add(
                new Microsoft.OpenApi.OpenApiParameter
                {
                    Name = "apitoken",
                    In = Microsoft.OpenApi.ParameterLocation.Header,
                    Required = false,
                    Description = "API Token"
                });

            operation.Parameters.Add(
                new Microsoft.OpenApi.OpenApiParameter
                {
                    Name = "usertoken",
                    In = Microsoft.OpenApi.ParameterLocation.Header,
                    Required = false,
                    Description = "User Token"
                });
        }
    }
}