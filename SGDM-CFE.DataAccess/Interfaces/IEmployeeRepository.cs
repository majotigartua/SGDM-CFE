using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        bool Delete(Employee employee);
        List<Employee> GetAll();
        Employee GetByAssignment(Assignment assignment);
        Employee GetById(int id);
        Employee GetByUser(User user);
        bool Update(Employee employee);
    }
}