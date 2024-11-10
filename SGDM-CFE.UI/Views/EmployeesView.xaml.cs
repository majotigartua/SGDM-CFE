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

        private bool _isEditWindow;

        public EmployeesView(Context context)
        {
            _context= context;
            _employeeService = new EmployeeService(_context);
            InitializeComponent();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                EmployeesDataGrid.ItemsSource = new ObservableCollection<Employee>(employees);
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
            _isEditWindow = true;
            var editEmployeeWindow = new EmployeeWindow(_context, _isEditWindow, employee);
            editEmployeeWindow.ShowDialog();
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
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
            _isEditWindow = false;
            var employee = new Employee();
            var createEmployeeWindow = new EmployeeWindow(_context, _isEditWindow, employee);
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
            _isEditWindow = false;
            var userWindow = new UserWindow(_context, _isEditWindow, employee);
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
            var employeeView = new EmployeeView(_context, employee);
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.MainContent.Content = employeeView;
            }
        }
    }
}