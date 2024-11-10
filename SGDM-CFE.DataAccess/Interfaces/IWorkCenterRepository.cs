using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IWorkCenterRepository
    {
        bool Add(WorkCenter workCenter);
        bool Delete(int workCenterId);
        List<WorkCenter> GetAll();
        List<WorkCenter> GetByArea(int areaId);
        List<WorkCenter> GetByBusinessProcess(int businessProcessId);
        List<WorkCenter> GetByCostCenter(int costCenterId);
        WorkCenter? GetById(int id);
        bool Update(WorkCenter workCenter);
    }
}