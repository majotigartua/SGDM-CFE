using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IEmployeeRepository
    {
        bool Add(Employee employee);
        bool Delete(int employeeId);
        List<Employee> GetAll();
        Employee? GetByAssignment(int assignmentId);
        Employee? GetById(int id);
        Employee? GetByRPE(string rpe);
        Employee? GetByUser(int userId);
        bool Update(Employee employee);
    }
}