using ORBIT.ComLink.Client.Network.DCS.Models.DCSState;
using ORBIT.ComLink.Client.Network.Models;
using RadioReceivingState = ORBIT.ComLink.Common.Models.RadioReceivingState;

namespace ORBIT.ComLink.Client.Network.DCS.Models;

public struct CombinedRadioState
{
    public DCSPlayerRadioInfo RadioInfo;

    public RadioSendingState RadioSendingState;

    public RadioReceivingState[] RadioReceivingState;

    public int ClientCountConnected;

    public int[] TunedClients;
}