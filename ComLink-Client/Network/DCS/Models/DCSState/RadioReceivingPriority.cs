using ORBIT.ComLink.Common.Models;

namespace ORBIT.ComLink.Client.Network.DCS.Models.DCSState;

public class RadioReceivingPriority
{
    public bool Decryptable;
    public byte Encryption;
    public double Frequency;
    public float LineOfSightLoss;
    public short Modulation;
    public double ReceivingPowerLossPercent;
    public DCSRadio ReceivingRadio;

    public RadioReceivingState ReceivingState;
}