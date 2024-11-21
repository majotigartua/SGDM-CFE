using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IWorkCenterService
    {
        bool CreateWorkCenter(WorkCenter workCenter);
        bool EditWorkCenter(WorkCenter workCenter);
        bool DeleteWorkCenter(WorkCenter workCenter);
        List<Area> GetAreas();
        List<BusinessProcess> GetBusinessProcesses();
        List<CostCenter> GetCostCenters();
        List<WorkCenter> GetWorkCenters();
        List<WorkCenter> GetWorkCentersByArea(int areaId);
    }
}