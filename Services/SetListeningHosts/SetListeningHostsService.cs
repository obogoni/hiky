using System;
using System.Text;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Logging;

namespace Hiky.Services.SetListeningHosts;

public class SetListeningHostsService(IHttpClientFactory httpClientFactory, ILogger<SetListeningHostsService> logger) : ServiceBase(httpClientFactory), ISetListeningHostsService
{
    public async Task SetListeningHostsAsync(SetListeningHostsRequest request)
    {
        Guard.Against.Null(request, nameof(request));

        var builder = new StringBuilder();

        builder.AppendLine("<HttpHostNotificationList>");

        foreach (var host in request.ListeningHosts)
        {
            builder.AppendLine($@"
                <HttpHostNotification>
                    <id>{host.Id}</id>
                    <url>{host.Url}</url>
                    <protocolType>{host.ProtocolType}</protocolType>
                    <parameterFormatType>{host.ProtocolType}</parameterFormatType>
                    <addressingFormatType>{host.AddressingFormatType}</addressingFormatType>
                    <ipAddress>{host.IpAddress}</ipAddress>
                    <portNo>{host.PorNo}</portNo>
                    <httpAuthenticationMethod>{host.HttpAuthenticationMethod}</httpAuthenticationMethod>
                </HttpHostNotification>");
        }

        builder.AppendLine("</HttpHostNotificationList>");

        using var content = new StringContent(
            builder.ToString(),
            Encoding.UTF8,
            "application/xml");

        var response = await HttpClient.PutAsync(Routes.NotificationHttpHosts, content);

        response.EnsureSuccessStatusCode();

        logger.LogInformation("Listening hosts set successfully.");
    }
}
