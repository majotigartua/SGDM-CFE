using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class MobileDeviceRepositoryTests
    {
        private readonly Context _context;
        private readonly MobileDeviceRepository _mobileDeviceRepository;

        public MobileDeviceRepositoryTests()
        {
            _context = new Context();
            _mobileDeviceRepository = new MobileDeviceRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var mobileDevice = new MobileDevice
            {
                TypeId = 1,
                DeviceId = 1,
                SIMCardId = 1
            };
            var result = _mobileDeviceRepository.Add(mobileDevice);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var mobileDevice = _context.MobileDevices.First();
            var result = _mobileDeviceRepository.Delete(mobileDevice);
            Assert.True(result);
        }

        [Fact]
        public void GetBySIMCard()
        {
            var simCard = _context.SIMCards.First();
            int simCardId = simCard.Id;
            var mobileDevice = _mobileDeviceRepository.GetBySIMCard(simCardId);
            Assert.NotNull(mobileDevice);
            Assert.Equal(mobileDevice.SIMCardId, simCardId);
        }

        [Fact]
        public void GetByType()
        {
            var type = _context.Types.First();
            int typeId = type.Id;
            var mobileDevices = _mobileDeviceRepository.GetByType(typeId);
            Assert.NotEmpty(mobileDevices);
            Assert.All(mobileDevices, md => Assert.Equal(md.TypeId, typeId));
        }

        [Fact]
        public void Update()
        {
            var mobileDevice = _context.MobileDevices.First();
            mobileDevice.SIMCardId = 1;
            var result = _mobileDeviceRepository.Update(mobileDevice);
            Assert.True(result);
        }
    }
}