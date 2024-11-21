using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ICostCenterRepository
    {
        List<CostCenter> GetAll();
    }
}