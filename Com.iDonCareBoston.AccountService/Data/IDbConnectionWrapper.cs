namespace Com.iDonCareBoston.AccountService.Data;

using System.Data;

public interface IDbConnectionWrapper : IDisposable
{
    IDbConnection Connection { get; }
}
