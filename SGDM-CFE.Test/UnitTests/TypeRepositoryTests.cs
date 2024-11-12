using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.Test.UnitTests
{
    public class TypeRepositoryTests
    {
        private readonly Context _context;
        private readonly TypeRepository _typeRepository;

        public TypeRepositoryTests()
        {
            _context = new Context();
            _typeRepository = new TypeRepository(_context);
        }

        [Fact]
        public void GetAll()
        {
            var types = _typeRepository.GetAll();
            Assert.NotNull(types);
        }

        [Fact]
        public void GetById()
        {
            var type = _typeRepository.GetById(1);
            Assert.NotNull(type);
        }

        [Fact]
        public void GetByMobileDevice()
        {
            var mobileDevice = _context.MobileDevices.First();
            int mobileDeviceId = mobileDevice.Id;
            var type = _typeRepository.GetByMobileDevice(mobileDeviceId);
            Assert.NotNull(type);
            Assert.Contains(type.MobileDevices, md => md.Id == mobileDeviceId);
        }
    }
}