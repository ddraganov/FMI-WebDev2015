using Microsoft.WindowsAzure;

namespace RestTestWebApp.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetValue(string key)
        {
            return CloudConfigurationManager.GetSetting(key);
        }
    }
}