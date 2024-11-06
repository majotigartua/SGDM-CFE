using SGDM_CFE.BusinessLogic.Services;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class PortableTerminalsView : UserControl
    {
        private readonly ContextService _contextService;

        public PortableTerminalsView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}