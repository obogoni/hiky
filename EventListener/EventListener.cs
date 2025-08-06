using System;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Net.Http;
using Hiky;

namespace Hiky;

public class EventListener(ILogger<EventListener> logger, IHttpClientFactory httpClientFactory)
{
    public async Task StartListeningAsync(int port, CancellationToken ct)
    {
        var listener = new HttpListener();
        listener.Prefixes.Add($"http://*:{port}/");
        listener.Start();
        logger.LogInformation("HTTP Listener started on port {Port}", port);

        try
        {
            while (!ct.IsCancellationRequested)
            {
                var context = await listener.GetContextAsync().WaitAsync(ct);
                var request = context.Request;

                logger.LogInformation("Received request: {Method} {Url}", request.HttpMethod, request.Url);

                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    var body = await reader.ReadToEndAsync();
                    string? json = null;
                    // Try to extract JSON from multipart/form-data
                    var match = Regex.Match(body, "(?s)\\{.*\\}");
                    if (match.Success)
                    {
                        json = match.Value;
                    }
                    else
                    {
                        json = body;
                    }

                    logger.LogInformation("Request Body: {Body}", json);
                    
                    try
                    {
                        var evt = JsonSerializer.Deserialize<AccessControllerEvent>(json);

                        logger.LogInformation("Deserialized AccessControllerEvent: {0}", evt);

                        if (long.TryParse(evt?.Details?.CardNo, out var cardNo))
                        {
                            var littleEndianStr = cardNo.ToString("X");

                            logger.LogInformation("UID little-endian: {CardNo}", littleEndianStr);  
                           
                            byte[] bytes = Convert.FromHexString(littleEndianStr);

                            Array.Reverse(bytes);

                            string bigEndianHex = Convert.ToHexString(bytes);

                            logger.LogInformation("UID: {CardNo}", bigEndianHex.ToLower());
                        }
                        else
                        {
                            logger.LogWarning("UID parsing failed: {CardNo}", evt?.Details?.CardNo);
                        }

                        int? majorEventType = evt?.Details?.MajorEventType;
                        int? subEventType = evt?.Details?.SubEventType;

                        try
                        {
                            if (majorEventType.HasValue) Console.WriteLine(
                            "Major Event Type: {0} - {1}",
                            majorEventType.Value,
                            EventTypes.EventDescriptions[majorEventType.Value]);

                        if (subEventType.HasValue) Console.WriteLine(
                            "Sub Event Type: {0} - {1}",
                            subEventType.Value,
                            EventTypes.EventDescriptions[subEventType.Value]);
                        }
                        catch { }
                        
                        var hex = Convert.ToInt64(evt.Details.CardNo);

                        if (evt?.Details?.RemoteCheck == true)
                        {
                            var responseObj = new
                            {
                                RemoteCheck = new
                                {
                                    serialNo = evt.Details.SerialNo,
                                    checkResult = "success",
                                    info = "Seja bem vindo!"
                                }
                            };
                            var responseJson = JsonSerializer.Serialize(responseObj);

                            logger.LogInformation("Forwarding remoteCheck to device: {Payload}", responseJson);

                            var client = httpClientFactory.CreateClient(Constants.DefaultHttpClient);
                            var httpContent = new StringContent(responseJson, System.Text.Encoding.UTF8, "application/json");
                            var deviceResponse = await client.PutAsync(Routes.RemoteCheck, httpContent, ct);
                            var deviceResponseBody = await deviceResponse.Content.ReadAsStringAsync(ct);

                            logger.LogInformation("Device responded: {Status} {Body}", deviceResponse.StatusCode, deviceResponseBody);

                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = (int)deviceResponse.StatusCode;
                            await context.Response.OutputStream.WriteAsync(System.Text.Encoding.UTF8.GetBytes(deviceResponseBody), ct);
                            context.Response.Close();
                            continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Failed to deserialize AccessControllerEvent from request body: {Body}", body);
                    }
                }
                // Default response
                context.Response.StatusCode = 200;
                await context.Response.OutputStream.WriteAsync(
                    System.Text.Encoding.UTF8.GetBytes("OK"), ct);
                context.Response.Close();
            }
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Listener cancelled.");
        }
        finally
        {
            listener.Stop();
            listener.Close();
            logger.LogInformation("HTTP Listener stopped.");
        }
    }
}
