using System.Data;
using Npgsql;

namespace Com.iDonCareBoston.AccountService.Grpc.Data;

public class NpgsqlConnectionWrapper : IDbConnectionWrapper
{
    private NpgsqlConnection? _connection;
    private bool _disposed = false;

    public NpgsqlConnectionWrapper(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public IDbConnection Connection => _connection!;

    ~NpgsqlConnectionWrapper()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _connection?.Close();
            _connection?.Dispose();
        }

        _disposed = true;
        _connection = null;
    }
}

