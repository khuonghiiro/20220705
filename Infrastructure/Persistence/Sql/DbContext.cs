using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Persistence.Sql;

public class DbContext
{
    private readonly string _connectionString;
    public DbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
