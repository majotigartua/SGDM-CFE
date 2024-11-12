using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class SIMCardView : UserControl
    {
        private readonly Context _context;
        private readonly SIMCard _simCard;

        public SIMCardView(Context context, SIMCard simCard)
        {
            _context = context;
            _simCard = simCard;
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
