using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Views
{
    public partial class AssignmentView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceType _deviceType;
        private readonly object _device;
        private readonly Assignment _assignment;

        public AssignmentView(Context context, DeviceType deviceType, object device, Assignment assignment)
        {
            _context = context;
            _deviceType = deviceType;
            _device = device;
            _assignment = assignment;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                PopulateDeviceDataGrid();
                PopulateEmployeeDataGrid();
                PopulateAssignmentStateDataGrid();
                var returnState = _assignment.ReturnState;
                if (returnState != null) PopulateReturnStateDataGrid(returnState);
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void PopulateDeviceDataGrid()
        {
            var device = GetDevice();
            var values = new List<Row>
            {
                new(Strings.InventoryNumberRow, device.InventoryNumber),
                new(Strings.SerialNumberRow, device.SerialNumber),
                new(Strings.IsCriticalMissionRow, device.IsCriticalMission ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.NotesRow, device.Notes),
            };
            DeviceDataGrid.ItemsSource = values;
        }

        private Device GetDevice()
        {
            return _device switch
            {
                OpticalReader opticalReader => opticalReader.Device,
                MobileDevice mobileDevice => mobileDevice.Device,
                _ => throw new Exception(),
            };
        }

        private void PopulateEmployeeDataGrid()
        {
            var employee = _assignment.Employee;
            var values = new List<Row>
            {
                new(Strings.RPERow, employee.RPE),
                new(Strings.NameRow, employee.Name),
                new(Strings.PaternalSurnameRow, employee.PaternalSurname),
                new(Strings.MaternalSurnameRow, employee.MaternalSurname)
            };
            EmployeeDataGrid.ItemsSource = values;
        }

        private void PopulateAssignmentStateDataGrid()
        {
            var assignmentState = _assignment.AssignmentState;
            var values = new List<Row>
            {
                new(Strings.HasFailuresRow, assignmentState.HasFailures ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.FailuresDescriptionRow, assignmentState.FailuresDescription),
                new(Strings.RequiresMaintenanceRow, assignmentState.RequiresMaintenance ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.IsFunctionalRow, assignmentState.IsFunctional ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.ReviewNotesRow, assignmentState.ReviewNotes),
                new(Strings.WorkCenterRow, assignmentState.Device.WorkCenter),
                new(Strings.BusinessProcessRow, assignmentState.WorkCenterBusinessProcess.BusinessProcess),
                new(Strings.CostCenterRow, assignmentState.WorkCenterCostCenter.CostCenter)
            };
            AssignmentStateDataGrid.ItemsSource = values;
        }

        private void PopulateReturnStateDataGrid(State returnState)
        {
            var values = new List<Row>
            {
                new(Strings.HasFailuresRow, returnState.HasFailures ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.FailuresDescriptionRow, returnState.FailuresDescription),
                new(Strings.RequiresMaintenanceRow, returnState.RequiresMaintenance ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.IsFunctionalRow, returnState.IsFunctional ? Strings.YesLabel : Strings.NoLabel),
                new(Strings.ReviewNotesRow, returnState.ReviewNotes),
                new(Strings.WorkCenterRow, returnState.Device.WorkCenter),
                new(Strings.BusinessProcessRow, returnState.WorkCenterBusinessProcess.BusinessProcess),
                new(Strings.CostCenterRow, returnState.WorkCenterCostCenter.CostCenter)
            };
            ReturnStateDataGrid.ItemsSource = values;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var assignmentsView = new AssignmentsView(_context, _deviceType, _device);
                mainWindow.MainContent.Content = assignmentsView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}