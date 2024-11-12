using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Views
{
    public partial class DevicesView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly DeviceType _deviceType;

        private List<OpticalReader>? _opticalReaders;
        private List<MobileDevice>? _mobileDevices;

        public DevicesView(Context context, DeviceType deviceType)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            _deviceType = deviceType;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                TitleLabel.Content = GetTitleLabel();
                var devices = LoadDevices();
                if (!devices.IsNullOrEmpty())
                {
                    DevicesDataGrid.ItemsSource = devices;
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
                DeviceType.OpticalReader => Strings.OpticalReadersLabel,
                DeviceType.PortableTerminal => Strings.PortableTerminalsLabel,
                DeviceType.Tablet => Strings.TabletsLabel,
                _ => throw new Exception(),
            };
        }

        private List<object>? LoadDevices()
        {
            List<object>? devices = [];
            switch (_deviceType)
            {
                case DeviceType.OpticalReader:
                    _opticalReaders = _deviceService.GetOpticalReaders();
                    devices.AddRange(_opticalReaders);
                    break;
                case DeviceType.PortableTerminal:
                    _mobileDevices = _deviceService.GetMobileDevicesByType((int)DeviceType.PortableTerminal);
                    devices.AddRange(_mobileDevices);
                    break;
                case DeviceType.Tablet:
                    _mobileDevices = _deviceService.GetMobileDevicesByType((int)DeviceType.Tablet);
                    devices.AddRange(_mobileDevices);
                    break;
                default:
                    throw new Exception();
            }
            return devices;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static void ShowWarning(string noSelectionMessage, string noSelectionWindowTitle)
        {
            MessageBox.Show(noSelectionMessage, noSelectionWindowTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedItem is object device)
            {
                ShowEditDeviceWindow(device);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowEditDeviceWindow(object device)
        {
            var editDeviceWindow = new DeviceWindow(_context, _deviceType, device, isEditWindow: true);
            editDeviceWindow.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedItem is object device)
            {
                DeleteDevice(device);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void DeleteDevice(object device)
        {
            throw new NotImplementedException();
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createDeviceWindow = new DeviceWindow(_context, _deviceType, device: new object(), isEditWindow: false);
            createDeviceWindow?.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedItem is object device)
            {
                ShowDeviceView(device);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowDeviceView(object device)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var deviceView = new DeviceView(_context, _deviceType, device);
                mainWindow.MainContent.Content = deviceView;
            }
        }
    }
}