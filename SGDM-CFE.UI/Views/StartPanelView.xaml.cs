using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class StartPanelView : UserControl
    {
        private readonly Context _context;
        private readonly Employee _employee;

        public StartPanelView(Context context, Employee employee)
        {
            _context = context;
            _employee = employee;
            InitializeComponent();
        }

        private void EditUserButtonClick(object sender, RoutedEventArgs e)
        {
            var userWindow = new UserWindow(_context, _employee, isEditWindow: true);
            userWindow.ShowDialog();
        }
    }
}