using Npgsql;
using System.Data;

namespace Com.iDonCareBoston.AccountService.Data;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public class NpgsqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}

