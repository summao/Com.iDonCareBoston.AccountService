namespace Com.iDonCareBoston.AccountService.Errors;

public class ApiError
{
    public string Message { get; set; } = default!;
    public string Type { get; set; } = default!;
    public object Details { get; set; } = default!;
}