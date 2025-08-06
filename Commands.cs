using Cocona;
using Hiky.Services.CheckListeningSupportedService;
using Hiky.Services.DeviceConfiguration;
using Hiky.Services.EnableRemoteCheck;
using Hiky.Services.GetAccessControlCapabilities;
using Hiky.Services.GetAccessControlConfiguration;
using Hiky.Services.GetListeningHost;
using Hiky.Services.GetListeningHosts;
using Hiky.Services.SetListeningHosts;
using Microsoft.Extensions.DependencyInjection;

namespace Hiky;

public static class Extensions
{

    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICheckListeningSupportedService, CheckListeningSupportedService>();
        services.AddTransient<IGetListeningHostService, GetListeningHostService>();
        services.AddTransient<IGetListeningHostsService, GetListeningHostsService>();
        services.AddTransient<ISetListeningHostsService, SetListeningHostsService>();
        services.AddTransient<IDeviceConfigurationService, DeviceConfigurationService>();
        services.AddTransient<IGetAccessControlCapabilitiesService, GetAccessControlCapabilitiesService>();
        services.AddTransient<IGetAccessControlConfigurationService, GetAccessControlConfigurationService>();
        services.AddTransient<IEnableRemoteCheckService, EnableRemoteCheckService>();
        services.AddTransient<EventListener>();
    }

    public static void AddCheckDeviceSupportsListeningCommand(this CoconaApp app)
    {
        app.AddCommand("check-support", async ([FromService] ICheckListeningSupportedService service) =>
        {
            await service.IsListeningSupportedAsync();
        })
        .WithDescription("Check if the device supports listening for events");
    }

    public static void AddGetListeningHostsCommand(this CoconaApp app)
    {
        app.AddCommand("get-hosts", async ([FromService] IGetListeningHostsService service) =>
        {
            var response = await service.GetListeningHostsAsync();

            foreach (var host in response)
            {
                Console.WriteLine(host);
            }
        })
        .WithDescription("Get all configured listening hosts on the device");
    }

    public static void AddGetListeningHostCommand(this CoconaApp app)
    {
        app.AddCommand("get-host", async ([FromService] IGetListeningHostService service, [Argument] int id) =>
        {
            var response = await service.GetListeningHostAsync(id);

            Console.WriteLine(response);
        })
        .WithDescription("Get details of a specific listening host by ID");
    }

    public static void AddSetListeningHostsCommand(this CoconaApp app)
    {
        app.AddCommand("set-hosts", async (
            [FromService] ISetListeningHostsService service,
            [Option('i')] string ipAddress,
            [Option('p')] int portNo,
            [Option('u')] string url,
            [Option] string id) =>
        {

            var host = new ListeningHost(id, ipAddress, portNo, url);
            var request = new SetListeningHostsRequest([host]);

            await service.SetListeningHostsAsync(request);

            Console.WriteLine($"Listening host set to: {host}");
        })
        .WithDescription("Configure a listening host on the device");
    }

    public static void AddListenCommand(this CoconaApp app)
    {
        app.AddCommand("listen", async ([FromService] EventListener listener, [FromService] CancellationToken ct, [Argument] int port) =>
        {
            await listener.StartListeningAsync(port, ct);
        })
        .WithDescription("Start listening for events on the specified port");
    }

    public static void AddDeviceConfigurationCommand(this CoconaApp app)
    {
        app.AddCommand("configure-device", async ([FromService] IDeviceConfigurationService configService,
            [Option('i')] string? ipAddress = null,
            [Option('p')] int? port = null,
            [Option('u')] string? username = null,
            [Option('w')] string? password = null,
            [Option('s')] bool show = false) =>
        {
            var config = await configService.GetAsync();

            if (show)
            {
                Console.WriteLine("Current Device Configuration:");
                Console.WriteLine($"IP Address: {config.IpAddress}");
                Console.WriteLine($"Port: {config.Port}");
                Console.WriteLine($"Username: {config.Username}");
                Console.WriteLine($"Password: ****"); // Don't show the actual password
            }

            bool changed = false;

            if (!string.IsNullOrEmpty(ipAddress))
            {
                config.IpAddress = ipAddress;
                changed = true;
            }

            if (port.HasValue)
            {
                config.Port = port.Value;
                changed = true;
            }

            if (!string.IsNullOrEmpty(username))
            {
                config.Username = username;
                changed = true;
            }

            if (!string.IsNullOrEmpty(password))
            {
                config.Password = password;
                changed = true;
            }

            if (changed)
            {
                await configService.SaveAsync(config);

                if (show)
                {
                    Console.WriteLine();
                    Console.WriteLine("New Device Configuration:");
                    Console.WriteLine($"IP Address: {config.IpAddress}");
                    Console.WriteLine($"Port: {config.Port}");
                    Console.WriteLine($"Username: {config.Username}");
                    Console.WriteLine($"Password: ****"); // Don't show the actual password
                }

                Console.WriteLine("Configuration saved successfully.");
            }
            else if (!show)
            {
                Console.WriteLine("No changes made. Use -s to show current configuration or provide parameters to update.");
            }
        })
        .WithDescription("Configure device connection settings");
    }

    public static void AddGetAccessControlCapabilitiesCommand(this CoconaApp app)
    {
        app.AddCommand("get-ac-cap", async ([FromService] IGetAccessControlCapabilitiesService service) =>
        {
            var response = await service.GetAccessControlCapabilitiesAsync();

            Console.WriteLine(response);
        })
        .WithDescription("Get details of a specific listening host by ID");
    }

    public static void AddGetAccessControlConfigurationCommand(this CoconaApp app)
    {
        app.AddCommand("get-ac-config", async ([FromService] IGetAccessControlConfigurationService service) =>
        {
            var response = await service.GetAccessControlConfigurationAsync();

            Console.WriteLine(response);
        })
        .WithDescription("Get access control configuration from the device");
    }
    
     /// <summary>
    /// Adds the enable-remote-check command to the Cocona app
    /// </summary>
    /// <param name="app">The Cocona app</param>
    /// <returns>The Cocona app builder</returns>
    public static CoconaApp AddEnableRemoteCheckCommand(this CoconaApp app)
    {
        app.AddCommand("enable-remote-check", async ([FromService] IEnableRemoteCheckService service, 
            [Option('e', Description = "Enable (true) or disable (false) the remote check")] bool enable) =>
        {
            Console.WriteLine($"{(enable ? "Enabling" : "Disabling")} remote check...");
            await service.EnableRemoteCheckAsync(enable);
            Console.WriteLine($"Remote check {(enable ? "enabled" : "disabled")} successfully.");
        })
        .WithDescription("Enable or disable remote check functionality on the device");
        
        return app;
    }
}
