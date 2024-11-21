using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class AssignmentWindow : Window
    {
        private readonly DeviceService _deviceService;
        private readonly EmployeeService _employeeService;
        private readonly object _device;

        private State? _state;
        private Assignment? _assignment;
        private bool _isEditWindow;

        public AssignmentWindow(Context context, object device)
        {
            _deviceService = new DeviceService(context);
            _employeeService = new EmployeeService(context);
            _device = device;
            InitializeComponent();
            ConfigureView();
        }

        private void ConfigureView()
        {
            try
            {
                _state = LoadState();
                if (_state == null)
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                ConfigureAssignment();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private State? LoadState()
        {
            if (_device is OpticalReader opticalReader)
            {
                _assignment = _deviceService.GetAssignmentsByDevice(opticalReader.Device.Id).LastOrDefault();
                return _deviceService.GetStateByDevice(opticalReader.Device.Id);
            }
            else if (_device is MobileDevice mobileDevice)
            {
                _assignment = _deviceService.GetAssignmentsByDevice(mobileDevice.Device.Id).LastOrDefault();
                return _deviceService.GetStateByDevice(mobileDevice.Device.Id);
            }
            return null;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ConfigureAssignment()
        {
            if (_assignment == null || _assignment.ReturnState != null)
            {
                _isEditWindow = false;
                Title = Strings.AssignDeviceWindowTitle;
                AssignDeviceStackPanel.Visibility = Visibility.Visible;
                LoadEmployees();
            }
            else
            {
                _isEditWindow = true;
                Title = Strings.ReturnDeviceWindowTitle;
                ReturnDeviceStackPanel.Visibility = Visibility.Visible;
            }
        }

        private void LoadEmployees()
        {
            var employees = _employeeService.GetEmployees();
            if (employees.IsNullOrEmpty())
            {
                ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            EmployeeComboBox.ItemsSource = employees;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AreFieldsEmpty())
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                    return;
                }
                UpdateAssignment();
                if (_isEditWindow)
                {
                    EditAssignment();
                }
                else
                {
                    CreateAssignment();
                }
                Close();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private bool AreFieldsEmpty()
        {
            return (EmployeeComboBox.SelectedItem == null && AssignmentDatePicker.SelectedDate == null);
        }

        private void UpdateAssignment()
        {
            if (_isEditWindow)
            {
                _assignment!.ReturnDate = ReturnDatePicker.SelectedDate!.Value;
                _assignment.ReturnState = _state!;
            }
            else
            {
                _assignment = new Assignment
                {
                    AssignmentDate = AssignmentDatePicker.SelectedDate!.Value,
                    AssignmentState = _state!,
                    Employee = (Employee)EmployeeComboBox.SelectedItem
                };
            }
        }

        private void EditAssignment()
        {
            if (_deviceService.EditAssignment(_assignment!))
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

        private void CreateAssignment()
        {
            if (_deviceService.CreateAssignment(_assignment!))
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