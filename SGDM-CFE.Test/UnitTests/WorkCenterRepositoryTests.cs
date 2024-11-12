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
            int workCenterId = workCenter.Id;
            var result = _workCenterRepository.Delete(workCenterId);
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
        public void GetByBusinessProcess()
        {
            var businessProcess = _context.BusinessProcesses.First();
            int businessProcessId = businessProcess.Id;
            var workCenters = _workCenterRepository.GetByBusinessProcess(businessProcessId);
            Assert.NotEmpty(workCenters);
            Assert.All(workCenters, wc => Assert.Contains(wc.WorkCenterBusinessProcesses, wcbp => wcbp.BusinessProcessId == businessProcessId));
        }

        [Fact]
        public void GetByCostCenter()
        {
            var costCenter = _context.CostCenters.First();
            int costCenterId = costCenter.Id;
            var workCenters = _workCenterRepository.GetByCostCenter(costCenterId);
            Assert.NotEmpty(workCenters);
            Assert.All(workCenters, wc => Assert.Contains(wc.WorkCenterCostCenters, wccc => wccc.CostCenterId == costCenterId));
        }

        [Fact]
        public void GetById()
        {
            int workCenterId = 1;
            var workCenter = _workCenterRepository.GetById(workCenterId);
            Assert.NotNull(workCenter);
            Assert.Equal(workCenter.Id, workCenterId);
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