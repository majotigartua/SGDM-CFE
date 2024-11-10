using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ISIMCardRepository
    {
        bool Add(SIMCard simCard);
        bool Delete(int simCardId);
        List<SIMCard> GetAll();
        SIMCard? GetById(int id);
        SIMCard? GetByMobileDevice(int mobileDeviceId);
        bool Update(SIMCard simCard);
    }
}