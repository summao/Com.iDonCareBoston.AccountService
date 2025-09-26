using Microsoft.AspNetCore.Mvc;
using Com.iDonCareBoston.AccountService.Services;
using Com.iDonCareBoston.AccountService.Errors;

namespace Com.iDonCareBoston.AccountService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService _userService) : ControllerBase
{
    // [HttpPost("register")]
    // public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    // {
       
    //     // await _uow.CommitAsync();

    //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    // }

    // GET api/users/abc
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        var user = await _userService.GetBy(userId.ToString());
        if (user == null)
            return NotFound(new ApiError
            {
                Message = "user not found"
            });

        return Ok(user);
    }
}