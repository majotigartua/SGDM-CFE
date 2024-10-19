using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        IEnumerable<User> GetAll();
        User GetByEmployee(Employee employee);
        User GetById(int id);
        IEnumerable<User> GetByRole(Role role);
        User Login(User user);
        void Update(User user);
    }
}