using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class CostCenterRepositoryTests
    {
        private readonly Context _context;
        private readonly CostCenterRepository costCenterRepository;

        public CostCenterRepositoryTests()
        {
            _context = new Context();
            costCenterRepository = new CostCenterRepository(_context);
        }

        [Fact]
        public void GetAll()
        {
            var costCenters = costCenterRepository.GetAll();
            Assert.NotEmpty(costCenters);
        }
    }
}