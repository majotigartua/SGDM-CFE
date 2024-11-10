using SGDM_CFE.Model;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class AssignmentsView : UserControl
    {
        private readonly Context _context;

        public AssignmentsView(Context context)
        {
            _context = context;
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}