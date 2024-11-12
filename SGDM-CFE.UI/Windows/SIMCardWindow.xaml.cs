using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class SIMCardWindow : Window
    {
        private readonly Context _context;
        private readonly SIMCard _simCard;
        private readonly bool _isEditWindow;

        public SIMCardWindow(Context context, SIMCard simCard, bool isEditWindow)
        {
            _context = context;
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
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}