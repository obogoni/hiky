using System;

namespace Hiky.Services.SetListeningHosts;

public record ListeningHost(string Id, string IpAddress, int PorNo, string Url)
{
    public string ProtocolType => "HTTP";

    public string HttpAuthenticationMethod => "none";

    public string AddressingFormatType => "ipaddress";
    
    public string ParameterFormatType => "XML";
}
