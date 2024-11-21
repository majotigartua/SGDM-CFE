using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IMobileDeviceRepository
    {
        bool Add(MobileDevice mobileDevice);
        bool Delete(MobileDevice mobileDevice);
        MobileDevice? GetBySIMCard(int simCardId);
        List<MobileDevice> GetByType(int typeId);
        bool Update(MobileDevice mobileDevice);
    }
}