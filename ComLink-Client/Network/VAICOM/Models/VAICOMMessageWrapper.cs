using System.Text.Json.Serialization;

namespace ORBIT.ComLink.Client.Network.VAICOM.Models;

public class VAICOMMessageWrapper
{
    public bool InhibitTX;

    [JsonIgnore] public long LastReceivedAt;

    public int MessageType; //1 is InhibitTX
}