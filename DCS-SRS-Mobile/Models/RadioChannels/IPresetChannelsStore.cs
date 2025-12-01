namespace ORBIT.ComLink.Client.Mobile.Models.RadioChannels;

public interface IPresetChannelsStore
{
    IEnumerable<PresetChannel> LoadFromStore(string radioName, bool mids = false);

    string CreatePresetFile(string radioName);
}