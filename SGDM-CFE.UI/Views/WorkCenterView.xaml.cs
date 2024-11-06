﻿using SGDM_CFE.BusinessLogic.Services;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCenterView : UserControl
    {
        private readonly ContextService _contextService;

        public WorkCenterView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }
    }
}