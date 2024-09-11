using RoutePlanningService.DTOs;
using RoutePlanningService.Models;
namespace RoutePlanningService.Services
{
    public interface IRoutePlanService
    { 
    Task<RouteResponseDto> PlanRoute(RouteRequestDto request);
    Task<IEnumerable<Trip>> GetTripHistory(string userId);
}
}
