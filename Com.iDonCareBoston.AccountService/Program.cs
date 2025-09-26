
using Com.iDonCareBoston.AccountService.Data;
using Com.iDonCareBoston.AccountService.Repositories;
using Com.iDonCareBoston.AccountService.Services;
using Dapper;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Host=localhost;Port=5432;Username=myuser;Password=mypassword;Database=accountdb";
DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http1);
    options.ListenLocalhost(5001, o => o.Protocols = HttpProtocols.Http2); 
});
builder.Services.AddScoped<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGrpcService<UserGrpcService>();
app.MapControllers();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
