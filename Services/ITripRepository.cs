using RoutePlanningService.Models;

namespace RoutePlanningService.Data
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> GetTripsByUserId(string userId);
        Task<Trip> GetTripById(int id);
        Task AddTrip(Trip trip);
        Task SaveChanges();
    }
}
