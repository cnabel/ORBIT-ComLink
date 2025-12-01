using System.Collections.Generic;
using System.Net.Sockets;

namespace ORBIT.ComLink.Common.Models;

public class OutgoingTCPMessage
{
    public NetworkMessage NetworkMessage { get; set; }

    public List<Socket> SocketList { get; set; }
}