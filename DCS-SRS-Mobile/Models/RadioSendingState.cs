using Newtonsoft.Json;

namespace ORBIT.ComLink.Client.Mobile.Models;

public class RadioSendingState
{
    [JsonIgnore] public long LastSentAt { get; set; }

    public bool IsSending { get; set; }

    public int SendingOn { get; set; }

    public int IsEncrypted { get; set; }
}