using System.Data;
using SGDM_CFE.DataAccess;

namespace SGDM_CFE.Tests.UnitTests.DataAccess
{
    [TestFixture]
    public class DatabaseConnectionTests
    {
        private DatabaseConnection _databaseConnection;

        [SetUp]
        public void SetUp()
        {
            _databaseConnection = new DatabaseConnection();
        }

        [Test]
        public void GetConnection()
        {
            using var sqlConnection = _databaseConnection.GetConnection();
            Assert.That(sqlConnection, Is.Not.Null);
            Assert.That(sqlConnection.State, Is.EqualTo(ConnectionState.Open));
        }
    }
}