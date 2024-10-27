using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IDeviceRepository
    {
        bool Add(Device device);
        bool Delete(Device device);
        List<Device> GetAll();
        Device? GetById(int id);
        Device? GetByMobileDevice(MobileDevice mobileDevice);
        Device? GetByOpticalReader(OpticalReader opticalReader);
        Device? GetByState(State state);
        List<Device> GetByWorkCenter(WorkCenter workCenter);
        bool Update(Device device);
    }
}