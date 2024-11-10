using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class EmployeeView : UserControl
    {
        private readonly Context _context;
        private readonly EmployeeService _employeeService;
        private readonly Employee? _employee;

        public EmployeeView(Context context, Employee employee)
        {
            _context = context;
            _employeeService = new EmployeeService(_context);
            _employee = employee;
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}