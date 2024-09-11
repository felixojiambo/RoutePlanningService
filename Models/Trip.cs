namespace RoutePlanningService.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime TripDate { get; set; }
        public double Distance { get; set; }
        public double EnergyConsumed { get; set; }
    }
}
