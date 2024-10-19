using SGDM_CFE.Model;
using System.Collections.Generic;
using Type = SGDM_CFE.Model.Type;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ITypeRepository
    {
        IEnumerable<Type> GetAll();
        Type GetById(int id);
        Type GetByMobileDevice(MobileDevice mobileDevice);
    }
}