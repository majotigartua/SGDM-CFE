using SGDM_CFE.Model;
using System.Windows.Controls;

namespace SGDM_CFE.UI.Views
{
    public partial class EmployeesView : UserControl
    {
        private readonly Context _context;

        public EmployeesView(Context context)
        {
            _context = context;
            InitializeComponent();
        }
    }
}