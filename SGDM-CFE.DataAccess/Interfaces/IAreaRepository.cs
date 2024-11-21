using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAreaRepository
    {
        List<Area> GetAll();
    }
}