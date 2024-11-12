using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        List<Role> GetRoles();
        Employee? Login(string rpe, string password);
    }
}