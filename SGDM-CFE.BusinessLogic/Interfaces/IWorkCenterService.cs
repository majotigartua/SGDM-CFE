using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IWorkCenterService
    {
        List<Area> GetAreas();
        List<WorkCenter> GetWorkCenters();
    }
}