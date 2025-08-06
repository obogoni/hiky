using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hiky.Services.DeviceConfiguration;

public class DeviceConfigurationService : IDeviceConfigurationService
{
    private const string ConfigFileName = "device_config.json";
    private string ConfigFilePath => Path.Combine(GetAppDataFolder(), ConfigFileName);

    public async Task<DeviceConfiguration> GetAsync()
    {
        if (!File.Exists(ConfigFilePath))
        {
            return new DeviceConfiguration
            {
                IpAddress = "172.30.0.226",
                Port = 80,
                Username = "admin",
                Password = "12345678acb"
            };
        }

        var json = await File.ReadAllTextAsync(ConfigFilePath);
        var config = JsonSerializer.Deserialize<DeviceConfiguration>(json);
        return config ?? new DeviceConfiguration();
    }

    public async Task SaveAsync(DeviceConfiguration configuration)
    {
        EnsureAppDataFolderExists();
        var json = JsonSerializer.Serialize(configuration, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(ConfigFilePath, json);
    }

    private string GetAppDataFolder()
    {
        var appDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
            "Hiky"
        );
        return appDataFolder;
    }

    private void EnsureAppDataFolderExists()
    {
        var folder = GetAppDataFolder();
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
    }
}
