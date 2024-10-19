using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;
using Type = SGDM_CFE.Model.Type;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class MobileDeviceRepository : IMobileDeviceRepository
    {
        public void Add(MobileDevice mobileDevice)
        {
            throw new NotImplementedException();
        }

        public void Delete(MobileDevice mobileDevice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MobileDevice> GetAll()
        {
            throw new NotImplementedException();
        }

        public MobileDevice GetByDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public MobileDevice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public MobileDevice GetBySIMCard(SIMCard simCard)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MobileDevice> GetByType(Type type)
        {
            throw new NotImplementedException();
        }

        public void Update(MobileDevice mobileDevice)
        {
            throw new NotImplementedException();
        }
    }
}