using System.Data;

namespace Com.iDonCareBoston.AccountService.Grpc.Data;

public class UnitOfWork(IDbConnectionWrapper _connectionWrapper) : IUnitOfWork
{
    public IDbConnection Connection { get; } = _connectionWrapper.Connection;

    public void Dispose()
    {
        _connectionWrapper.Dispose();
    }
}
