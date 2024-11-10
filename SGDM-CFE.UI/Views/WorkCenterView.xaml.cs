using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCenterView : UserControl
    {
        private readonly Context _context;
        private readonly WorkCenter _workCenter;

        public WorkCenterView(Context context, WorkCenter workCenter)
        {
            _context = context;
            InitializeComponent();
            _workCenter = workCenter;
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}