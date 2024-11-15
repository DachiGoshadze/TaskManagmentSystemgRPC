using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TasksManagmentService.Controllers;
using TasksManagmentService.Data;
using TasksManagmentService.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddGrpc();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuer = true,
         
            ValidIssuer = AuthOptions.ISSUER,
      
            ValidateAudience = true,

            ValidAudience = AuthOptions.AUDIENCE,

            ValidateLifetime = true,
 
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
          
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<SpaceService>();
var app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<ControllerService>();
// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();

public static class AuthOptions
{
    public const string ISSUER = "TaskManagementSystemGrpc"; 
    public const string AUDIENCE = "TaskManagementSystemGrpcClient"; 
    const string KEY = "mysupersecret_secretsecretsecretkey!123";  
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}