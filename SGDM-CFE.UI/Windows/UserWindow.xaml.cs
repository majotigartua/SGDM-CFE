using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class UserWindow : Window
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;
        private readonly Employee _employee;
        private readonly bool _isEditWindow;

        public UserWindow(Context context, Employee employee, bool isEditWindow)
        {
            _context = context;
            _employeeService = new EmployeeService(_context);
            _employee = employee;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                var roles = _employeeService.GetRoles();
                if (!roles.IsNullOrEmpty())
                {
                    RoleComboBox.ItemsSource = roles;
                    if (_isEditWindow) PopulateFields();
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

        private void PopulateFields()
        {
            EmailTextBox.Text = _employee.User?.Email;
            RoleComboBox.SelectedItem = _employee.User?.Role;
            RoleComboBox.IsEnabled = false;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
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