using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class OpticalReadersView : UserControl
    {
        private readonly Context _context;

        public OpticalReadersView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}