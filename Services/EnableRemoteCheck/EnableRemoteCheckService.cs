using Microsoft.Extensions.Logging;

namespace Hiky.Services.EnableRemoteCheck;

public class EnableRemoteCheckService(IHttpClientFactory httpClientFactory, ILogger<EnableRemoteCheckService> logger) : ServiceBase(httpClientFactory), IEnableRemoteCheckService
{
    public async Task EnableRemoteCheckAsync(bool enable)
    {
        var client = httpClientFactory.CreateClient(Constants.DefaultHttpClient);

        var data = @"
        {{
            ""AcsCfg"": {{
                ""remoteCheckSet"": 0,
                ""remoteCheckDoorEnabled"": {0},
                ""needDeviceCheck"": false,
                ""checkChannelType"": ""ISAPIListen""
            }}
        }}";

        data = string.Format(data, enable ? "true" : "false");

        logger.LogInformation("Sending request to enable remote check: {0}", data);

        var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        
        var response = await client.PutAsync(Routes.AccessControlConfiguration, content);
        response.EnsureSuccessStatusCode();

        if (enable)
        {
            logger.LogInformation("Remote check enabled.");
        }
        else
        {
            logger.LogInformation("Remote check disabled.");
         }
    }
}