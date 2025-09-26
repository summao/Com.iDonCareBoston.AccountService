using Com.iDonCareBoston.AccountService.Entities;

namespace Com.iDonCareBoston.AccountService.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateUser(User user);
    Task<User?> GetBy(string userId);
}
