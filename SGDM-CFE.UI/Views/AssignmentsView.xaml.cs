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
    public partial class AssignmentsView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly DeviceType _deviceType;
        private readonly object _device;

        public AssignmentsView(Context context, DeviceType deviceType, object device)
        {
            _context = context;
            _deviceService = new DeviceService(context);
            _deviceType = deviceType;
            _device = device;
            InitializeComponent();
            ConfigureView();
        } 

        private void ConfigureView()
        {
            try
            {
                var assignments = LoadAssignments();
                if (!assignments.IsNullOrEmpty())
                {
                    AssignmentsDataGrid.ItemsSource = assignments;
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

        private List<Assignment> LoadAssignments()
        {
            if (_device is OpticalReader opticalReader)
            {
                var assignments = _deviceService.GetAssignmentsByDevice(opticalReader.Device.Id);
                return assignments;
            }
            else if (_device is MobileDevice mobileDevice)
            {
                var assignments = _deviceService.GetAssignmentsByDevice(mobileDevice.Device.Id);
                return assignments;
            }
            return [];
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var deviceView = new DeviceView(_context, _deviceType, _device);
                mainWindow.MainContent.Content = deviceView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            if (AssignmentsDataGrid.SelectedItem is Assignment assignment)
            {
                ShowAssignmentView(assignment);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowAssignmentView(Assignment assignment)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var assignmentView = new AssignmentView(_context, _deviceType, _device, assignment);
                mainWindow.MainContent.Content = assignmentView;
            }
        }
    }
}