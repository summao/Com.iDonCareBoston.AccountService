namespace Com.iDonCareBoston.AccountService.Dtos;

public class UserRegisterDto
{
    public string DisplayName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}