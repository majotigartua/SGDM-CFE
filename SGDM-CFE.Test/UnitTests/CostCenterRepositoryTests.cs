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

        [Fact]
        public void GetById()
        {
            int costCenterId = 1;
            var costCenter = costCenterRepository.GetById(costCenterId);
            Assert.NotNull(costCenter);
            Assert.Equal(costCenter.Id, costCenterId);
        }

        [Fact]
        public void GetByWorkCenter()
        {
            var workCenter = _context.WorkCenters.First();
            int workCenterId = workCenter.Id;
            var costCenters = costCenterRepository.GetByWorkCenter(workCenter);
            Assert.NotEmpty(costCenters);
            Assert.All(costCenters, cc => Assert.Contains(cc.WorkCenterCostCenters, wccc => wccc.WorkCenterId == workCenterId));
        }
    }
}