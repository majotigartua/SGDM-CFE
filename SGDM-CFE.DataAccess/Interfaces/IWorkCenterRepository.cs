using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IWorkCenterRepository
    {
        void Add(WorkCenter workCenter);
        void Delete(WorkCenter workCenter);
        WorkCenter GetById(int id);
        IEnumerable<WorkCenter> GetAll();
        IEnumerable<WorkCenter> GetByArea(Area area);
        IEnumerable<WorkCenter> GetByBusinessProcess(BusinessProcess businessProcess);
        IEnumerable<WorkCenter> GetByCostCenter(CostCenter costCenter);
        WorkCenter GetByDevice(Device device);
        void Update(WorkCenter workCenter);
    }
}