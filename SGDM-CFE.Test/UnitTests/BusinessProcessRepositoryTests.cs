using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class BusinessProcessRepositoryTests
    {
        private readonly Context _context;
        private readonly BusinessProcessRepository _businessProcessRepository;

        public BusinessProcessRepositoryTests()
        {
            _context = new Context();
            _businessProcessRepository = new BusinessProcessRepository(_context);
        }

        [Fact]
        public void GetAll()
        {
            var businessProcesses = _businessProcessRepository.GetAll();
            Assert.NotEmpty(businessProcesses);
        }

        [Fact]
        public void GetById()
        {
            int businessProcessId = 1;
            var businessProcess = _businessProcessRepository.GetById(businessProcessId);
            Assert.NotNull(businessProcess);
            Assert.Equal(businessProcess.Id, businessProcessId);
        }

        [Fact]
        public void GetByWorkCenter()
        {
            var workCenter = _context.WorkCenters.First();
            int workCenterId = workCenter.Id;
            var businessProcesses = _businessProcessRepository.GetByWorkCenter(workCenterId);
            Assert.NotEmpty(businessProcesses);
            Assert.All(businessProcesses, bp => Assert.Contains(bp.WorkCenterBusinessProcesses, wcbp => wcbp.WorkCenterId == workCenterId));
        }
    }
}