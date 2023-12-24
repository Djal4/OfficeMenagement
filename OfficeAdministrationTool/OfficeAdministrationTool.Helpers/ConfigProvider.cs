using Microsoft.Extensions.Configuration;

namespace OfficeAdministrationTool.Helpers
{
    public static class ConfigProvider
    {
        public static string ConnectionString { get; private set; } = string.Empty;

        public static void SetupConfiguration(this ConfigurationManager configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

    }
}