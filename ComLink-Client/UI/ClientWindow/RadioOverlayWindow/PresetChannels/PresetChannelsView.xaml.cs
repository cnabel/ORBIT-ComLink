using System.Windows.Controls;

namespace ORBIT.ComLink.Client.UI.ClientWindow.RadioOverlayWindow.PresetChannels;

/// <summary>
///     Interaction logic for PresetChannelsView.xaml
/// </summary>
public partial class PresetChannelsView : UserControl
{
    public PresetChannelsView()
    {
        InitializeComponent();

        //set to window width
        FrequencyDropDown.Width = Width;
    }
}