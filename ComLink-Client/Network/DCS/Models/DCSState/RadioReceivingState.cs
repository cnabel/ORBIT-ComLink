// using System;
// using System.Collections.Concurrent;
// using ORBIT.ComLink.Common.Network;
// using Newtonsoft.Json;
// using NLog.Layouts;
//
// namespace ORBIT.ComLink.Common
// {
//     public class RadioReceivingState
//     {
//         [JsonIgnore]
//         public long LastReceivedAt { get; set; }
//
//         public bool IsSecondary { get; set; }
//         public bool IsSimultaneous { get; set; }
//         public int ReceivedOn { get; set; }
// 
//         public string SentBy { get; set; }
//
//         public bool IsReceiving
//         {
//             get
//             {
//                 return (DateTime.Now.Ticks - LastReceviedAt) < 3500000;
//             }
//         }
//     }
// }

