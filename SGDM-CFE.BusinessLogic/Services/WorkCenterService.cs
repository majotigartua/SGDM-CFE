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

        public List<WorkCenter> GetWorkCenters()
        {
            return _workCenterRepository.GetAll();
        }
    }
}