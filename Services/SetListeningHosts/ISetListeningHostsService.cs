using System;

namespace Hiky.Services.SetListeningHosts;

public interface ISetListeningHostsService
{
    /// <summary>
    /// Sets the listening hosts.
    /// </summary>
    /// <param name="request">The request containing the listening hosts.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SetListeningHostsAsync(SetListeningHostsRequest request);
}
