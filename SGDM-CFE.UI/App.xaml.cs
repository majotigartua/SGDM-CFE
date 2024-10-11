using Microsoft.UI.Xaml;

namespace SGDM_CFE.UI
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Window loginWindow = new LoginWindow();
            loginWindow.Activate();
        }
    }
}
