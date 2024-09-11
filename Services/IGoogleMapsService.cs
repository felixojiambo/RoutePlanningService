using RoutePlanningService.Models;

namespace RoutePlanningService.Services
{
    public interface IGoogleMapsService
    {
        Task<RouteResponse> GetRouteAsync(string origin, string destination);
    }
}
