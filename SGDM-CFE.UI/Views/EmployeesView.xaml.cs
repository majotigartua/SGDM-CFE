using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class EmployeesView : UserControl
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;
        private readonly Employee? _employee;

        public EmployeesView(Context context)
        {
            _context = context;
            _employeeService = new EmployeeService(_context);
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                if (!employees.IsNullOrEmpty())
                {
                    EmployeesDataGrid.ItemsSource = employees;
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

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee employee)
            {
                ShowEditEmployeWindow(employee);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowEditEmployeWindow(Employee employee)
        {
            var editEmployeeWindow = new EmployeeWindow(_context, employee, isEditWindow: true);
            editEmployeeWindow.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee employee)
            {
                DeleteEmployee(employee);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createEmployeeWindow = new EmployeeWindow(_context, employee: new Employee(), isEditWindow: false);
            createEmployeeWindow.ShowDialog();
        }

        private void CreateUserButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee employee)
            {
                ShowCreateUserWindow(employee);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowCreateUserWindow(Employee employee)
        {
            var userWindow = new UserWindow(_context, employee, isEditWindow: false);
            userWindow.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee employee)
            {
                ShowEmployeeView(employee);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowEmployeeView(Employee employee)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var employeeView = new EmployeeView(_context, employee);
                mainWindow.MainContent.Content = employeeView;
            }
        }
    }
}