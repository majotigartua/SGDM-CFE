using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Views
{
    public partial class DeviceView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly DeviceType _deviceType;
        private readonly object _device;

        private OpticalReader? _opticalReader;
        private MobileDevice? _mobileDevice;

        public DeviceView(Context context, DeviceType deviceType, object device)
        {
            _context= context;
            _deviceService = new DeviceService(_context);
            _deviceType = deviceType;
            _device = device;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                TitleLabel.Content = GetTitleLabel();
                var state = LoadState();
                if (state != null) 
                {
                    var assignment = _deviceService.GetAssignmentByState(state.Id);
                }
                else
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                }
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private string GetTitleLabel()
        {
            return _deviceType switch
            {
                DeviceType.OpticalReader => Strings.ViewOpticalReaderLabel,
                DeviceType.PortableTerminal => Strings.ViewPortableTerminalLabel,
                DeviceType.Tablet => Strings.ViewTabletLabel,
                _ => throw new Exception(),
            };
        }

        private State? LoadState()
        {
            if (_device is OpticalReader opticalReader)
            {
                _opticalReader = opticalReader;
                var states = _deviceService.GetStatesByDevice(opticalReader.Device.Id);
                return !states.IsNullOrEmpty() ? states.Last() : null;
            }
            else if (_device is MobileDevice mobileDevice)
            {
                _mobileDevice = mobileDevice;
                var states = _deviceService.GetStatesByDevice(mobileDevice.Device.Id);
                return !states.IsNullOrEmpty() ? states.Last() : null;
            }
            return null;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}