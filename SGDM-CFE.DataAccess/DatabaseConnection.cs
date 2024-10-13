using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using SGDM_CFE.DataAccess;

namespace SGDM_CFE.DataAccess
{
    public class DatabaseConnection
    {
        private readonly string? _connectionString;

        public DatabaseConnection()
        {
            string solutionPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\.."));
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(solutionPath, "SGDM-CFE.DataAccess"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}