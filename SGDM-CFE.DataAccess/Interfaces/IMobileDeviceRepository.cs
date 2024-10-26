using SGDM_CFE.Model.Models;
using Type = SGDM_CFE.Model.Models.Type;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IMobileDeviceRepository
    {
        bool Add(MobileDevice mobileDevice);
        bool Delete(MobileDevice mobileDevice);
        List<MobileDevice> GetAll();
        MobileDevice GetByDevice(Device device);
        MobileDevice GetById(int id);
        MobileDevice GetBySIMCard(SIMCard simCard);
        MobileDevice GetByType(Type type);
        bool Update(MobileDevice mobileDevice);
    }
}