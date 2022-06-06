using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public interface IOpenWeather
    {
        Task<WeatherModel> GetWeather(string city);
    }
}
