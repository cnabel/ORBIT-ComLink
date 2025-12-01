namespace ORBIT.ComLink.Client.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}