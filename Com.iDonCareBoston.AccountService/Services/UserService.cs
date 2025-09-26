using Com.iDonCareBoston.AccountService.Data;
using Com.iDonCareBoston.AccountService.Dtos;
using Com.iDonCareBoston.AccountService.Entities;
using Com.iDonCareBoston.AccountService.Repositories;

namespace Com.iDonCareBoston.AccountService.Services;

public interface IUserService
{
    Task Register(UserRegisterDto dto);
    Task<UserDto?> GetBy(string userId);
}

public class UserService(IUserRepository _userRepository, IUnitOfWork _uow) : IUserService
{
    public async Task Register(UserRegisterDto dto)
    {
        var user = new User
        {
            DisplayName = dto.DisplayName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow,
            Status = "active",
        };

        await _userRepository.CreateUser(user);
        _uow.Commit();
    }

    public async Task<UserDto?> GetBy(string userId)
    {
        var user = await _userRepository.GetBy(userId);
        if (user == null) return null;

        return new UserDto
        {
            UserId = user.UserId,
            DisplayName = user.DisplayName,
            Email = user.Email,
        };
    }

}