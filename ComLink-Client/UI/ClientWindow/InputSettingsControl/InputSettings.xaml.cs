using System.Windows;
using System.Windows.Controls;
using ORBIT.ComLink.Client.Singletons;

namespace ORBIT.ComLink.Client.UI.ClientWindow.InputSettingsControl;

/// <summary>
///     Interaction logic for InputSettings.xaml
/// </summary>
public partial class InputSettings : UserControl
{
    public InputSettings()
    {
        InitializeComponent();
    }

    private void Rescan_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(Application.Current.MainWindow,
            Properties.Resources.MsgBoxRescanText,
            Properties.Resources.MsgBoxRescan,
            MessageBoxButton.OK,
            MessageBoxImage.Information);
        InputDeviceManager.Instance.InitDevices();
    }
}