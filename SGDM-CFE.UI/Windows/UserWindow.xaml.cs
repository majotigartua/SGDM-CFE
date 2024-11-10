using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class UserWindow : Window
    {
        private readonly Context _context;
        private readonly bool _isEditWindow;
        private readonly Employee _employee;

        public UserWindow(Context context, bool isEditWindow, Employee employee)
        {
            _context = context;
            _isEditWindow = isEditWindow;
            _employee = employee;
            InitializeComponent();
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