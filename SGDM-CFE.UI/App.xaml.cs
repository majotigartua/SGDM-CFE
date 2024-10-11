using Microsoft.UI.Xaml;
using SGDM_CFE.UI.Views;

namespace SGDM_CFE.UI
{
    public partial class App : Application
    {
        public Window LoginWindow { get; private set; }
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            LoginWindow = new LoginWindow();
            LoginWindow.Activate();
        }
    }
}
 