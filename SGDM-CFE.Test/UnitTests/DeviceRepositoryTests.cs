using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class DeviceRepositoryTests
    {
        private readonly Context _context;
        private readonly DeviceRepository _deviceRepository;

        public DeviceRepositoryTests()
        {
            _context = new Context();
            _deviceRepository = new DeviceRepository(_context);
        }

        [Fact]
        public void GetByWorkCenter()
        {
            var workCenter = _context.WorkCenters.First();
            int workCenterId = workCenter.Id;
            var device = _deviceRepository.GetByWorkCenter(workCenterId);
            Assert.NotEmpty(device);
            Assert.All(device, d => Assert.Equal(d.WorkCenterId, workCenterId));
        }
    }
}