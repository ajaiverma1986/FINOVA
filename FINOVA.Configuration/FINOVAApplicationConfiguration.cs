using Microsoft.Extensions.Configuration;

namespace FINOVA.Configuration
{
    public sealed class FINOVAApplicationConfiguration
    {
        private static readonly Lazy<FINOVAApplicationConfiguration> _instance =
            new(() => new FINOVAApplicationConfiguration());

        private IConfiguration? _configuration;

        private FINOVAApplicationConfiguration()
        {
        }

        public static FINOVAApplicationConfiguration Instance =>
            _instance.Value;

        public void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration Configuration =>
            _configuration
            ?? throw new InvalidOperationException(
                "FINOVAApplicationConfiguration has not been initialized.");

        public string? FIADB =>
            Configuration.GetConnectionString("FINOVADB");

        public string? AuditingDB =>
            Configuration.GetConnectionString("AuditingDB");

        public string? LoggingDB =>
            Configuration.GetConnectionString("LoggingDB");

        public string? FileDownloadPath =>
            Configuration["FileDownloadPath"];

        public string? FIAAPIUrl =>
            Configuration["APIUrl"];

        public string? FileUploadPath =>
            Configuration["FileUploadPath"];

        public string? APIToken =>
            Configuration["APIToken"];

        public string? certisslpass =>
            Configuration["CertSslPass"];

        public string? certisslName =>
            Configuration["CertSslName"];

        private string GetParameterValue(string parameterName)
        {
            return Configuration[parameterName] ?? string.Empty;
        }
    }
}