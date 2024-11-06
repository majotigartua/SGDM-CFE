using SGDM_CFE.BusinessLogic.Services;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class EmployeeWindow : Window
    {
        private readonly ContextService _contextService;

        public EmployeeWindow(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}