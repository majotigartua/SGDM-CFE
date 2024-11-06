using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCentersView : UserControl
    {
        private readonly ContextService _contextService;

        public WorkCentersView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            var editWorkCenterWindow = new WorkCenterWindow(_contextService, isEditWindow: true);
            editWorkCenterWindow.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createWorkCenterWindow = new WorkCenterWindow(_contextService, isEditWindow: false);
            createWorkCenterWindow.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}