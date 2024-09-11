using Microsoft.EntityFrameworkCore;
using RoutePlanningService.Data;
using RoutePlanningService.Services;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// 1. Add the Database Context (SQL Server or PostgreSQL)
builder.Services.AddDbContext<TripContext>(options =>
{
    // Use SQL Server
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

    // If you are using PostgreSQL, replace the line above with this one:
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 2. Register custom services and repositories
builder.Services.AddScoped<ITripRepository, TripRepository>(); // Repository for trip management
builder.Services.AddScoped<IRoutePlanService, RoutePlanService>(); // Route planning business logic
builder.Services.AddScoped<IGoogleMapsService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var apiKey = configuration["GoogleMapsApiKey"]; // Reading Google Maps API Key from appsettings.json
    return new GoogleMapsService(apiKey);
});

// 3. Add HttpClient for external API calls (EnergyPredictionService)
builder.Services.AddHttpClient<EnergyPredictionService>();

// Add Controllers and API documentation
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
