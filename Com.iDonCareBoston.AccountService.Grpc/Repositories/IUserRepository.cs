using Com.iDonCareBoston.AccountService.Grpc.Entities;

namespace Com.iDonCareBoston.AccountService.Grpc.Repositories;

public interface IUserRepository
{
    Task<Guid> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(Guid userId);
}
