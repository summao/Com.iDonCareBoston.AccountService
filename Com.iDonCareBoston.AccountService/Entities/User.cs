namespace Com.iDonCareBoston.AccountService.Entities;

public class User
{
    public Guid UserId { get; set; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public required string PasswordHash { get; set; }
    public required string Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
}