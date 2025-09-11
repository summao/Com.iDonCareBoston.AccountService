using System.Data;

namespace Com.iDonCareBoston.AccountService.Data;

public interface IUnitOfWork : IDisposable
{
    IDbConnection Connection { get; }
}
