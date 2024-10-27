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

        [Fact]
        public void GetById()
        {
            int areaId = 1;
            var area = _areaRepository.GetById(areaId);
            Assert.NotNull(area);
            Assert.Equal(areaId, area.Id);
        }

        [Fact]
        public void GetByWorkCenter()
        {
            var workCenter = _context.WorkCenters.First();
            int workCenterId = workCenter.Id;
            var area = _areaRepository.GetByWorkCenter(workCenter);
            Assert.NotNull(area);
            Assert.Contains(area.WorkCenters, wc => wc.Id == workCenterId);
        }
    }
}