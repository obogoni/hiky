# Hiky CLI

Hiky is a simple CLI tool that provides commands for enabling remote authentication and listening for access controller events from Hikvision face recognition terminals.

## Prerequisites

- .NET 9.0 Runtime
- A Hikvision face recognition terminal

## Installation

1. Clone or download the project
2. Build the project:
   ```powershell
   dotnet build
   ```
3. Run the executable from the output directory or use `dotnet run`

## Usage

```powershell
dotnet run -- [command] [options]
```

Or if using the built executable:
```powershell
.\Hiky.exe [command] [options]
```

## Commands

### Device Configuration

#### `configure-device`
Configure device connection settings including IP address, port, username, and password.

**Options:**
- `-i, --ip-address <ip>` - Device IP address
- `-p, --port <port>` - Device port number
- `-u, --username <username>` - Authentication username
- `-w, --password <password>` - Authentication password
- `-s, --show` - Show current configuration

**Examples:**
```powershell
# Configure device connection
dotnet run -- configure-device -i 192.168.1.100 -p 80 -u admin -w password123

# Show current configuration
dotnet run -- configure-device -s

# Update only the IP address
dotnet run -- configure-device -i 192.168.1.101
```

### Device Support

#### `check-support`
Check if the device supports listening for events.

**Example:**
```powershell
dotnet run -- check-support
```

### Listening Hosts Management

#### `get-hosts`
Get all configured listening hosts on the device.

**Example:**
```powershell
dotnet run -- get-hosts
```

#### `get-host`
Get details of a specific listening host by ID.

**Arguments:**
- `<id>` - Host ID number

**Example:**
```powershell
dotnet run -- get-host 1
```

#### `set-hosts`
Configure a listening host on the device.

**Options:**
- `-i, --ip-address <ip>` - Host IP address
- `-p, --port-no <port>` - Host port number
- `-u, --url <url>` - Host URL
- `--id <id>` - Host identifier

**Example:**
```powershell
dotnet run -- set-hosts -i 192.168.1.200 -p 8080 -u "/events" --id "host1"
```

### Event Listening

#### `listen`
Start listening for events on the specified port.

**Arguments:**
- `<port>` - Port number to listen on

**Example:**
```powershell
dotnet run -- listen 8080
```

### Access Control

#### `get-ac-cap`
Get access control capabilities from the device.

**Example:**
```powershell
dotnet run -- get-ac-cap
```

#### `get-ac-config`
Get access control configuration from the device.

**Example:**
```powershell
dotnet run -- get-ac-config
```

#### `enable-remote-check`
Enable or disable remote check functionality on the device.

**Options:**
- `-e, --enable <true|false>` - Enable (true) or disable (false) remote check

**Examples:**
```powershell
# Enable remote check
dotnet run -- enable-remote-check -e true

# Disable remote check
dotnet run -- enable-remote-check -e false
```

## Configuration

The application stores device configuration locally and uses it for subsequent API calls. Make sure to configure your device connection details using the `configure-device` command before using other commands.

## Development

### Project Structure
- `Commands.cs` - Contains all CLI command definitions
- `Program.cs` - Application entry point and service configuration
- `Services/` - Business logic services for each command
- `EventListener/` - Event listening functionality

## Troubleshooting

1. **Connection Issues**: Ensure the device is accessible and the configuration is correct using `configure-device -s`
2. **Authentication Errors**: Verify username and password with `configure-device` command
3. **Command Not Found**: Use `--help` to see available commands

## Help

For detailed help on any command, use:
```powershell
dotnet run -- [command] --help
```

Or for general help:
```powershell
dotnet run -- --help
```
