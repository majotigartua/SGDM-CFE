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
            var editEmployeeWindow = new EmployeeWindow(_contextService, isEditWindow: true);
            editEmployeeWindow.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createEmployeeWindow = new EmployeeWindow(_contextService, isEditWindow: false);
            createEmployeeWindow.ShowDialog();
        }

        private void CreateUserButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            var employeeView = new EmployeeView(_contextService);
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.MainContent.Content = employeeView;
            }
        }
    }
}