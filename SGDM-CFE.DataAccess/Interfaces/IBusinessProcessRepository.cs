using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IBusinessProcessRepository
    {
        IEnumerable<BusinessProcess> GetAll();
        BusinessProcess GetByDevice(Device device);
        BusinessProcess GetById(int id);
        IEnumerable<BusinessProcess> GetByWorkCenter(WorkCenter workCenter);
    }
}