﻿using SGDM_CFE.Model;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class SIMCardWindow : Window
    {
        private readonly Context _context;
        private readonly bool _isEditWindow;

        public SIMCardWindow(Context context, bool isEditWindow)
        {
            _context = context;
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