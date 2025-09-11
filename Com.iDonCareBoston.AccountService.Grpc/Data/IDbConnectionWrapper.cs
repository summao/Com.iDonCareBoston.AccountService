namespace Com.iDonCareBoston.AccountService.Grpc.Data;

using System.Data;

public interface IDbConnectionWrapper : IDisposable
{
    IDbConnection Connection { get; }
}
