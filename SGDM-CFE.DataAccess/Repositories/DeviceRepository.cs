using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        public void Add(Device device)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Device device)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Device> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Device> GetByBusinessProcess(BusinessProcess businessProcess)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Device> GetByCostCenter(CostCenter costCenter)
        {
            throw new System.NotImplementedException();
        }

        public Device GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Device GetByMobileDevice(MobileDevice mobileDevice)
        {
            throw new System.NotImplementedException();
        }

        public Device GetByOpticalReader(OpticalReader opticalReader)
        {
            throw new System.NotImplementedException();
        }

        public Device GetByState(State state)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Device> GetByWorkCenter(WorkCenter workCenter)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Device device)
        {
            throw new System.NotImplementedException();
        }
    }
}