using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class EmployeeRepositoryTests
    {
        private readonly Context _context;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeRepositoryTests()
        {
            _context = new Context();
            _employeeRepository = new EmployeeRepository(_context);

        }

        [Fact]
        public void Add()
        {
            var employee = new Employee
            {
                Name = "Test",
                PaternalSurname = "Test",
                MaternalSurname = "Test",
                RPE = "123456",
                UserId = 1
            };
            var result = _employeeRepository.Add(employee);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var employee = _context.Employees.First();
            var result = _employeeRepository.Delete(employee);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var employees = _employeeRepository.GetAll();
            Assert.NotEmpty(employees);
        }

        [Fact]
        public void Update()
        {
            var employee = _context.Employees.First();
            employee.Name = "Test";
            employee.PaternalSurname = "Test";
            employee.MaternalSurname = "Test";
            employee.RPE = "123456";
            employee.UserId = 1;
            var result = _employeeRepository.Update(employee);
            Assert.True(result);
        }
    }
}