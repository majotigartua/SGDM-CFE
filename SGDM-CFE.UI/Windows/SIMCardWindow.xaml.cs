using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class SIMCardWindow : Window
    {
        private readonly Context _context;
        private readonly DeviceService _deviceService;
        private readonly SIMCard _simCard;
        private readonly bool _isEditWindow;

        public SIMCardWindow(Context context, SIMCard simCard, bool isEditWindow)
        {
            _context = context;
            _deviceService = new DeviceService(_context);
            _simCard = simCard;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditSIMCardWindowTitle : Strings.CreateSIMCardWindowTitle;
            if (_isEditWindow) SerialNumberTextBox.Text = _simCard.SerialNumber;
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var serialNumber = SerialNumberTextBox.Text;
                if (!string.IsNullOrEmpty(serialNumber))
                {
                    _simCard.SerialNumber = serialNumber;
                    if (_isEditWindow)
                    {
                        EditSIMCard();
                    }
                    else
                    {
                        CreateSIMCard();
                    }
                    Close();
                }
                else
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                }
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void EditSIMCard()
        {
            bool isEdited = _deviceService.EditSIMCard(_simCard);
            if (isEdited)
            {
                ShowInformation(Strings.InformationEditedMessage, Strings.InformationEditedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateSIMCard()
        {
            bool isCreated = _deviceService.CreateSIMCard(_simCard);
            if (isCreated)
            {
                ShowInformation(Strings.InformationCreatedMessage, Strings.InformationCreatedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}