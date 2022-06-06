using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherService
{
    public class OpenWeather : IOpenWeather
    {
        private readonly string _apiKey;
        private readonly string _url;
        private readonly HttpClient _client;
        public OpenWeather()
        {
            _client = new HttpClient();
            _apiKey = GlobalVar.ApiKey;
            _url = GlobalVar.Url;
        }
        public async Task<WeatherModel> GetWeather(string city)
        {
            WeatherModel weather = new WeatherModel();
            HttpResponseMessage response = await _client.GetAsync(_url + $"?q={city}&appid={_apiKey}");
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                weather = JsonConvert.DeserializeObject<WeatherModel>(responseBody);
            }
            return weather;
        }
    }
}
