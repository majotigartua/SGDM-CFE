using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class SIMCardView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly SIMCard _simCard;

        public SIMCardView(Context context, SIMCard simCard)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            _simCard = simCard;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                PopulateSIMCardDataGrid();
                var mobileDevice = _deviceService.GetMobileDeviceBySIMCard(_simCard.Id);
                if (mobileDevice != null) PopulateDeviceDataGrid(mobileDevice.Device);
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void PopulateDeviceDataGrid(Device device)
        {
            var values = new List<Row>
            {
                new(Strings.InventoryNumberRow, device.InventoryNumber),
                new(Strings.SerialNumberRow, device.SerialNumber),
                new(Strings.IsCriticalMissionRow, device.IsCriticalMission ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.NotesRow, device.Notes),
            };
            DeviceDataGrid.ItemsSource = values;
        }

        private void PopulateSIMCardDataGrid()
        {
            var values = new List<Row>
            {
                new(Strings.SerialNumberRow, _simCard.SerialNumber)
            };
            SIMCardDataGrid.ItemsSource = values;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var simCardsView = new SIMCardsView(_context);
                mainWindow.MainContent.Content = simCardsView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}
