using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class AreaRepositoryTests
    {
        private readonly Context _context;
        private readonly AreaRepository _areaRepository;

        public AreaRepositoryTests()
        {
            _context = new Context();
            _areaRepository = new AreaRepository(_context);
        }

        [Fact]
        public void GetAll()
        {
            var areas = _areaRepository.GetAll();
            Assert.NotEmpty(areas);
        }
    }
}