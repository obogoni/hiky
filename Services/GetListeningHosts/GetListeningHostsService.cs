using System;
using Microsoft.Extensions.Logging;

namespace Hiky.Services.GetListeningHosts;

public class GetListeningHostsService(IHttpClientFactory httpClientFactory, ILogger<GetListeningHostsService> logger) : ServiceBase(httpClientFactory), IGetListeningHostsService
{
    public async Task<IEnumerable<string>> GetListeningHostsAsync()
    {
        var response = await HttpClient.GetAsync(Routes.NotificationHttpHosts);

        response.EnsureSuccessStatusCode();

        logger.LogInformation("Listening hosts retrieved successfully.");
        
        var content = await response.Content.ReadAsStringAsync();

        logger.LogInformation("Response content: {Content}", content);

        var xmlDocument = new System.Xml.XmlDocument();

        xmlDocument.LoadXml(content);

        var elements = xmlDocument.GetElementsByTagName("HttpHostNotification");
        var listeningHosts = new List<string>();

        foreach (System.Xml.XmlElement element in elements)
        {
            listeningHosts.Add(element.OuterXml);
        }

        return listeningHosts;
    }
}
