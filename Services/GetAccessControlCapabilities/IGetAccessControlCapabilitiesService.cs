using System;

namespace Hiky.Services.GetAccessControlCapabilities;

public interface IGetAccessControlCapabilitiesService
{
    Task<GetAccessControlCapabilitiesResponse> GetAccessControlCapabilitiesAsync();
}
