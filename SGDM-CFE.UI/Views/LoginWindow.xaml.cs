using SGDM_CFE.BusinessLogic.Services;
using System.Windows;

namespace SGDM_CFE.UI
{
    public partial class LoginWindow : Window
    {
        private readonly WorkCenterService _workCenterService;

        public LoginWindow()
        {
            InitializeComponent();
            _workCenterService = new WorkCenterService();
            MessageBox.Show(_workCenterService.GetAll().ToString());
        }
    }
}