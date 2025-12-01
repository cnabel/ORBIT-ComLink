using ORBIT.ComLink.Client.Network.DCS.Models.DCSState;

namespace ORBIT.ComLink.Client.Network.DCS;

public class InstructorModeMessage
{
    public DCSRadio Radio { get; set; }
    public int RadioId { get; set; }
}