namespace Com.iDonCareBoston.AccountService.Grpc.Entities;

public class UserProfile
{
    public Guid UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
}
