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
    }
}