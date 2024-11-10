using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IDeviceService
    {
        List<OpticalReader> GetOpticalReaders();
        List<MobileDevice> GetMobileDevicesByType(int typeId);
        List<SIMCard> GetSIMCards();
    }
}