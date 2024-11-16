using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class EmployeeWindow : Window
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;
        private readonly Employee _employee;
        private readonly bool _isEditWindow;

        public EmployeeWindow(Context context, Employee employee, bool isEditWindow)
        {
            _context = context;
            _employeeService = new EmployeeService(context);
            _employee = employee;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditEmployeeWindowTitle : Strings.CreateEmployeeWindowTitle;
            if (_isEditWindow) PopulateFields();
        }

        private void PopulateFields()
        {
            RPETextBox.Text = _employee.RPE;
            NameTextBox.Text = _employee.Name;
            PaternalSurnameTextBox.Text = _employee.PaternalSurname;
            MaternalSurnameTextBox.Text = _employee.MaternalSurname;
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreFieldsFilled())
                {
                    _employee.RPE = RPETextBox.Text;
                    _employee.Name = NameTextBox.Text;
                    _employee.PaternalSurname = PaternalSurnameTextBox.Text;
                    _employee.MaternalSurname = MaternalSurnameTextBox.Text;
                    if (_isEditWindow)
                    {
                        EditEmployee();
                    }
                    else
                    {
                        CreateEmployee();
                    }
                    Close();
                }
                else
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                }
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(RPETextBox.Text) && !string.IsNullOrWhiteSpace(NameTextBox.Text) && !string.IsNullOrWhiteSpace(PaternalSurnameTextBox.Text) && !string.IsNullOrWhiteSpace(MaternalSurnameTextBox.Text);
        }

        private void EditEmployee()
        {
            bool isEdited = _employeeService.EditEmployee(_employee);
            if (isEdited)
            {
                ShowInformation(Strings.InformationEditedMessage, Strings.InformationEditedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateEmployee()
        {
            bool isCreated = _employeeService.CreateEmployee(_employee);
            if (isCreated)
            {
                ShowInformation(Strings.InformationCreatedMessage, Strings.InformationCreatedWindowTitle);
            }
            else
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

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}