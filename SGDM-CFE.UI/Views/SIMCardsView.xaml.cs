using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
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
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                var simCards = _deviceService.GetSIMCards();
                if (!simCards.IsNullOrEmpty())
                {
                    SIMCardsDataGrid.ItemsSource = simCards;
                }
                else
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                }
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
            if (SIMCardsDataGrid.SelectedItem is SIMCard simCard)
            {
                ShowEditSIMCardWindow(simCard);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowEditSIMCardWindow(SIMCard simCard)
        {
            var editSIMCardWindow = new SIMCardWindow(_context, simCard, isEditWindow: true);
            editSIMCardWindow.ShowDialog();
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (SIMCardsDataGrid.SelectedItem is SIMCard simCard)
            {
                DeleteSIMCard(simCard);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void DeleteSIMCard(SIMCard simCard)
        {
            throw new NotImplementedException();
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createSIMCardWindow = new SIMCardWindow(_context, simCard: new SIMCard(), isEditWindow: false);
            createSIMCardWindow?.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            if (SIMCardsDataGrid.SelectedItem is SIMCard simCard)
            {
                ShowSIMCardView(simCard);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowSIMCardView(SIMCard simCard)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var simCardView = new SIMCardView(_context, simCard);
                mainWindow.MainContent.Content = simCardView;
            }
        }
    }
}