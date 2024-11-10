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

        private bool _isEditWindow;

        public WorkCentersView(Context context)
        {
            _context = context;
            _workCenterService = new WorkCenterService(_context);
            InitializeComponent();
            LoadWorkCenters();
        }

        private void LoadWorkCenters()
        {
            try
            {
                WorkCentersDataGrid.ItemsSource = _workCenterService.GetWorkCenters();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
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

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ShowEditWorkCenterWindow(WorkCenter workCenter)
        {
            _isEditWindow = true;
            var editWorkCenterWindow = new WorkCenterWindow(_context, _isEditWindow, workCenter);
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
            _isEditWindow = false;
            var workCenter = new WorkCenter();
            var createWorkCenterWindow = new WorkCenterWindow(_context, _isEditWindow, workCenter);
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
            var workCenterView = new WorkCenterView(_context, workCenter);
            if (Window.GetWindow(this) is MainWindow mainWindow)
            {
                mainWindow.MainContent.Content = workCenterView;
            }
        }
    }
}