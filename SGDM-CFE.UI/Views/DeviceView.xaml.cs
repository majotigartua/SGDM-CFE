using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Views
{
    public partial class DeviceView : UserControl
    {
        private readonly Context _context;
        private readonly DeviceType _deviceType;

        public DeviceView(Context context, DeviceType deviceType)
        {
            _context= context;
            _deviceType = deviceType;
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void GenerateReportButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}