using System;
using Ardalis.GuardClauses;

namespace Hiky.Services.SetListeningHosts;

public record SetListeningHostsRequest
{

    public SetListeningHostsRequest(ListeningHost[] listeningHosts)
    {
        Guard.Against.Null(listeningHosts, nameof(listeningHosts));
        Guard.Against.NullOrEmpty(listeningHosts, nameof(listeningHosts));
        
        ListeningHosts = listeningHosts;
    }

    public ListeningHost[] ListeningHosts { get; private set; }
}
