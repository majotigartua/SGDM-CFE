﻿using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using SGDM_CFE.UI.Resources;
using System.Windows;

namespace SGDM_CFE.UI.Windows
{
    public partial class WorkCenterWindow : Window
    { 
        private readonly Context _context;
        private readonly bool _isEditWindow;
        private readonly WorkCenter _workCenter;

        public WorkCenterWindow(Context context, bool isEditWindow, WorkCenter workCenter)
        {
            _context = context;
            _isEditWindow = isEditWindow;
            _workCenter = workCenter;
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