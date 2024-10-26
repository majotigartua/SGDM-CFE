using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        bool Add(User user);
        bool Delete(User user);
        List<User> GetAll();
        User GetById(int id);
        User GetByEmployee(Employee employee);
        List<User> GetByRole(Role role);
        bool Update(User user);
    }
}