﻿using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class SIMCardWindow : Window
    {
        private readonly ContextService _contextService;
        private readonly bool _isEditWindow;

        public SIMCardWindow(ContextService contextService, bool isEditWindow)
        {
            _contextService = contextService;
            _isEditWindow = isEditWindow;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            Title = _isEditWindow ? Strings.EditSIMCardWindowTitle : Strings.CreateSIMCardWindowTitle;
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