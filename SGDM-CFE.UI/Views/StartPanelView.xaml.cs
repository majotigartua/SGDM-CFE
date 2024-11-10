using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class StartPanelView : UserControl
    {
        private readonly Context _context;

        public StartPanelView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}