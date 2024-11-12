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
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}