using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    internal class CostCenterRepository : ICostCenterRepository
    {
        public IEnumerable<CostCenter> GetAll()
        {
            throw new NotImplementedException();
        }

        public CostCenter GetByDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public CostCenter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CostCenter> GetByWorkCenter(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }
    }
}