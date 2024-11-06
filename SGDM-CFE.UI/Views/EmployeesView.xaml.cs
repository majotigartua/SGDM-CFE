using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class EmployeesView : UserControl
    {
        private readonly ContextService _contextService;

        public EmployeesView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            ShowEmployeeWindow();
        }

        private void ShowEmployeeWindow()
        {
            var employeeWindow = new EmployeeWindow(_contextService);
            employeeWindow.ShowDialog();
        }

        private void CreateUserButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}