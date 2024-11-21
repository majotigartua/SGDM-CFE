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
                if (devices.IsNullOrEmpty())
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                DevicesDataGrid.ItemsSource = devices;
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
                case DeviceType.Tablet:
                    _mobileDevices = _deviceService.GetMobileDevicesByType((int)_deviceType);
                    devices.AddRange(_mobileDevices);
                    break;
                default:
                    throw new Exception();
            }
            return devices;
        }

        private static void ShowWarning(string noSelectionMessage, string noSelectionWindowTitle)
        {
            MessageBox.Show(noSelectionMessage, noSelectionWindowTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AssignReturnDeviceButtonClick(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedItem is object device)
            {
                ShowAssignReturnDeviceWindow(device);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowAssignReturnDeviceWindow(object device)
        {
            var assignReturnDeviceWindow = new AssignmentWindow(_context, device);
            assignReturnDeviceWindow.ShowDialog();
            ConfigureView();
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
            ConfigureView();
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
            if (ShowDeleteConfirmation() != MessageBoxResult.Yes) return;
            bool isDeleted = device switch
            {
                OpticalReader opticalReader => _deviceService.DeleteOpticalReader(opticalReader),
                MobileDevice mobileDevice => _deviceService.DeleteMobileDevice(mobileDevice),
                _ => false
            };
            if (isDeleted)
            {
                ShowInformation(Strings.InformationDeletedMessage, Strings.InformationDeletedWindowTitle);
                ConfigureView();
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static MessageBoxResult ShowDeleteConfirmation()
        {
            return MessageBox.Show(Strings.DeleteConfirmationMessage, Strings.DeleteConfirmationWindowTitle, MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }

        private static void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createDeviceWindow = new DeviceWindow(_context, _deviceType, device: new object(), isEditWindow: false);
            createDeviceWindow.ShowDialog();
            ConfigureView();
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