using SGDM_CFE.Model;
using SGDM_CFE.UI.Resources;
using System.Windows;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Windows
{
    public partial class DeviceWindow : Window
    {
        private readonly Context _context;
        private readonly DeviceType _deviceType;
        private readonly bool _isEditWindow;

        public DeviceWindow(Context context, DeviceType deviceType, bool isEditWindow)
        {
            _context= context;
            _deviceType = deviceType;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = GetWindowTitle();
        }

        private string GetWindowTitle()
        {
            string action = _isEditWindow ? Strings.EditWindowTitle : Strings.CreateWindowTitle;
            string device = _deviceType switch
            {
                DeviceType.OpticalReader => Strings.OpticalReaderWindowTitle,
                DeviceType.PortableTerminal => Strings.PortableTerminalWindowTitle,
                DeviceType.Tablet => Strings.TabletWindowTitle,
                _ => throw new Exception()
            };
            return String.Concat(action, " ", device);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
