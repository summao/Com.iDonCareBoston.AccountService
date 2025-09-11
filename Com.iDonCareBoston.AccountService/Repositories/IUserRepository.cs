using Com.iDonCareBoston.AccountService.Entities;

namespace Com.iDonCareBoston.AccountService.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
}
