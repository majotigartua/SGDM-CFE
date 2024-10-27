using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class RoleRepositoryTests
    {
        private readonly Context _context;
        private readonly RoleRepository _roleRepository;

        public RoleRepositoryTests()
        {
            _context = new Context();
            _roleRepository = new RoleRepository(_context);
        }

        [Fact]
        public void GetAll()
        {
            var roles = _roleRepository.GetAll();
            Assert.NotEmpty(roles);
        }

        [Fact]
        public void GetById()
        {
            int roleId = 1;
            var role = _roleRepository.GetById(roleId);
            Assert.NotNull(role);
            Assert.Equal(role.Id, roleId);
        }

        [Fact]
        public void GetByUser()
        {
            var user = _context.Users.First();
            int userId = user.Id;
            var role = _roleRepository.GetByUser(user);
            Assert.NotNull(role);
            Assert.Contains(role.Users, u => u.Id == userId);
        }
    }
}