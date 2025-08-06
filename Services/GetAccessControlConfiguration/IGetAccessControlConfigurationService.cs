using System.Threading.Tasks;

namespace Hiky.Services.GetAccessControlConfiguration;

/// <summary>
/// Interface for a service that retrieves access control configuration from the device.
/// </summary>
public interface IGetAccessControlConfigurationService
{
    /// <summary>
    /// Gets the access control configuration from the device.
    /// </summary>
    /// <returns>The access control configuration.</returns>
    Task<GetAccessControlConfigurationResponse> GetAccessControlConfigurationAsync();
}
