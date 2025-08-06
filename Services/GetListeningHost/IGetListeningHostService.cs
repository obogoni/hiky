using System;

namespace Hiky.Services.GetListeningHost;

public interface IGetListeningHostService
{
    /// <summary>
    /// Retrieves the host that is currently listening for connections.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation, containing the listening host.</returns>
    Task<string> GetListeningHostAsync(int id);
}