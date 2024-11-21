using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class StateRepositoryTests
    {
        private readonly Context _context;
        private readonly StateRepository _stateRepository;

        public StateRepositoryTests()
        {
            _context = new Context();
            _stateRepository = new StateRepository(_context);
        }

        [Fact]
        public void GetByDevice()
        {
            var device = _context.Devices.First();
            int deviceId = device.Id;
            var state = _stateRepository.GetByDevice(deviceId);
            Assert.NotNull(state);
            Assert.Equal(state.Device.Id, deviceId);
        }
    }
}