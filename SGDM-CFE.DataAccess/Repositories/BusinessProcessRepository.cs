using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class BusinessProcessRepository : IBusinessProcessRepository
    {
        public IEnumerable<BusinessProcess> GetAll()
        {
            throw new NotImplementedException();
        }

        public BusinessProcess GetByDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public BusinessProcess GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessProcess> GetByWorkCenter(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }
    }
}