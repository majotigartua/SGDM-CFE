using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class WorkCenterRepositoryTests
    {
        private readonly Context _context;
        private readonly WorkCenterRepository _workCenterRepository;

        public WorkCenterRepositoryTests()
        {
            _context = new Context();
            _workCenterRepository = new WorkCenterRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var workCenter = new WorkCenter()
            {
                Code = "123456",
                Name = "Test",
                AreaId = 1
            };
            var result = _workCenterRepository.Add(workCenter);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var workCenter = _context.WorkCenters.First();
            var result = _workCenterRepository.Delete(workCenter);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var workCenters = _workCenterRepository.GetAll();
            Assert.NotNull(workCenters);
        }

        [Fact]
        public void GetByArea()
        {
            var area = _context.Areas.First();
            int areaId = area.Id;
            var workCenters = _workCenterRepository.GetByArea(areaId);
            Assert.NotNull(workCenters);
            Assert.Contains(workCenters, wc => wc.AreaId == area.Id);
        }

        [Fact]
        public void Update()
        {
            var workCenter = _context.WorkCenters.First();
            workCenter.Code = "123456";
            workCenter.Name = "Test";
            workCenter.AreaId = 1;
            var result = _workCenterRepository.Update(workCenter);
            Assert.True(result);
        }
    }
}