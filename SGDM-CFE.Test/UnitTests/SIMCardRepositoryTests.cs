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
            var result = _simCardRepository.Delete(simCard);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var simCards = _simCardRepository.GetAll();
            Assert.NotEmpty(simCards);
        }

        [Fact]
        public void GetByMovileDevice()
        {
            var simCard = _context.SIMCards.First();
            var simCardId = simCard.Id;
            var result = _simCardRepository.GetByMobileDevice(simCardId);
            Assert.NotNull(result);
            Assert.Equal(result.Id, simCardId);
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