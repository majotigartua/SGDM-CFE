using SGDM_CFE.Model;
using SGDM_CFE.UI.Views;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Utilities;

namespace SGDM_CFE.UI.Windows
{
    public partial class MainWindow : Window
    {
        private readonly Context _context;

        public MainWindow(Context context)
        {
            _context = context;
            InitializeComponent();
            NavigateTo(ViewType.StartPanel);
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
                ViewType.OpticalReaders => new OpticalReadersView(_context),
                ViewType.PortableTerminals => new PortableTerminalsView(_context),
                ViewType.SIMCards => new SIMCardsView(_context),
                ViewType.StartPanel => new StartPanelView(_context),
                ViewType.Tablets => new TabletsView(_context),
                ViewType.WorkCenters => new WorkCentersView(_context),
                _ => throw new Exception()
            };
        }

        private void LogoutButtonClick(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void NavigateButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && Enum.TryParse<ViewType>(button.Tag.ToString(), out var viewType))
            {
                NavigateTo(viewType);
            }
        }
    }
}