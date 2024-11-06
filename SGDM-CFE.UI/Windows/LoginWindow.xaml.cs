using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;

namespace SGDM_CFE.UI
{
    public partial class LoginWindow : Window
    {
        private readonly ContextService _contextService;
        private readonly EmployeeService _employeeService;

        public LoginWindow()
        {
            _contextService = new ContextService();
            var context = _contextService.Context;
            _employeeService = new EmployeeService(context);
            InitializeComponent();
        }

        private void ForgotPasswordButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (AreFieldsFilled())
            {
                var rpe = RPETextBox.Text;
                var password = PasswordBox.Password;
                password = Utilities.ComputeSHA256Hash(password);
                Login(rpe, password);
            }
            else
            {
                ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
            }
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(RPETextBox.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Password);
        }

        private void Login(string rpe, string password)
        {
            try
            {
                var employee = _employeeService.Login(rpe, password);
                if (employee != null)
                {
                    NavigateToMainWindow(employee);
                }
                else
                {
                    ShowWarning(Strings.InvalidInformationMessage, Strings.InvalidInformationWindowTitle);
                }
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

        private void NavigateToMainWindow(Employee employee)
        {
            var mainWindow = new MainWindow(_contextService, employee);
            mainWindow.Show();
            Close();
        }
    }
}