using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ISIMCardRepository
    {
        bool Add(SIMCard simCard);
        bool Delete(SIMCard simCard);
        List<SIMCard> GetAll();
        SIMCard? GetById(int id);
        SIMCard? GetByMobileDevice(MobileDevice mobileDevice);
        bool Update(SIMCard simCard);
    }
}