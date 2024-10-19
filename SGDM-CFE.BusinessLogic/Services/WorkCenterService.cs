using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class WorkCenterService : IWorkCenterService
    {
        private readonly AreaRepository _areaRepository;

        public WorkCenterService()
        {
            _areaRepository = new AreaRepository();
        }

        public IEnumerable<Area> GetAll()
        {
            return _areaRepository.GetAll();
        }
    }
}