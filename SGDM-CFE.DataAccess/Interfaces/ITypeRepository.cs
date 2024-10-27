using SGDM_CFE.Model.Models;
using Type = SGDM_CFE.Model.Models.Type;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface ITypeRepository
    {
        List<Type> GetAll();
        Type? GetById(int id);
        Type? GetByMobileDevice(MobileDevice mobileDevice);
    }
}