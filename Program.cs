using Microsoft.EntityFrameworkCore;
using RoutePlanningService.Data;
using RoutePlanningService.Services;
using Npgsql;
using Microsoft.OpenApi.Models;
using RoutePlanningService.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<TripContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IRoutePlanService, RoutePlanService>();
builder.Services.AddScoped<IGoogleMapsService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var apiKey = configuration["GoogleMapsApiKey"];
    return new GoogleMapsService(apiKey);
});

builder.Services.AddHttpClient<EnergyPredictionService>();

builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Route Planning API",
        Version = "1.0.0",
        Description = "API for planning routes and trips"
    });

    c.SchemaFilter<EnumSchemaFilter>();
});

var app = builder.Build();

// Enable Swagger and Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Route Planning API v1");
    c.RoutePrefix = "swagger-ui";  // Swagger UI will be accessible at /swagger-ui/
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
