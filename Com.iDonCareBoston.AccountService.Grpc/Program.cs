using Com.iDonCareBoston.AccountService.Grpc.Data;
using Com.iDonCareBoston.AccountService.Grpc.Repositories;
using Com.iDonCareBoston.AccountService.Grpc.Services;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();          

string connectionString = "Host=localhost;Port=5432;Username=myuser;Password=mypassword;Database=accountdb";
DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
    });
});
builder.Services.AddScoped<IDbConnectionWrapper>(_ => new NpgsqlConnectionWrapper(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();


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
