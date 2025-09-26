namespace Com.iDonCareBoston.AccountService.Repositories;

using Com.iDonCareBoston.AccountService.Data;
using Com.iDonCareBoston.AccountService.Entities;
using Dapper;

public class UserRepository(IUnitOfWork _uow) : IUserRepository
{
    public async Task<Guid> CreateUser(User user)
    {
        const string sql =
            @"INSERT INTO users (user_id, email, status, created_at)
              VALUES (@UserId, @Email, @Status, @CreatedAt) 
              RETURNING id;";
        return await _uow.Connection.ExecuteScalarAsync<Guid>(sql, user, _uow.Transaction);
    }

    public async Task<User?> GetBy(string userId)
    {
        Guid id = Guid.Parse(userId);
        const string sql = "SELECT * FROM users WHERE user_id = @Id";
        return await _uow.Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id }, _uow.Transaction);
    }
}
