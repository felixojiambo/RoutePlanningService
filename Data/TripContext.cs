using Microsoft.EntityFrameworkCore;
using RoutePlanningService.Models;

namespace RoutePlanningService.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options)
        {
        }

        public DbSet<Trip> Trips { get; set; }
    }
}
