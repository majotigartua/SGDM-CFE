using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        bool Add(User user);
        bool Delete(int userId);
        List<User> GetAll();
        User? GetById(int id);
        User? GetByEmployee(int employeeId);
        List<User> GetByRole(int roleId);
        bool Update(User user);
    }
}