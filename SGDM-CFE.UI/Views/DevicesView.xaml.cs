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

        private bool _isEditWindow;

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
            TitleLabel.Content = GetViewTitle();
            LoadDevices();
        }

        private string GetViewTitle()
        {
            return _deviceType switch
            {
                DeviceType.OpticalReader => Strings.OpticalReadersLabel,
                DeviceType.PortableTerminal => Strings.PortableTerminalsLabel,
                DeviceType.Tablet => Strings.TabletsLabel,
                _ => throw new Exception(),
            };
        }

        private void LoadDevices()
        {
            try
            {
                switch (_deviceType)
                {
                    case DeviceType.OpticalReader:
                        _opticalReaders = _deviceService.GetOpticalReaders();
                        DevicesDataGrid.ItemsSource = _opticalReaders;
                        break;
                    case DeviceType.PortableTerminal:
                        _mobileDevices = _deviceService.GetMobileDevicesByType((int)DeviceType.PortableTerminal);
                        DevicesDataGrid.ItemsSource = _mobileDevices;
                        break;
                    case DeviceType.Tablet:
                        _mobileDevices = _deviceService.GetMobileDevicesByType((int)DeviceType.Tablet);
                        DevicesDataGrid.ItemsSource = _mobileDevices;
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            _isEditWindow = true;
            DeviceWindow? editWindow = _deviceType switch
            {
                DeviceType.OpticalReader => new DeviceWindow(_context, DeviceType.OpticalReader, _isEditWindow),
                DeviceType.PortableTerminal => new DeviceWindow(_context, DeviceType.PortableTerminal, _isEditWindow),
                DeviceType.Tablet => new DeviceWindow(_context, DeviceType.Tablet, _isEditWindow),
                _ => throw new Exception(),
            };
            editWindow?.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (DevicesDataGrid.SelectedItem is OpticalReader opticalReader)
            {
                DeleteOpticalReader(opticalReader);
            }
            else if (DevicesDataGrid.SelectedItem is MobileDevice mobileDevice)
            {
                DeleteMobileDevice(mobileDevice);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void DeleteOpticalReader(OpticalReader opticalReader)
        {
            throw new NotImplementedException();
        }

        private void DeleteMobileDevice(MobileDevice mobileDevice)
        {
            throw new NotImplementedException();
        }

        private static void ShowWarning(string noSelectionMessage, string noSelectionWindowTitle)
        {
            MessageBox.Show(noSelectionMessage, noSelectionWindowTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            _isEditWindow = false;
            DeviceWindow? createWindow = _deviceType switch
            {
                DeviceType.OpticalReader => new DeviceWindow(_context, DeviceType.OpticalReader, _isEditWindow),
                DeviceType.PortableTerminal => new DeviceWindow(_context, DeviceType.PortableTerminal, _isEditWindow),
                DeviceType.Tablet => new DeviceWindow(_context, DeviceType.Tablet, _isEditWindow),
                _ => throw new Exception(),
            };
            createWindow?.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            var device = DevicesDataGrid.SelectedItem;
            if (device != null)
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
            throw new NotImplementedException();
        }
    }
}