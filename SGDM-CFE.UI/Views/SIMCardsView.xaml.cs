using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class SIMCardsView : UserControl
    {
        private readonly Context _context;

        public SIMCardsView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}