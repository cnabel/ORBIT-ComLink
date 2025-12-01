using System.Net;

namespace ORBIT.ComLink.Common.Models;

public class PendingPacket
{
    public IPEndPoint ReceivedFrom { get; set; }
    public byte[] RawBytes { get; set; }
}