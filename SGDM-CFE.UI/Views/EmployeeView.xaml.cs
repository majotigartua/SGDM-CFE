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
    public partial class EmployeeView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly Employee? _employee;

        public EmployeeView(Context context, Employee employee)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            _employee = employee;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                if (_employee == null)
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                PopulateEmployeeDataGrid();
                var assignments = _deviceService.GetAssignmentsByEmployee(_employee.Id);
                if (!assignments.IsNullOrEmpty()) DevicesDataGrid.ItemsSource = assignments;
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PopulateEmployeeDataGrid()
        {
            var values = new List<Row>
            {
                new(Strings.RPERow, _employee?.RPE),
                new(Strings.NameRow, _employee?.Name),
                new(Strings.PaternalSurnameRow, _employee?.PaternalSurname),
                new(Strings.MaternalSurnameRow, _employee?.MaternalSurname)
            };
            EmployeeDataGrid.ItemsSource = values;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var employeesView = new EmployeesView(_context);
                mainWindow.MainContent.Content = employeesView;
            }
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}