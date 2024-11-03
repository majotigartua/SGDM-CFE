using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using Strings = SGDM_CFE.UI.Resources.Strings;

namespace SGDM_CFE.UI
{
    public partial class LoginWindow : Window
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new Context();
            _employeeService = new EmployeeService(_context);
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
                try
                {
                    var employee = _employeeService.Login(rpe, password);
                    if (employee != null)
                    {
                        var mainWindow = new MainWindow(_context, employee);
                        mainWindow.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show(Strings.InvalidInformationMessage, Strings.InvalidInformationWindowTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(RPETextBox.Text) && !string.IsNullOrWhiteSpace(PasswordBox.Password);
        }
    }
}