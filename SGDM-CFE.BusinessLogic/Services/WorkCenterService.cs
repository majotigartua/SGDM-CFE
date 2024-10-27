using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class WorkCenterService : IWorkCenterService
    {
        private readonly AreaRepository _areaRepository;
        private readonly BusinessProcessRepository _businessProcessRepository;
        private readonly CostCenterRepository _costCenterRepository;
        private readonly WorkCenterRepository _workCenterRepository;

        public WorkCenterService(Context context)
        {
            _areaRepository = new AreaRepository(context);
            _businessProcessRepository = new BusinessProcessRepository(context);
            _costCenterRepository = new CostCenterRepository(context);
            _workCenterRepository = new WorkCenterRepository(context);
        }
    }
}