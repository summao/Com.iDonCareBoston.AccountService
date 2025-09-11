using System.Data;

namespace Com.iDonCareBoston.AccountService.Grpc.Data;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}