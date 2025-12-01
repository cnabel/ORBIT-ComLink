using System.Collections.Generic;
using System.Net;

namespace ORBIT.ComLink.Common.Models;

public class OutgoingUDPPackets
{
    public List<IPEndPoint> OutgoingEndPoints { get; set; }
    public byte[] ReceivedPacket { get; set; }
}