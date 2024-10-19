using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IDeviceRepository
    {
        void Add(Device device);
        void Delete(Device device);
        IEnumerable<Device> GetAll();
        Device GetById(int id);
        IEnumerable<Device> GetByBusinessProcess(BusinessProcess businessProcess);
        IEnumerable<Device> GetByCostCenter(CostCenter costCenter);
        Device GetByMobileDevice(MobileDevice mobileDevice);
        Device GetByOpticalReader(OpticalReader opticalReader);
        Device GetByState(State state);
        void Update(Device device);
        IEnumerable<Device> GetByWorkCenter(WorkCenter workCenter);
    }
}