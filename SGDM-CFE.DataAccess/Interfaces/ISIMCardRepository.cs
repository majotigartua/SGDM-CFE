using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ISIMCardRepository
    {
        bool Add(SIMCard simCard);
        bool Delete(SIMCard simCard);
        List<SIMCard> GetAll();
        SIMCard? GetByMobileDevice(int mobileDeviceId);
        bool Update(SIMCard simCard);
    }
}