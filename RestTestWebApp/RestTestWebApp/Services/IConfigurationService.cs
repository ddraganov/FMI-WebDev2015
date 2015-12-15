using System;
namespace RestTestWebApp.Services
{
    public interface IConfigurationService
    {
        string GetValue(string key);
    }
}
