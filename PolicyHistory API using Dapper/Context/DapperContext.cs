using Microsoft.Data.SqlClient;
using System.Data;

namespace PolicyHistory_API_using_Dapper.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("dbcs");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
