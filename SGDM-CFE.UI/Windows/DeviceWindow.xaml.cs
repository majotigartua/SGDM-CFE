using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Windows
{
    public partial class DeviceWindow : Window
    {
        private readonly DeviceService _deviceService;
        private readonly WorkCenterService _workCenterService;
        private readonly DeviceType _deviceType;
        private readonly object _device;
        private readonly bool _isEditWindow;

        private Assignment? _assignment;

        public DeviceWindow(Context context, DeviceType deviceType, object device, bool isEditWindow)
        {
            _deviceService = new DeviceService(context);
            _workCenterService = new WorkCenterService(context);
            _deviceType = deviceType;
            _device = device;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                Title = GetWindowTitle();
                LoadAreas();
                if (_deviceType.Equals(DeviceType.PortableTerminal) || _deviceType.Equals(DeviceType.Tablet)) LoadSIMCards();
                if (_isEditWindow) PopulateStateFields();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private string GetWindowTitle()
        {
            string action = _isEditWindow ? Strings.EditWindowTitle : Strings.CreateWindowTitle;
            string device = _deviceType switch
            {
                DeviceType.OpticalReader => Strings.OpticalReaderWindowTitle,
                DeviceType.PortableTerminal => Strings.PortableTerminalWindowTitle,
                DeviceType.Tablet => Strings.TabletWindowTitle,
                _ => throw new Exception()
            };
            return string.Concat(action, " ", device);
        }

        private void LoadAreas()
        {
            var areas = _workCenterService.GetAreas();
            if (areas.Count == 0)
            {
                ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            AreaComboBox.ItemsSource = areas;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PopulateStateFields()
        {
            var state = LoadState();
            if (state == null)
            {
                ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                return;
            }
            InventoryNumberTextBox.Text = state.Device.InventoryNumber;
            SerialNumberTextBox.Text = state.Device.SerialNumber;
            AreaComboBox.SelectedItem = state.Device.WorkCenter.Area;
            WorkCenterComboBox.SelectedItem = state.Device.WorkCenter;
            CostCenterComboBox.SelectedItem = state.WorkCenterCostCenter;
            BusinessProcessComboBox.SelectedItem = state.WorkCenterBusinessProcess;
            HasFailuresCheckBox.IsChecked = state.HasFailures;
            FailuresDescriptionTextBox.Text = state.FailuresDescription;
            RequiresMaintenanceCheckBox.IsChecked = state.RequiresMaintenance;
            IsCriticalMissionCheckBox.IsChecked = state.Device.IsCriticalMission;
            IsFunctionalCheckBox.IsChecked = state.IsFunctional;
            ReviewNotesTextBox.Text = state.ReviewNotes;
            NotesTextBox.Text = state.Device.Notes;
            SIMCardComboBox.SelectedItem = state.Device.MobileDevices.FirstOrDefault()?.SIMCard;
        }

        private State? LoadState()
        {
            if (_device is OpticalReader opticalReader)
            {
                var state = _deviceService.GetStateByDevice(opticalReader.Device.Id);
                _assignment = _deviceService.GetAssignmentByState(state!.Id);
                return state;
            }
            else if (_device is MobileDevice mobileDevice)
            {
                var state = _deviceService.GetStateByDevice(mobileDevice.Device.Id);
                _assignment = _deviceService.GetAssignmentByState(state!.Id);
                return state;
            }
            return null;
        }

        private void LoadSIMCards()
        {
            var simCards = _deviceService.GetSIMCards();
            simCards = simCards.Where(sc => (sc.MobileDevices == null || sc.MobileDevices.Count == 0) || (_device is MobileDevice mobileDevice && sc.Id == mobileDevice.SIMCardId)).ToList();
            if (simCards.IsNullOrEmpty())
            {
                return;
            }
            simCards.Add(new SIMCard { Id = InvalidId });
            SIMCardLabel.Visibility = Visibility.Visible;
            SIMCardComboBox.Visibility = Visibility.Visible;
            SIMCardComboBox.ItemsSource = simCards;
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AreaComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AreaComboBox.SelectedItem is Area area)
            {
                var workCenters = _workCenterService.GetWorkCentersByArea(area.Id);
                if (workCenters.IsNullOrEmpty())
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                WorkCenterComboBox.ItemsSource = workCenters;
                BusinessProcessComboBox.ItemsSource = null;
                CostCenterComboBox.ItemsSource = null;
            }
        }

        private void WorkCenterComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WorkCenterComboBox.SelectedItem is WorkCenter workCenter)
            {
                BusinessProcessComboBox.ItemsSource = workCenter.WorkCenterBusinessProcesses;
                CostCenterComboBox.ItemsSource = workCenter.WorkCenterCostCenters;
            }
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
                var device = UpdateDevice();
                if (_isEditWindow)
                {
                    EditDevice(device!);
                }
                else
                {
                    CreateDevice(device!);
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
            return string.IsNullOrEmpty(InventoryNumberTextBox.Text) || string.IsNullOrEmpty(SerialNumberTextBox.Text) || AreaComboBox.SelectedItem == null || WorkCenterComboBox.SelectedItem == null || CostCenterComboBox.SelectedItem == null || BusinessProcessComboBox.SelectedItem == null || (HasFailuresCheckBox.IsChecked == true && string.IsNullOrEmpty(FailuresDescriptionTextBox.Text)) || string.IsNullOrEmpty(ReviewNotesTextBox.Text) || string.IsNullOrEmpty(NotesTextBox.Text);
        }

        private object? UpdateDevice()
        {
            var state = GetState();
            if (_device is OpticalReader opticalReader)
            {
                opticalReader = UpdateOpticalReader(opticalReader, state);
                return opticalReader;
            }
            else if (_device is MobileDevice mobileDevice)
            {
                mobileDevice = UpdateMobileDevice(mobileDevice, state);
                return mobileDevice;
            }
            else
            {
                var device = GetDevice(state);
                return _deviceType switch
                {
                    DeviceType.OpticalReader => new OpticalReader { Device = device },
                    DeviceType.PortableTerminal or DeviceType.Tablet => new MobileDevice
                    {
                        TypeId = (int)_deviceType,
                        Device = device,
                        SIMCard = (SIMCard)SIMCardComboBox.SelectedItem
                    },
                    _ => throw new Exception()
                };
            }
        }

        private State GetState()
        {
            return new State
            {
                HasFailures = HasFailuresCheckBox.IsChecked == true,
                FailuresDescription = FailuresDescriptionTextBox.Text,
                RequiresMaintenance = RequiresMaintenanceCheckBox.IsChecked == true,
                IsFunctional = IsFunctionalCheckBox.IsChecked == true,
                ReviewNotes = ReviewNotesTextBox.Text,
                WorkCenterBusinessProcess = (WorkCenterBusinessProcess)BusinessProcessComboBox.SelectedItem,
                WorkCenterCostCenter = (WorkCenterCostCenter)CostCenterComboBox.SelectedItem
            };
        }

        private OpticalReader UpdateOpticalReader(OpticalReader opticalReader, State state)
        {
            opticalReader.Device.InventoryNumber = InventoryNumberTextBox.Text;
            opticalReader.Device.SerialNumber = SerialNumberTextBox.Text;
            opticalReader.Device.IsCriticalMission = IsCriticalMissionCheckBox.IsChecked == true;
            opticalReader.Device.Notes = NotesTextBox.Text;
            opticalReader.Device.WorkCenter = (WorkCenter)WorkCenterComboBox.SelectedItem;
            opticalReader.Device.States.Add(state);
            return opticalReader;
        }

        private MobileDevice UpdateMobileDevice(MobileDevice mobileDevice, State state)
        {
            mobileDevice.Device.InventoryNumber = InventoryNumberTextBox.Text;
            mobileDevice.Device.SerialNumber = SerialNumberTextBox.Text;
            mobileDevice.Device.IsCriticalMission = IsCriticalMissionCheckBox.IsChecked == true;
            mobileDevice.Device.Notes = NotesTextBox.Text;
            mobileDevice.Device.WorkCenter = (WorkCenter)WorkCenterComboBox.SelectedItem;
            mobileDevice.Device.States.Add(state);
            mobileDevice.SIMCard = GetSIMCard();
            return mobileDevice;
        }

        private SIMCard? GetSIMCard()
        {
            if (SIMCardComboBox.SelectedItem is SIMCard simCard)
            {
                return simCard.Id == InvalidId ? null : simCard;
            }
            return null;
        }

        private Device GetDevice(State state)
        {
            return new Device
            {
                InventoryNumber = InventoryNumberTextBox.Text,
                SerialNumber = SerialNumberTextBox.Text,
                IsCriticalMission = IsCriticalMissionCheckBox.IsChecked == true,
                Notes = NotesTextBox.Text,
                WorkCenter = (WorkCenter)WorkCenterComboBox.SelectedItem,
                States = [state]
            };
        }

        private void EditDevice(object device)
        {
            bool isEdited = device switch
            {
                OpticalReader opticalReader => _deviceService.EditOpticalReader(opticalReader),
                MobileDevice mobileDevice => _deviceService.EditMobileDevice(mobileDevice),
                _ => false
            };
            if (isEdited)
            {
                if (_assignment != null) EditAssignment(device);
                ShowInformation(Strings.InformationEditedMessage, Strings.InformationEditedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void EditAssignment(object device)
        {
            if (device is OpticalReader opticalReader)
            {
                _assignment!.AssignmentState = opticalReader.Device.States.Last();
            }
            else if (device is MobileDevice mobileDevice)
            {
                _assignment!.AssignmentState = mobileDevice.Device.States.Last();
            }
            _deviceService.EditAssignment(_assignment!);
        }

        private static void ShowInformation(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateDevice(object device)
        {
            bool isCreated= device switch
            {
                OpticalReader opticalReader => _deviceService.CreateOpticalReader(opticalReader),
                MobileDevice mobileDevice => _deviceService.CreateMobileDevice(mobileDevice),
                _ => false
            };
            if (isCreated)
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