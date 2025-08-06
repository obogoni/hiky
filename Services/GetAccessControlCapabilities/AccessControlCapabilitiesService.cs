using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.GuardClauses;
using Hiky.Services;
using Hiky.Services.GetAccessControlCapabilities;
using Microsoft.Extensions.Logging;

public class GetAccessControlCapabilitiesService(IHttpClientFactory httpClientFactory, ILogger<GetAccessControlCapabilitiesService> logger) : ServiceBase(httpClientFactory), IGetAccessControlCapabilitiesService
{
    public async Task<GetAccessControlCapabilitiesResponse> GetAccessControlCapabilitiesAsync()
    {
        var response = await HttpClient.GetAsync(Routes.AccessControlCapabilities);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        Guard.Against.NullOrEmpty(responseContent, nameof(responseContent), "Response content cannot be null or empty.");   

        logger.LogInformation("Received access control capabilities response: {ResponseContent}", responseContent);

        return JsonSerializer.Deserialize<GetAccessControlCapabilitiesResponse>(responseContent!, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        })!;
    }
}