using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserRepository _userRepository;

        public EmployeeService(Context context)
        {
            _employeeRepository = new EmployeeRepository(context);
            _roleRepository = new RoleRepository(context);
            _userRepository = new UserRepository(context);
        }
    }
}