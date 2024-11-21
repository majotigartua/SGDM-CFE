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