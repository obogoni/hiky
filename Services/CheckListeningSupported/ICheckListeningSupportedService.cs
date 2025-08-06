using System;

namespace Hiky.Services.CheckListeningSupportedService;

public interface ICheckListeningSupportedService
{
    /// <summary>
    /// Checks if the device supports listening for events.
    /// </summary>
    /// <returns>True if the device supports listening, otherwise false.</returns>
    Task<bool> IsListeningSupportedAsync();
}
