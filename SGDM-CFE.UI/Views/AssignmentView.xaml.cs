using SGDM_CFE.BusinessLogic.Services;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class AssignmentView : UserControl
    {
        private readonly ContextService _contextService;

        public AssignmentView(ContextService contextService)
        {
            _contextService = contextService;
            InitializeComponent();
        }
    }
}