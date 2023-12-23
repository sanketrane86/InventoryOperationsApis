using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryOperationsApis.Repositories
{
    public class BaseConnectionRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public BaseConnectionRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._connectionstring = this._configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
