using System.Threading.Tasks;
using Com.iDonCareBoston.AccountService.Data;
using Com.iDonCareBoston.AccountService.Dtos;
using Com.iDonCareBoston.AccountService.Entities;
using Com.iDonCareBoston.AccountService.Repositories;
using Com.iDonCareBoston.AccountService.Services;
using FluentAssertions;
using Moq;

namespace Com.iDonCareBoston.AccountService.Test.Services;

public class UserServiceTest
{
    private readonly UserService _service;

    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    public UserServiceTest()
    {
        _mockUserRepository = new();
        _mockUnitOfWork = new();
        _service = new(_mockUserRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task GetBy_ShouldMapCorrectly()
    {
        // Given
        var mockUserId = Guid.Empty;
        var mockUser = Mock.Of<User>(a =>
            a.UserId == mockUserId
            && a.DisplayName == "DisplayName"
            && a.Email == "Email"
        );
        _mockUserRepository.Setup(a => a.GetBy(It.IsAny<string>()))
            .ReturnsAsync(mockUser);

        // When
        var result = await _service.GetBy("");

        // Then
        var expected = new UserDto
        {
            UserId = mockUserId,
            DisplayName = "DisplayName",
            Email = "Email",
        };

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expected);
    }
}