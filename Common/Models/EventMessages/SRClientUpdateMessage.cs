using ORBIT.ComLink.Common.Models.Player;

namespace ORBIT.ComLink.Common.Models.EventMessages;

public class SRClientUpdateMessage
{
    public SRClientUpdateMessage(SRClientBase srClient, bool connected = true)
    {
        SrClient = srClient;
        Connected = connected;
    }

    public SRClientBase SrClient { get; }
    public bool Connected { get; }
}