using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class SIMCardRepositoryTests
    {
        private readonly Context _context;
        private readonly SIMCardRepository _simCardRepository;

        public SIMCardRepositoryTests()
        {
            _context = new Context();
            _simCardRepository = new SIMCardRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var simCard = new SIMCard
            {
                SerialNumber = "1234567890",
            };
            var result = _simCardRepository.Add(simCard);
            Assert.True(result);

        }

        [Fact]
        public void Delete()
        {
            var simCard = _context.SIMCards.First();
            int simCardId = simCard.Id;
            var result = _simCardRepository.Delete(simCardId);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var simCards = _simCardRepository.GetAll();
            Assert.NotEmpty(simCards);
        }

        [Fact]
        public void GetById()
        {
            int simCardId = 1;
            var simCard = _simCardRepository.GetById(simCardId);
            Assert.NotNull(simCard);
            Assert.Equal(simCard.Id, simCardId);
        }

        [Fact]
        public void GetByMobileDevice()
        {
            var mobileDevice = _context.MobileDevices.First();
            int mobileDeviceId = mobileDevice.Id;
            var simCard = _simCardRepository.GetByMobileDevice(mobileDeviceId);
            Assert.NotNull(simCard);
            Assert.Contains(simCard.MobileDevices, md => md.Id == mobileDeviceId);
        }

        [Fact]
        public void Update()
        {
            var simCard = _context.SIMCards.First();
            simCard.SerialNumber = "1234567890";
            var result = _simCardRepository.Update(simCard);
            Assert.True(result);
        }
    }
}