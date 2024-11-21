using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class OpticalReaderRepositoryTests
    {
        private readonly Context _context;
        private readonly OpticalReaderRepository _opticalReaderRepository;

        public OpticalReaderRepositoryTests()
        {
            _context = new Context();
            _opticalReaderRepository = new OpticalReaderRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var opticalReader = new OpticalReader
            {
                DeviceId = 1,
            };
            var result = _opticalReaderRepository.Add(opticalReader);
            Assert.True(result);
        }

        [Fact]
        public void Delete()
        {
            var opticalReader = _context.OpticalReaders.First();
            var result = _opticalReaderRepository.Delete(opticalReader);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var opticalReaders = _opticalReaderRepository.GetAll();
            Assert.NotEmpty(opticalReaders);
        }
    }
}