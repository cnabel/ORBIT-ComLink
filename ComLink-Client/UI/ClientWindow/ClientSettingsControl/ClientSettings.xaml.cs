using System.Windows.Controls;

namespace ORBIT.ComLink.Client.UI.ClientWindow.ClientSettingsControl;

/// <summary>
///     Interaction logic for ClientSettings.xaml
/// </summary>
public partial class ClientSettings : UserControl
{
    public ClientSettings()
    {
        InitializeComponent();
        DataContext = new ClientSettingsViewModel();
    }
}