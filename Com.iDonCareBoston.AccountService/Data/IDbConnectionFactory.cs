using System.Data;

namespace Com.iDonCareBoston.AccountService.Data;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}