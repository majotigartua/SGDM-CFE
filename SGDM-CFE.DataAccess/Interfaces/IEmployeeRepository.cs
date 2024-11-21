using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        bool Delete(Employee employee);
        List<Employee> GetAll();
        Employee? GetByRPE(string rpe);
        bool Update(Employee employee);
    }
}