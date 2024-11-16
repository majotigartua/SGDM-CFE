using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCenterView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly WorkCenter _workCenter;

        public WorkCenterView(Context context, WorkCenter workCenter)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            _workCenter = workCenter;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                PopulateWorkCenterDataGrid();
                var devices = _deviceService.GetDevicesByWorkCenter(_workCenter.Id);
                if (!devices.IsNullOrEmpty()) DevicesDataGrid.ItemsSource = devices;
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void PopulateWorkCenterDataGrid()
        {
            var values = new List<Row>
            {
                new(Strings.CodeRow, _workCenter.Code),
                new(Strings.NameRow, _workCenter.Name),
                new(Strings.AreaRow, _workCenter.Area.Name)
            };
            WorkCenterDataGrid.ItemsSource = values;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var workCentersView = new WorkCentersView(_context);
                mainWindow.MainContent.Content = workCentersView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}