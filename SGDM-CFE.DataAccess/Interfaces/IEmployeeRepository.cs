using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(Employee employee);
        IEnumerable<Employee> GetAll();
        Employee GetByAssignment(Assignment assignment);
        Employee GetById(int id);
        Employee GetByUser(User user);
        void Update(Employee employee);
    }
}