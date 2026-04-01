using System.Text.Json;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(9, 0, 0));

builder.Services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
    dbContextOptions.UseMySql(connectionString, serverVersion)
        // Additional Pomelo-specific options can be chained here
        .LogTo(Console.WriteLine, LogLevel.Information) // Log SQL queries to console
        .EnableSensitiveDataLogging() // Include sensitive app data in logs (useful for debugging)
        .EnableDetailedErrors() // Provide more detailed errors
);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();


app.MapControllers();

app.UseCors("AllowAll");

app.Run();
