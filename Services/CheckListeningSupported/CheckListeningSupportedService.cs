using System;
using Microsoft.Extensions.Logging;

namespace Hiky.Services.CheckListeningSupportedService;

public class CheckListeningSupportedService(IHttpClientFactory httpClientFactory, ILogger<CheckListeningSupportedService> logger) : ServiceBase(httpClientFactory), ICheckListeningSupportedService
{
    public async Task<bool> IsListeningSupportedAsync()
    {
        var response = await HttpClient.GetAsync(Routes.NotificationHttpHostsCapabilities);

        var xmlDocument = new System.Xml.XmlDocument();

        xmlDocument.LoadXml(await response.Content.ReadAsStringAsync());

        var elements = xmlDocument.GetElementsByTagName("HttpHostNotificationCap");
        var supportListening = elements.Count > 0 && !string.IsNullOrEmpty(elements[0]?.InnerXml);

        if (supportListening)
        {
            logger.LogInformation("The device supports listening for events.");
        }
        else
        {
            logger.LogInformation("The device does not support listening for events.");
        }

        return supportListening;
    }
}
