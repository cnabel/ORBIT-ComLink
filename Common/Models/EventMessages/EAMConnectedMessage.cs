namespace ORBIT.ComLink.Common.Network.Client;

public class EAMConnectedMessage
{
    public EAMConnectedMessage(int clientCoalition)
    {
        ClientCoalition = clientCoalition;
    }

    public int ClientCoalition { get; }
}