using SGDM_CFE.BusinessLogic.Interfaces;
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
    public partial class DeviceView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly DeviceType _deviceType;
        private readonly object _device;

        public DeviceView(Context context, DeviceType deviceType, object device)
        {
            _context = context;
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
                if (state == null)
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                PopulateStateDataGrid(state);
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
            int deviceId;
            switch (_device)
            {
                case OpticalReader opticalReader:
                    deviceId = opticalReader.Device.Id;
                    break;
                case MobileDevice mobileDevice:
                    deviceId = mobileDevice.Device.Id;
                    LoadSIMCard(mobileDevice.Id);
                    break;
                default:
                    return null;
            }
            var assignment = _deviceService.GetAssignmentsByDevice(deviceId).LastOrDefault();
            if (assignment?.ReturnState == null) PopulateEmployeeDataGrid(assignment!.Employee);
            return _deviceService.GetStateByDevice(deviceId);
        }

        private void LoadSIMCard(int mobileDeviceId)
        {
            DeviceAssignedSIMCardLabel.Visibility = Visibility.Visible;
            SIMCardDataGrid.Visibility = Visibility.Visible;
            var simCard = _deviceService.GetSIMCardByMobileDevice(mobileDeviceId);
            if (simCard != null) PopulateSIMCardDataGrid(simCard);
        }

        private void PopulateSIMCardDataGrid(SIMCard simCard)
        {
            var values = new List<Row>
            {
                new(Strings.SerialNumberRow, simCard.SerialNumber)
            };
            SIMCardDataGrid.ItemsSource = values;
        }

        private void PopulateEmployeeDataGrid(Employee employee)
        {
            var values = new List<Row>
            {
                new(Strings.RPERow, employee.RPE),
                new(Strings.NameRow, employee.Name),
                new(Strings.PaternalSurnameRow, employee.PaternalSurname),
                new(Strings.MaternalSurnameRow, employee.MaternalSurname)
            };
            EmployeeDataGrid.ItemsSource = values;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PopulateStateDataGrid(State state)
        {
            var values = new List<Row>
            {
                new(Strings.InventoryNumberRow, state.Device.InventoryNumber),
                new(Strings.SerialNumberRow, state.Device.SerialNumber),
                new(Strings.IsCriticalMissionRow, state.Device.IsCriticalMission ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.NotesRow, state.Device.Notes),
                new(Strings.HasFailuresRow, state.HasFailures ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.FailuresDescriptionRow, state.FailuresDescription),
                new(Strings.RequiresMaintenanceRow, state.RequiresMaintenance ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.IsFunctionalRow, state.IsFunctional ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.ReviewNotesRow, state.ReviewNotes),
                new(Strings.AreaRow, state.Device.WorkCenter.Area),
                new(Strings.WorkCenterRow, state.Device.WorkCenter),
                new(Strings.BusinessProcessRow, state.WorkCenterBusinessProcess.BusinessProcess),
                new(Strings.CostCenterRow, state.WorkCenterCostCenter.CostCenter)
            };
            StateDataGrid.ItemsSource = values;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var devicesView = new DevicesView(_context, _deviceType);
                mainWindow.MainContent.Content = devicesView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewAssignmentHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var assignmentsView = new AssignmentsView(_context, _deviceType, _device);
                mainWindow.MainContent.Content = assignmentsView;
            }
        }
    }
}