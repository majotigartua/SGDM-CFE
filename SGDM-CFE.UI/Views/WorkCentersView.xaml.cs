using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCentersView : UserControl
    {
        private readonly Context _context;
        private readonly WorkCenterService _workCenterService;

        public WorkCentersView(Context context)
        {
            _context = context;
            _workCenterService = new WorkCenterService(_context);
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                var workCenters = _workCenterService.GetWorkCenters();
                if (!workCenters.IsNullOrEmpty())
                {
                    WorkCentersDataGrid.ItemsSource = workCenters;
                }
                else
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                }
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (WorkCentersDataGrid.SelectedItem is WorkCenter workCenter)
            {
                ShowEditWorkCenterWindow(workCenter);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowEditWorkCenterWindow(WorkCenter workCenter)
        {
            var editWorkCenterWindow = new WorkCenterWindow(_context, workCenter, isEditWindow: true);
            editWorkCenterWindow.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            if (WorkCentersDataGrid.SelectedItem is WorkCenter workCenter)
            {
                DeleteWorkCenter(workCenter);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void DeleteWorkCenter(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            var createWorkCenterWindow = new WorkCenterWindow(_context, new WorkCenter(), isEditWindow : true);
            createWorkCenterWindow.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
            if (WorkCentersDataGrid.SelectedItem is WorkCenter workCenter)
            {
                ShowWorkCenterView(workCenter);
            }
            else
            {
                ShowWarning(Strings.NoSelectionMessage, Strings.NoSelectionWindowTitle);
            }
        }

        private void ShowWorkCenterView(WorkCenter workCenter)
        {
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                var workCenterView = new WorkCenterView(_context, workCenter);
                mainWindow.MainContent.Content = workCenterView;
            }
        }
    }
}