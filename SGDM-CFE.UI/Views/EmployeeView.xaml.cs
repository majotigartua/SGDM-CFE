using SGDM_CFE.BusinessLogic.Services;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class EmployeeView : UserControl
    {
        private readonly ContextService _contextService;

        public EmployeeView(ContextService contextService)
        {
            _contextService = contextService;
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