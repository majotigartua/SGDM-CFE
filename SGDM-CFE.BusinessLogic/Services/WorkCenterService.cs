using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class WorkCenterService(Context context) : IWorkCenterService
    {
        private readonly AreaRepository _areaRepository = new(context);
        private readonly BusinessProcessRepository _businessProcessRepository = new(context);
        private readonly CostCenterRepository _costCenterRepository = new(context);
        private readonly WorkCenterRepository _workCenterRepository = new(context);

        public bool CreateWorkCenter(WorkCenter workCenter)
        {
            return _workCenterRepository.Add(workCenter);
        }

        public bool DeleteWorkCenter(WorkCenter workCenter)
        {
            return _workCenterRepository.Delete(workCenter);
        }

        public bool EditWorkCenter(WorkCenter workCenter)
        {
            return _workCenterRepository.Update(workCenter);
        }

        public List<Area> GetAreas()
        {
            return _areaRepository.GetAll();
        }

        public List<BusinessProcess> GetBusinessProcesses()
        {
            return _businessProcessRepository.GetAll();
        }

        public List<CostCenter> GetCostCenters()
        {
            return _costCenterRepository.GetAll();
        }

        public List<WorkCenter> GetWorkCenters()
        {
            return _workCenterRepository.GetAll();
        }

        public List<WorkCenter> GetWorkCentersByArea(int areaId)
        {
            return _workCenterRepository.GetByArea(areaId);
        }
    }
}