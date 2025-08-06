using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;

namespace Hiky.Services.GetAccessControlConfiguration;

/// <summary>
/// Implementation of the service to get access control configuration from the device.
/// </summary>
public class GetAccessControlConfigurationService(IHttpClientFactory httpClientFactory, ILogger<GetAccessControlConfigurationService> logger) : ServiceBase(httpClientFactory), IGetAccessControlConfigurationService
{

    /// <inheritdoc/>
    public async Task<GetAccessControlConfigurationResponse> GetAccessControlConfigurationAsync()
    {
        var client = httpClientFactory.CreateClient(Constants.DefaultHttpClient);
        
        var response = await client.GetAsync(Routes.AccessControlConfiguration);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        Guard.Against.NullOrEmpty(content, nameof(content), "Response content cannot be null or empty.");

        logger.LogInformation("Received access control configuration response: {Content}", content);

        var result = JsonSerializer.Deserialize<GetAccessControlConfigurationResponse>(content, options);
        
        return result!;
    }
}
