using SGDM_CFE.Model;
using System.Collections.Generic;
using Type = SGDM_CFE.Model.Type;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IMobileDeviceRepository
    {
        void Add(MobileDevice mobileDevice);
        void Delete(MobileDevice mobileDevice);
        IEnumerable<MobileDevice> GetAll();
        MobileDevice GetByDevice(Device device);
        MobileDevice GetById(int id);
        MobileDevice GetBySIMCard(SIMCard simCard);
        IEnumerable<MobileDevice> GetByType(Type type);
        void Update(MobileDevice mobileDevice);
    }
}