using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IWorkCenterService
    {
        IEnumerable<Area> GetAll();
    }
}