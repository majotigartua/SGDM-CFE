using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.UI.Resources;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class SIMCardsView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;

        public SIMCardsView(Context context)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            InitializeComponent();
            LoadSIMCards();
        }

        private void LoadSIMCards()
        {
            try
            {
                SIMCardsDataGrid.ItemsSource = _deviceService.GetSIMCards();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}