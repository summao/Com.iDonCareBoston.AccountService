namespace Com.iDonCareBoston.AccountService.Repositories;

using Com.iDonCareBoston.AccountService.Data;
using Com.iDonCareBoston.AccountService.Entities;
using Dapper;

public class UserRepository(IUnitOfWork unitOfWork) : IUserRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> CreateUserAsync(User user)
    {
        const string sql = @"INSERT INTO users (user_id, email, status, created_at)
                             VALUES (@UserId, @Email, @Status, @CreatedAt)";
        await _unitOfWork.Connection.ExecuteAsync(sql, user);
        return user.UserId;
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        const string sql = "SELECT * FROM users WHERE user_id = @Id";
        return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = userId });
    }
}
