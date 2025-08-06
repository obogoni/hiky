using Hiky.Services.EnableRemoteCheck;

public interface IEnableRemoteCheckService
{
    /// <summary>
    /// Enables or disables remote check on the device.
    /// </summary>
    /// <param name="enable">True to enable remote check, false to disable.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task EnableRemoteCheckAsync(bool enable);
}