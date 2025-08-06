using System;
using Microsoft.Extensions.Logging;

namespace Hiky.Services.GetListeningHost;

public class GetListeningHostService(IHttpClientFactory httpClientFactory, ILogger<GetListeningHostService> logger) : ServiceBase(httpClientFactory), IGetListeningHostService
{
    public async Task<string> GetListeningHostAsync(int id)
    {
        var response = await HttpClient.GetAsync(string.Format(Routes.NotificationHttpHost, id));

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
