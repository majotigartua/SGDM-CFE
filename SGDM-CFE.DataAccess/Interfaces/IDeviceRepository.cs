using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IDeviceRepository
    {
        bool Add(Device device);
        bool Delete(int deviceId);
        List<Device> GetAll();
        Device? GetById(int id);
        Device? GetByMobileDevice(int mobileDeviceId);
        Device? GetByOpticalReader(int opticalReaderId);
        Device? GetByState(int stateId);
        List<Device> GetByWorkCenter(int workCenterId);
        bool Update(Device device);
    }
}