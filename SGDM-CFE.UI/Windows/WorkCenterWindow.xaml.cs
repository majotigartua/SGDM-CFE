using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class WorkCenterWindow : Window
    {
        private readonly WorkCenterService _workCenterService;
        private readonly WorkCenter _workCenter;
        private readonly bool _isEditWindow;

        public WorkCenterWindow(Context context, WorkCenter workCenter, bool isEditWindow)
        {
            _workCenterService = new WorkCenterService(context);
            _workCenter = workCenter;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                Title = _isEditWindow ? Strings.EditWorkCenterWindowTitle : Strings.CreateWorkCenterWindowTitle;
                LoadAreas();
                LoadBusinessProcesses();
                LoadCostCenters();
                if (_isEditWindow) PopulateWorkCenterFields();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void LoadAreas()
        {
            var areas = _workCenterService.GetAreas();
            if (areas.IsNullOrEmpty())
            {
                ShowError(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            AreaComboBox.ItemsSource = areas;
        }

        private void LoadBusinessProcesses()
        {
            var businessProcesses = _workCenterService.GetBusinessProcesses();
            if (businessProcesses.IsNullOrEmpty())
            {
                ShowError(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            BusinessProcessesListBox.ItemsSource = businessProcesses;
        }

        private void LoadCostCenters()
        {
            var costCenters = _workCenterService.GetCostCenters();
            if (costCenters.IsNullOrEmpty())
            {
                ShowError(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            CostCentersListBox.ItemsSource = costCenters;
        }

        private void PopulateWorkCenterFields()
        {
            CodeTextBox.Text = _workCenter.Code;
            NameTextBox.Text = _workCenter.Name;
            AreaComboBox.SelectedItem = _workCenter.Area;
            PopulateBusinessProcessesListBox();
            PopulateCostCentersListBox();
        }

        private void PopulateBusinessProcessesListBox()
        {
            foreach (var businessProcess in _workCenter.WorkCenterBusinessProcesses)
            {
                if (!businessProcess.IsDeleted) BusinessProcessesListBox.SelectedItems.Add(businessProcess.BusinessProcess);
            }
        }

        private void PopulateCostCentersListBox()
        {
            foreach (var costCenter in _workCenter.WorkCenterCostCenters)
            {
                if (!costCenter.IsDeleted) CostCentersListBox.SelectedItems.Add(costCenter.CostCenter);
            }
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreEmptyFields())
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                    return;
                }
                UpdateWorkCenter();
                if (_isEditWindow)
                {
                    EditWorkCenter();
                }
                else
                {
                    CreateWorkCenter();
                }
                Close();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private bool AreEmptyFields()
        {
            return string.IsNullOrEmpty(CodeTextBox.Text) || string.IsNullOrEmpty(NameTextBox.Text) || AreaComboBox.SelectedItem == null || BusinessProcessesListBox.SelectedItems.Count == 0 || CostCentersListBox.SelectedItems.Count == 0;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void UpdateWorkCenter()
        {
            _workCenter.Code = CodeTextBox.Text;
            _workCenter.Name = NameTextBox.Text;
            _workCenter.Area = (Area)AreaComboBox.SelectedItem;
            UpdateBusinessProcesses();
            UpdateCostCenters();
        }

        private void UpdateBusinessProcesses()
        {
            var businessProcesses = BusinessProcessesListBox.SelectedItems.Cast<BusinessProcess>().ToList();
            foreach (var businessProcess in businessProcesses)
            {
                var workCenterBusinessProcess = _workCenter.WorkCenterBusinessProcesses.FirstOrDefault(wcbp => wcbp.BusinessProcess == businessProcess);
                if (workCenterBusinessProcess != null)
                {
                    workCenterBusinessProcess.IsDeleted = false;
                }
                else
                {
                    _workCenter.WorkCenterBusinessProcesses.Add(new WorkCenterBusinessProcess
                    {
                        WorkCenter = _workCenter,
                        BusinessProcess = businessProcess
                    });
                }
            }
            foreach (var workCenterBusinessProcess in _workCenter.WorkCenterBusinessProcesses)
            {
                if (!businessProcesses.Contains(workCenterBusinessProcess.BusinessProcess))
                {
                    workCenterBusinessProcess.IsDeleted = true;
                }
            }
        }

        private void UpdateCostCenters()
        {
            var costCenters = CostCentersListBox.SelectedItems.Cast<CostCenter>().ToList();
            foreach (var costCenter in costCenters)
            {
                var workCenterCostCenter = _workCenter.WorkCenterCostCenters.FirstOrDefault(wccc => wccc.CostCenter == costCenter);
                if (workCenterCostCenter != null)
                {
                    workCenterCostCenter.IsDeleted = false;
                }
                else
                {
                    _workCenter.WorkCenterCostCenters.Add(new WorkCenterCostCenter
                    {
                        WorkCenter = _workCenter,
                        CostCenter = costCenter
                    });
                }
            }
            foreach (var workCenterCostCenter in _workCenter.WorkCenterCostCenters)
            {
                if (!costCenters.Contains(workCenterCostCenter.CostCenter))
                {
                    workCenterCostCenter.IsDeleted = true;
                }
            }
        }

        private void EditWorkCenter()
        {
            if (_workCenterService.EditWorkCenter(_workCenter))
            {
                ShowInformation(Strings.InformationEditedMessage, Strings.InformationEditedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private static void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateWorkCenter()
        {
            if (_workCenterService.CreateWorkCenter(_workCenter))
            {
                ShowInformation(Strings.InformationCreatedMessage, Strings.InformationCreatedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}