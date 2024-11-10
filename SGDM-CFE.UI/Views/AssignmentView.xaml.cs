using SGDM_CFE.Model;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class AssignmentView : UserControl
    {
        private readonly Context _context;

        public AssignmentView(Context context)
        {
            _context = context;
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}