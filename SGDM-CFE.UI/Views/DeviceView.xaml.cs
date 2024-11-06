using SGDM_CFE.BusinessLogic.Services;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class DeviceView : UserControl
    {
        private readonly ContextService _contextService;

        public DeviceView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }
    }
}