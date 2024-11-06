using SGDM_CFE.BusinessLogic.Services;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class StartPanelView : UserControl
    {
        private readonly ContextService _contextService;

        public StartPanelView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }
    }
}