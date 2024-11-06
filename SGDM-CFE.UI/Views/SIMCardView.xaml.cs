using SGDM_CFE.BusinessLogic.Services;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class SIMCardView : UserControl
    {
        private readonly ContextService _contextService;

        public SIMCardView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }
    }
}
