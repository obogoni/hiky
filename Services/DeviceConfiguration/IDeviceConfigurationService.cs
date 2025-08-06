namespace Hiky.Services.DeviceConfiguration;

public interface IDeviceConfigurationService
{
    Task<DeviceConfiguration> GetAsync();
    Task SaveAsync(DeviceConfiguration configuration);
}
