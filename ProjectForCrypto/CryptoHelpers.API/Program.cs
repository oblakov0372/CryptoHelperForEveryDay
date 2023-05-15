using ApplicationService.implementations.CryptoTracker.Portfolio;
using ApplicationService.implementations.CryptoTracker.PortfolioTokenManagement;
using ApplicationService.implementations.CryptoTracker.TransactionManagement;
using ApplicationService.implementations.TradeFututreManagement;
using ApplicationService.implementations.UserManagement;
using Contracts;
using CryptoCollector.API;
using CryptoHelpers.API.JWT;
using Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });
builder.Services.AddAuthorization();

#region Services
var jwtSettings = new JwtSettings
{
    SecretKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey"),
    Issuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer"),
    Audience = builder.Configuration.GetValue<string>("JwtSettings:Audience"),
    ExpiresInMinutes = builder.Configuration.GetValue<int>("JwtSettings:ExpiresInMinutes"),
};

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddScoped<IJwtAuthenticationManager, JwtAuthenticationManager>();
builder.Services.AddScoped<ProjectDBContext>();
builder.Services.AddScoped<ITradeFutureManagementService, TradeFutureManagementService>();
builder.Services.AddScoped<IUserManagementService, UserManagementService>();
builder.Services.AddScoped<IPortfolioManagementService,PortfolioManagementService>();
builder.Services.AddScoped<ITransactionManagementService, TransactionManagementService>();
builder.Services.AddScoped<IPortfolioTokenManagementService,PortfolioTokenManagementService>();
builder.Services.AddScoped<ICryptoCollectorManagementService,CryptoCollectorManagementService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

#endregion


#region CORS
builder.Services.AddCors(options =>
{
    // this defines a CORS policy called "default"
    options.AddPolicy("default", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
