using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IDeviceRepository
    {
        List<Device> GetByWorkCenter(int workCenterId);
    }
}