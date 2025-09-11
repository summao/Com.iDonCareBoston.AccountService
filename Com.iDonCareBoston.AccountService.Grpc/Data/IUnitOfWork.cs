using System.Data;

namespace Com.iDonCareBoston.AccountService.Grpc.Data;

public interface IUnitOfWork : IDisposable
{
    IDbConnection Connection { get; }
}
