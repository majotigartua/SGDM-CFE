using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Windows
{
    public partial class DeviceWindow : Window
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly WorkCenterService _workCenterService;
        private readonly DeviceType _deviceType;
        private readonly object _device;
        private readonly bool _isEditWindow;

        public DeviceWindow(Context context, DeviceType deviceType, object device, bool isEditWindow)
        {
            _context= context;
            _deviceService = new DeviceService(_context);
            _workCenterService = new WorkCenterService(_context);
            _deviceType = deviceType;
            _device = device;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                Title = GetWindowTitle();
                var areas = _workCenterService.GetAreas();
                if (!areas.IsNullOrEmpty())
                {
                    AreaComboBox.ItemsSource = areas;
                    SetFieldVisibility();
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
            return string.Concat(action, " ", device);
        }

        private void SetFieldVisibility()
        {
            bool isMobileDevice = _deviceType == DeviceType.PortableTerminal || _deviceType == DeviceType.Tablet;
            SIMCardLabel.Visibility = isMobileDevice ? Visibility.Visible : Visibility.Collapsed;
            SIMCardComboBox.Visibility = isMobileDevice ? Visibility.Visible : Visibility.Collapsed;
            if (isMobileDevice) LoadSIMCards();
        }

        private void LoadSIMCards()
        {
            var simCards = _deviceService.GetSIMCards();
            if (!simCards.IsNullOrEmpty())
            {
                SIMCardComboBox.ItemsSource = simCards;
            }
            else
            {
                ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
            }
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AreaComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void WorkCenterComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
