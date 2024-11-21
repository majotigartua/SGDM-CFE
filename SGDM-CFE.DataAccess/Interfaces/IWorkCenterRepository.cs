using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IWorkCenterRepository
    {
        bool Add(WorkCenter workCenter);
        bool Delete(WorkCenter workCenter);
        List<WorkCenter> GetAll();
        List<WorkCenter> GetByArea(int areaId);
        bool Update(WorkCenter workCenter);
    }
}