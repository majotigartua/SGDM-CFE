using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;

namespace SGDM_CFE.UI
{
    public partial class LoginWindow : Window
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;

        public LoginWindow()
        {
            _context = new Context();
            _employeeService = new EmployeeService(_context);
            InitializeComponent();
        }

        private void ForgotPasswordButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreFieldsEmpty())
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                    return;
                }
                var rpe = RPETextBox.Text;
                var password = PasswordBox.Password;
                Login(rpe, password);
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private bool AreFieldsEmpty()
        {
            return string.IsNullOrWhiteSpace(RPETextBox.Text) && string.IsNullOrWhiteSpace(PasswordBox.Password);
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Login(string rpe, string password)
        {
            password = Utilities.ComputeSHA256Hash(password);
            var employee = _employeeService.Login(rpe, password);
            if (employee == null)
            {
                ShowWarning(Strings.InvalidInformationMessage, Strings.InvalidInformationWindowTitle);
                PasswordBox.Clear();
                return;
            }
            NavigateToMainWindow(employee);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NavigateToMainWindow(Employee employee)
        {
            var mainWindow = new MainWindow(_context, employee);
            mainWindow.Show();
            Close();
        }
    }
}