using System.Collections.Generic;

namespace ORBIT.ComLink.Client.Settings.RadioChannels;

public interface IPresetChannelsStore
{
    IEnumerable<PresetChannel> LoadFromStore(string radioName, bool mids = false);

    string CreatePresetFile(string radioName);
}