using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class EmployeeService(Context context) : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository = new(context);
        private readonly RoleRepository _roleRepository = new(context);
        private readonly UserRepository _userRepository = new(context);

        public Employee? Login(string rpe, string password)
        {
            var employee = _employeeRepository.GetByRPE(rpe);
            if (employee == null) return null;
            var user = _userRepository.GetByEmployee(employee);
            if (user == null || user.Password != password) return null;
            var role = _roleRepository.GetByUser(user);
            if (role == null) return null;
            user.Role = role;
            employee.User = user;
            return employee;
        }
    }
}