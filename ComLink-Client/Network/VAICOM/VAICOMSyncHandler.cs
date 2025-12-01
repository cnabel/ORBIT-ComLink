using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ORBIT.ComLink.Client.Network.VAICOM.Models;
using ORBIT.ComLink.Client.Singletons;
using ORBIT.ComLink.Common.Network.Singletons;
using ORBIT.ComLink.Common.Settings;
using NLog;

namespace ORBIT.ComLink.Client.Network.VAICOM;

public class VAICOMSyncHandler
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly ClientStateSingleton _clientStateSingleton;
    private readonly GlobalSettingsStore _globalSettings = GlobalSettingsStore.Instance;
    private readonly SyncedServerSettings _serverSettings = SyncedServerSettings.Instance;
    private volatile bool _stop;
    private UdpClient _vaicomUDPListener;

    public VAICOMSyncHandler()
    {
        _clientStateSingleton = ClientStateSingleton.Instance;
    }

    public void Start()
    {
        Task.Factory.StartNew(() =>
        {
            while (!_stop)
                try
                {
                    var localEp = new IPEndPoint(IPAddress.Any,
                        _globalSettings.GetNetworkSetting(GlobalSettingsKeys.VAICOMIncomingUDP));
                    _vaicomUDPListener = new UdpClient(localEp);
                    break;
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex,
                        $"Unable to bind to the VAICOM Listener Socket Port: {_globalSettings.GetNetworkSetting(GlobalSettingsKeys.VAICOMIncomingUDP)}");
                    Thread.Sleep(500);
                }

            while (!_stop)
                try
                {
                    var groupEp = new IPEndPoint(IPAddress.Any, 0);
                    var bytes = _vaicomUDPListener.Receive(ref groupEp);

                    var vaicomMessageWrapper =
                        JsonSerializer.Deserialize<VAICOMMessageWrapper>(Encoding.UTF8.GetString(
                            bytes, 0, bytes.Length), new JsonSerializerOptions() { IncludeFields = true, PropertyNameCaseInsensitive = true, });

                    if (vaicomMessageWrapper != null)
                        if (vaicomMessageWrapper.MessageType == 1)
                            if (_globalSettings.GetClientSettingBool(GlobalSettingsKeys.VAICOMTXInhibitEnabled))
                            {
                                vaicomMessageWrapper.LastReceivedAt = DateTime.Now.Ticks;
                                _clientStateSingleton.InhibitTX = vaicomMessageWrapper;
                            }
                }
                catch (SocketException e)
                {
                    if (!_stop) Logger.Error(e, "SocketException Handling VAICOM UDP Message");
                }
                catch (Exception e)
                {
                    Logger.Error(e, "Exception Handling VAICOM UDP Message");
                }

            try
            {
                _vaicomUDPListener.Close();
            }
            catch (Exception e)
            {
                Logger.Error(e, "Exception stoping VAICOM UDP listener");
            }
        });
    }

    public void Stop()
    {
        _stop = true;
        try
        {
            _vaicomUDPListener?.Close();
        }
        catch (Exception)
        {
        }
    }
}