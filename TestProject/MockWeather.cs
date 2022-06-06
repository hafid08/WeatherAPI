using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService;

namespace TestProject
{
    public class MockWeather
    {
        private readonly string _city;
        private readonly IOpenWeather _service;
        public MockWeather(string city, IOpenWeather service)
        {
            _city = city;
            _service = service;
        }
        public WeatherModel Weather { get; private set; }
        public async Task Refresh()
        {
            Weather = await Task.Run(() => _service.GetWeather(_city));
        }
    }
}
