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
        private readonly Context _context;
        private readonly Employee _employee;

        public MainWindow(Context context, Employee employee)
        {
            _context = context;
            _employee = employee;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                switch (_employee.User?.Role?.Id)
                {
                    case Roles.Administrator:
                        SetButtonVisibility(isAdministrator: true);
                        break;
                    case Roles.Operator:
                        SetButtonVisibility(isAdministrator: false);
                        break;
                    default:
                        ShowWarning(Strings.AccessDeniedMessage, Strings.AccessDeniedWindowTitle);
                        return;
                }
                NavigateTo(ViewType.StartPanel);
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void SetButtonVisibility(bool isAdministrator)
        {
            EmployeesButton.Visibility = isAdministrator ? Visibility.Visible : Visibility.Collapsed;
            WorkCentersButton.Visibility = isAdministrator ? Visibility.Visible : Visibility.Collapsed;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
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
                ViewType.Employees => new EmployeesView(_context),
                ViewType.OpticalReaders => new DevicesView(_context, DeviceType.OpticalReader),
                ViewType.PortableTerminals => new DevicesView(_context, DeviceType.PortableTerminal),
                ViewType.SIMCards => new SIMCardsView(_context),
                ViewType.StartPanel => new StartPanelView(_context, _employee),
                ViewType.Tablets => new DevicesView(_context, DeviceType.Tablet),
                ViewType.WorkCenters => new WorkCentersView(_context),
                _ => throw new Exception()
            };
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            NavigateToLoginWindow();
        }

        private void NavigateToLoginWindow()
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
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
            }
        }
    }
}