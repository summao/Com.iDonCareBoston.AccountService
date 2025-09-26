using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Com.iDonCareBoston.AccountService.Repositories;
using Com.iDonCareBoston.AccountService.Services.Grpc;
using Com.iDonCareBoston.AccountService.Entities;

namespace Com.iDonCareBoston.AccountService.Services;

public class UserGrpcService :  Grpc.UserService.UserServiceBase
{
    private readonly IUserRepository _userRepository;

    public UserGrpcService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<GetUserResponse> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var user = await _userRepository.GetBy(request.UserId) ?? throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        return new GetUserResponse
        {
            UserId = user.UserId.ToString(),
            Email = user.Email,
            Status = user.Status,
            CreatedAt = user.CreatedAt.ToTimestamp(),
        };
    }

    public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        var user = new User
        {
            UserId = Guid.NewGuid(),
            DisplayName = "", // TODO เอาจาก request มาใส่
            PasswordHash = "",
            Email = request.Email,
            Status = string.IsNullOrEmpty(request.Status) ? "active" : request.Status,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.CreateUser(user);

        return new CreateUserResponse
        {
            UserId = user.UserId.ToString()
        };
    }
}
