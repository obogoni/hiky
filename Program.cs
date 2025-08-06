using Cocona;
using Hiky;
using Hiky.Services.DeviceConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net;

var builder = CoconaApp.CreateBuilder(args);

// Register the DeviceConfigurationService
builder.Services.AddTransient<IDeviceConfigurationService, DeviceConfigurationService>();

// Configure HttpClient with settings from configuration - restructured to avoid multiple initializations
builder.Services.AddHttpClient(Constants.DefaultHttpClient)
    .ConfigureHttpClient((sp, client) =>
    {
        var configService = sp.GetRequiredService<IDeviceConfigurationService>();
        var config = configService.GetAsync().Result;

        var url = string.Format("http://{0}:{1}/", config.IpAddress, config.Port);
        client.BaseAddress = new Uri(url);
        
        Console.WriteLine("HttpClient created with base address: " + client.BaseAddress);
    })
    .ConfigurePrimaryHttpMessageHandler(sp =>
    {
        var configService = sp.GetRequiredService<IDeviceConfigurationService>();
        var config = configService.GetAsync().Result;

        return new HttpClientHandler
        {
            PreAuthenticate = true,
            Credentials = new NetworkCredential(config.Username, config.Password)
        }; 
    });

builder.Logging.AddConsole();

builder.Services.AddServices();

var app = builder.Build();

app.AddDeviceConfigurationCommand();
app.AddCheckDeviceSupportsListeningCommand();
app.AddGetListeningHostsCommand();
app.AddGetListeningHostCommand();
app.AddGetAccessControlCapabilitiesCommand();
app.AddGetAccessControlConfigurationCommand();
app.AddSetListeningHostsCommand();
app.AddListenCommand();
app.AddEnableRemoteCheckCommand();

app.Run();





