using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class PortableTerminalsView : UserControl
    {
        private readonly Context _context;

        public PortableTerminalsView(Context context)
        {
            InitializeComponent();
            _context = context;
        }
    }
}