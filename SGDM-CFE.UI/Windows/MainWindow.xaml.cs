using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Views;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Windows
{
    public partial class MainWindow : Window
    {
        private readonly ContextService _contextService;
        private readonly Employee _employee;

        public MainWindow(ContextService contextService, Employee employee)
        {
            _contextService = contextService;

            _employee = employee;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            StartPanelButton.Visibility = Visibility.Visible;
            int roleId = GetRoleId();
            switch (roleId)
            {
                case Roles.Administrator:
                    SetButtonVisibility(showAll: true);
                    break;

                case Roles.Operator:
                    SetButtonVisibility(showAll: false);
                    break;

                default:
                    NavigateToLoginWindow();
                    return;
            }
            NavigateTo(ViewType.StartPanel);
        }

        private int GetRoleId()
        {
            if (_employee != null && _employee.User != null && _employee.User.Role != null)
            {
                return _employee.User.RoleId;
            }
            return 0;
        }

        private void SetButtonVisibility(bool showAll)
        {
            EmployeesButton.Visibility = showAll ? Visibility.Visible : Visibility.Collapsed;
            OpticalReadersButton.Visibility = Visibility.Visible;
            PortableTerminalsButton.Visibility = Visibility.Visible;
            SIMCardsButton.Visibility = Visibility.Visible;
            TabletsButton.Visibility = Visibility.Visible;
            WorkCentersButton.Visibility = showAll ? Visibility.Visible : Visibility.Collapsed;
        }

        private void NavigateToLoginWindow()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void NavigateTo(ViewType viewType)
        {
            var view = GetView(viewType);
            MainContent.Content = view;
        }

        private UIElement GetView(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Employees => new EmployeesView(_contextService),
                ViewType.OpticalReaders => new DevicesView(_contextService, DeviceType.OpticalReader),
                ViewType.PortableTerminals => new DevicesView(_contextService, DeviceType.PortableTerminal),
                ViewType.SIMCards => new SIMCardsView(_contextService),
                ViewType.StartPanel => new StartPanelView(_contextService),
                ViewType.Tablets => new DevicesView(_contextService, DeviceType.Tablet),
                ViewType.WorkCenters => new WorkCentersView(_contextService),
                _ => throw new Exception()
            };
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToLoginWindow();
        }

        private void NavigateButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var viewTypes = new Dictionary<string, ViewType>()
                {
                    { EmployeesButton.Name, ViewType.Employees },
                    { OpticalReadersButton.Name, ViewType.OpticalReaders },
                    { PortableTerminalsButton.Name, ViewType.PortableTerminals },
                    { SIMCardsButton.Name, ViewType.SIMCards },
                    { StartPanelButton.Name, ViewType.StartPanel },
                    { TabletsButton.Name, ViewType.Tablets },
                    { WorkCentersButton.Name, ViewType.WorkCenters }
                };
                if (viewTypes.TryGetValue(button.Name, out ViewType viewType))
                {
                    NavigateTo(viewType);
                }
                else
                {
                    ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
                }
            }
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}