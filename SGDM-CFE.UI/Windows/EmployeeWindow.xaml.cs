﻿using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class EmployeeWindow : Window
    {
        private readonly ContextService _contextService;
        private readonly bool _isEditWindow;

        public EmployeeWindow(ContextService contextService, bool isEditWindow)
        {
            _contextService = contextService;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditEmployeeWindowTitle : Strings.CreateEmployeeWindowTitle;
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