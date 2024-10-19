using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ISIMCardRepository
    {
        void Add(SIMCard simCard);
        void Delete(SIMCard simCard);
        IEnumerable<SIMCard> GetAll();
        SIMCard GetById(int id);
        SIMCard GetByMobileDevice(MobileDevice mobileDevice);
        void Update(SIMCard simCard);
    }
}