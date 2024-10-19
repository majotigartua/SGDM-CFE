using SGDM_CFE.Model;
using System;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public class WorkCenterRepository : IWorkCenterRepository
    {
        public void Add(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }

        public void Delete(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkCenter> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkCenter> GetByArea(Area area)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkCenter> GetByBusinessProcess(BusinessProcess businessProcess)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkCenter> GetByCostCenter(CostCenter costCenter)
        {
            throw new NotImplementedException();
        }

        public WorkCenter GetByDevice(Device device)
        {
            throw new NotImplementedException();
        }

        public WorkCenter GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }
    }
}