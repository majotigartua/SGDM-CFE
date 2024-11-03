using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class TabletsView : UserControl
    {
        private readonly Context _context;

        public TabletsView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}