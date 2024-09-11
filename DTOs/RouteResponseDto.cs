using RoutePlanningService.Models;

namespace RoutePlanningService.DTOs
{
    public class RouteResponseDto
    {
        public RouteResponse Route { get; set; }
        public double EnergyConsumed { get; set; }
    }
}
