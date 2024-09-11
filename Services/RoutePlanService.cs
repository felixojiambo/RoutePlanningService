using RoutePlanningService.Data;
using RoutePlanningService.DTOs;
using RoutePlanningService.Models;

namespace RoutePlanningService.Services
{
    public class RoutePlanService : IRoutePlanService
    {
        private readonly IGoogleMapsService _googleMapsService;
        private readonly ITripRepository _tripRepository;
        private readonly EnergyPredictionService _energyPredictionService;

        public RoutePlanService(IGoogleMapsService googleMapsService, ITripRepository tripRepository, EnergyPredictionService energyPredictionService)
        {
            _googleMapsService = googleMapsService;
            _tripRepository = tripRepository;
            _energyPredictionService = energyPredictionService;
        }

        public async Task<RouteResponseDto> PlanRoute(RouteRequestDto request)
        {
            // Call Google Maps API
            var route = await _googleMapsService.GetRouteAsync(request.Origin, request.Destination);

            // Predict energy consumption
            var energyConsumed = await _energyPredictionService.PredictEnergyConsumption(route.Routes.First().Legs.First().Distance.Value);

            // Save the trip
            var trip = new Trip
            {
                UserId = request.UserId,
                Origin = request.Origin,
                Destination = request.Destination,
                TripDate = DateTime.Now,
                Distance = route.Routes.First().Legs.First().Distance.Value,
                EnergyConsumed = energyConsumed
            };

            await _tripRepository.AddTrip(trip);
            await _tripRepository.SaveChanges();

            // Return response
            return new RouteResponseDto
            {
                Route = route,
                EnergyConsumed = energyConsumed
            };
        }

        public async Task<IEnumerable<Trip>> GetTripHistory(string userId)
        {
            return await _tripRepository.GetTripsByUserId(userId);
        }
    }
}
