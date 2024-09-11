using Microsoft.EntityFrameworkCore;
using RoutePlanningService.Models;
namespace RoutePlanningService.Data
{
    public class TripRepository : ITripRepository
    {
        private readonly TripContext _context;

        public TripRepository(TripContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsByUserId(string userId)
        {
            return await _context.Trips.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Trip> GetTripById(int id)
        {
            return await _context.Trips.FindAsync(id);
        }

        public async Task AddTrip(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
