using System.Collections.Generic;

namespace RoutePlanningService.Models
{
    public class RouteResponse
    {
        public string Status { get; set; } = string.Empty;
        public List<Route> Routes { get; set; } = new List<Route>();
    }

    public class Route
    {
        public List<Leg> Legs { get; set; } = new List<Leg>();
    }

    public class Leg
    {
        public Distance Distance { get; set; } = new Distance();
        public Duration Duration { get; set; } = new Duration();
    }

    public class Distance
    {
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class Duration
    {
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }
    }
}
