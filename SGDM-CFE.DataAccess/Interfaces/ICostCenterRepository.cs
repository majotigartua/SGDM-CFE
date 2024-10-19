using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ICostCenterRepository
    {
        IEnumerable<CostCenter> GetAll();
        CostCenter GetByDevice(Device device);
        CostCenter GetById(int id);
        IEnumerable<CostCenter> GetByWorkCenter(WorkCenter workCenter);
    }
}