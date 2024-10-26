using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IWorkCenterRepository
    {
        bool Add(WorkCenter workCenter);
        bool Delete(WorkCenter workCenter);
        List<WorkCenter> GetAll();
        List<WorkCenter> GetByArea(Area area);
        List<WorkCenter> GetByBusinessProcess(BusinessProcess businessProcess);
        List<WorkCenter> GetByCostCenter(CostCenter costCenter);
        WorkCenter GetById(int id);
        bool Update(WorkCenter workCenter);
    }
}