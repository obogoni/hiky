using System;

namespace Hiky.Services.GetListeningHosts;

public interface IGetListeningHostsService
{
    /// <summary>
    /// Retrieves a list of hosts that are currently listening for connections.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing a list of listening hosts.</returns>
    Task<IEnumerable<string>> GetListeningHostsAsync();
}
