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
        private readonly bool _isEditWindow;
        private readonly Employee? _employee;

        public EmployeeWindow(Context context, bool isEditWindow, Employee employee)
        {
            _context = context;
            _employeeService = new EmployeeService(context);
            _isEditWindow = isEditWindow;
            _employee = employee;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditEmployeeWindowTitle : Strings.CreateEmployeeWindowTitle;
            NameTextBox.Text = _employee?.Name;
            PaternalSurnameTextBox.Text = _employee?.PaternalSurname;
            MaternalSurnameTextBox.Text = _employee?.MaternalSurname;
            RPETextBox.Text = _employee?.RPE;
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