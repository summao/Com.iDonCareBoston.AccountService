namespace Com.iDonCareBoston.AccountService.Grpc.Entities;

public class User
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = "";
    public string Status { get; set; } = "active";
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
}