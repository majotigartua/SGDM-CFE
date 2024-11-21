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
    }
}