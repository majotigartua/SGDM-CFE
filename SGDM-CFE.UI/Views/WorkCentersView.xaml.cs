using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class WorkCentersView : UserControl
    {
        private readonly Context _context;

        public WorkCentersView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}