using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IBusinessProcessRepository
    {
        List<BusinessProcess> GetAll();
        BusinessProcess GetById(int id);
        List<BusinessProcess> GetByWorkCenter(WorkCenter workCenter);
    }
}