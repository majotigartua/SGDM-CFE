﻿using Microsoft.IdentityModel.Tokens;
using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class UserWindow : Window
    {
        private readonly EmployeeService _employeeService;
        private readonly Employee _employee;
        private readonly User? _user;
        private readonly bool _isEditWindow;

        public UserWindow(Context context, Employee employee, bool isEditWindow)
        {
            _employeeService = new EmployeeService(context);
            _employee = employee;
            _user = employee?.User ?? new User();
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            try
            {
                var roles = _employeeService.GetRoles();
                if (roles.IsNullOrEmpty())
                {
                    ShowWarning(Strings.NoRecordsMessage, Strings.NoRecordsWindowTitle);
                    return;
                }
                RoleComboBox.ItemsSource = roles;
                if (_isEditWindow) PopulateFields();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void PopulateFields()
        {
            EmailTextBox.Text = _user?.Email;
            RoleComboBox.SelectedItem = _user?.Role;
            RoleComboBox.IsEnabled = false;
        }

        private static void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private static void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!AreFieldsFilled())
                {
                    ShowWarning(Strings.EmptyFieldsMessage, Strings.EmptyFieldsWindowTitle);
                    return;
                }
                UpdateUser();
                if (_isEditWindow)
                {
                    EditUser();
                }
                else
                {
                    CreateUser();
                }
                Close();
            }
            catch (Exception)
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private bool AreFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(EmailTextBox.Text) && RoleComboBox.SelectedItem != null;
        }

        private void UpdateUser()
        {
            var password = PasswordBox.Password;
            var passwordConfirmation = PasswordConfirmationBox.Password;
            if (password != passwordConfirmation)
            {
                ShowWarning(Strings.IncorrectInformationMessage, Strings.IncorrectInformationWindowTitle);
                return;
            }
            if (_isEditWindow && string.IsNullOrWhiteSpace(password))
            {
                password = _user!.Password;
            }
            else
            {
                password = Utilities.ComputeSHA256Hash(password);
            }
            _user!.Email = EmailTextBox.Text;
            _user.Password = password;
            _user.Role = (Role)RoleComboBox.SelectedItem!;
            if (!_user.Employees.Contains(_employee)) _user?.Employees.Add(_employee);
        }

        private void EditUser()
        {
            if (_employeeService.EditUser(_user!))
            {
                ShowInformation(Strings.InformationEditedMessage, Strings.InformationEditedWindowTitle);
            }
            else
            {
                ShowError(Strings.ConnectionErrorMessage, Strings.ConnectionErrorWindowTitle);
            }
        }

        private void CreateUser()
        {
            if (_employeeService.CreateUser(_user!))
            {
                ShowInformation(Strings.InformationCreatedMessage, Strings.InformationCreatedWindowTitle);
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

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}