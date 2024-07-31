using Microsoft.Extensions.Configuration;

namespace ContactsManagement.Infrastructure.Settings
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration) => 
            _configuration = configuration;

        public string ConnectionStrings => _configuration.GetConnectionString("FiapContact") ?? string.Empty;
    }
}
