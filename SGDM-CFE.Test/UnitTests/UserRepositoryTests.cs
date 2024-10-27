using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class UserRepositoryTests
    {
        private readonly Context _context;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _context = new Context();
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var user = new User()
            {
                Email = "Test",
                Password = "Test",
                RoleId = 1
            };
            var result = _userRepository.Add(user);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var user = _context.Users.First();
            var result = _userRepository.Delete(user);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var users = _userRepository.GetAll();
            Assert.NotNull(users);
        }

        [Fact]
        public void GetByEmployee()
        {
            var employee = _context.Employees.First();
            var user = _userRepository.GetByEmployee(employee);
            Assert.NotNull(user);
            Assert.Contains(user.Employees, e => e.Id == employee.Id);
        }

        [Fact]
        public void GetById()
        {
            int userId = 1;
            var user = _userRepository.GetById(userId);
            Assert.NotNull(user);
            Assert.Equal(user.Id, userId);
        }

        [Fact]
        public void GetByRole()
        {
            var role = _context.Roles.First();
            var users = _userRepository.GetByRole(role);
            Assert.NotEmpty(users);
            Assert.All(users, u => Assert.Equal(u.RoleId, role.Id));
        }

        [Fact]
        public void Update()
        {
            var user = _context.Users.First();
            user.Email = "Test";
            user.Password = "Test";
            user.RoleId = 1;
            var result = _userRepository.Update(user);
            Assert.True(result);
        }
    }
}