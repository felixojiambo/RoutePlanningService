using System.Net.Http;
using System.Threading.Tasks;
using RoutePlanningService.Models;
using Newtonsoft.Json;
namespace RoutePlanningService.Services
{
    public class GoogleMapsService : IGoogleMapsService
    {
        private readonly string _apiKey;

        public GoogleMapsService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<RouteResponse> GetRouteAsync(string origin, string destination)
        {
            var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={origin}&destination={destination}&key={_apiKey}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                var route = JsonConvert.DeserializeObject<RouteResponse>(response);
                return route;
            }
        }
    }
}