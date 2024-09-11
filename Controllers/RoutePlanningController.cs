using Microsoft.AspNetCore.Mvc;
using RoutePlanningService.DTOs;
using RoutePlanningService.Services;

namespace RoutePlanningService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutePlanningController : ControllerBase
    {
        private readonly IRoutePlanService _routePlanningService;

        public RoutePlanningController(IRoutePlanService routePlanningService)
        {
            _routePlanningService = routePlanningService;
        }

        [HttpPost("plan")]
        public async Task<IActionResult> PlanRoute([FromBody] RouteRequestDto request)
        {
            var response = await _routePlanningService.PlanRoute(request);
            return Ok(response);
        }

        [HttpGet("history/{userId}")]
        public async Task<IActionResult> GetTripHistory(string userId)
        {
            var trips = await _routePlanningService.GetTripHistory(userId);
            return Ok(trips);
        }
    }
}
