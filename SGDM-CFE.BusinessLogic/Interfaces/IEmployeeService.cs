using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        bool CreateEmployee(Employee employee);
        bool CreateUser(User user);
        bool EditEmployee(Employee employee);
        bool EditUser(User user);
        List<Employee> GetEmployees();
        List<Role> GetRoles();
        Employee? Login(string rpe, string password);
    }
}