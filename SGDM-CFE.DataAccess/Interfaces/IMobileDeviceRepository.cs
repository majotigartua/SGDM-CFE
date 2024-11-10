using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IMobileDeviceRepository
    {
        bool Add(MobileDevice mobileDevice);
        bool Delete(int mobileDeviceId);
        List<MobileDevice> GetAll();
        MobileDevice? GetByDevice(int deviceId);
        MobileDevice? GetById(int id);
        MobileDevice? GetBySIMCard(int simCardId);
        List<MobileDevice> GetByType(int typeId);
        bool Update(MobileDevice mobileDevice);
    }
}