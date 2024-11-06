using SGDM_CFE.BusinessLogic.Services;
using SGDM_CFE.UI.Resources;
using SGDM_CFE.UI.Windows;
using System.Windows;
using System.Windows.Controls;
using static SGDM_CFE.UI.Resources.Constants;

namespace SGDM_CFE.UI.Views
{
    public partial class DevicesView : UserControl
    {
        private readonly ContextService _contextService;
        private readonly DeviceType _deviceType;

        public DevicesView(ContextService contextService, DeviceType deviceType)
        {
            _contextService = contextService;
            _deviceType = deviceType;
            InitializeComponent();
            ConfigureWindow();
        }

        private void ConfigureWindow()
        {
            TitleLabel.Content = GetViewTitle();
        }

        private string GetViewTitle()
        {
            return _deviceType switch
            {
                DeviceType.OpticalReader => Strings.OpticalReadersLabel,
                DeviceType.PortableTerminal => Strings.PortableTerminalsLabel,
                DeviceType.Tablet => Strings.TabletsLabel,
                _ => throw new Exception(),
            };
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            DeviceWindow? editWindow = _deviceType switch
            {
                DeviceType.OpticalReader => new DeviceWindow(_contextService, DeviceType.OpticalReader, isEditWindow: true),
                DeviceType.PortableTerminal => new DeviceWindow(_contextService, DeviceType.PortableTerminal, isEditWindow: true),
                DeviceType.Tablet => new DeviceWindow(_contextService, DeviceType.Tablet, isEditWindow: true),
                _ => throw new Exception(),
            };
            editWindow?.ShowDialog();
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
        }

        private void CreateNewButtonClick(object sender, RoutedEventArgs e)
        {
            DeviceWindow? createWindow = _deviceType switch
            {
                DeviceType.OpticalReader => new DeviceWindow(_contextService, DeviceType.OpticalReader, isEditWindow: false),
                DeviceType.PortableTerminal => new DeviceWindow(_contextService, DeviceType.PortableTerminal, isEditWindow: false),
                DeviceType.Tablet => new DeviceWindow(_contextService, DeviceType.Tablet, isEditWindow: false),
                _ => throw new Exception(),
            };
            createWindow?.ShowDialog();
        }

        private void ViewDetailsButtonClick(object sender, RoutedEventArgs e)
        {
        }
    }
}