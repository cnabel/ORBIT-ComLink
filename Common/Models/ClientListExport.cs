using System.Collections.Generic;
using ORBIT.ComLink.Common.Models.Player;

namespace ORBIT.ComLink.Common.Models;

public struct ClientListExport
{
    public ICollection<SRClientBase> Clients { get; set; }

    public string ServerVersion { get; set; }
}