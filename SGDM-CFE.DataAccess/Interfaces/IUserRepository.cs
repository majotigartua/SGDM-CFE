using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        bool Add(User user);
        bool Update(User user);
    }
}