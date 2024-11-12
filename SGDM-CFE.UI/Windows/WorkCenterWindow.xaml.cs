using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class WorkCenterWindow : Window
    { 
        private readonly Context _context;
        private readonly WorkCenter _workCenter;
        private readonly bool _isEditWindow;

        public WorkCenterWindow(Context context, WorkCenter workCenter, bool isEditWindow)
        {
            _context = context;
            _workCenter = workCenter;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditWorkCenterWindowTitle : Strings.CreateWorkCenterWindowTitle;
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