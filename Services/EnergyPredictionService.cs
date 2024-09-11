using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace RoutePlanningService.Services
{
    public class EnergyPredictionService
    {
        private readonly HttpClient _httpClient;

        public EnergyPredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> PredictEnergyConsumption(double distance)
        {
            var response = await _httpClient.PostAsJsonAsync("http://ml-service/api/predict-energy", new { Distance = distance });
            var result = await response.Content.ReadFromJsonAsync<PredictionResult>();
            return result?.EnergyConsumed ?? 0;
        }
    }

    public class PredictionResult
    {
        public double EnergyConsumed { get; set; }
    }
}
