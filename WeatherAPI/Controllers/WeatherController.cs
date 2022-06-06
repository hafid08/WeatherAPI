using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IOpenWeather _openWeather;
        private readonly ILookupDataRetriever _lookupDataRetriever;
        public WeatherController(IOpenWeather openWeather, ILookupDataRetriever lookupDataRetriever)
        {
            _openWeather = openWeather;
            _lookupDataRetriever = lookupDataRetriever;
        }
        // GET: api/<WeatherController>
        [HttpGet("{city}")]
        public async Task<IActionResult> Get(string city)
        {
            if (string.IsNullOrEmpty(city))
                return Ok();
            var result = await _openWeather.GetWeather(city);
            return Ok(result);
        }
        [HttpGet("City/{country}")]
        public IActionResult GetCity(string country)
        {
            if (string.IsNullOrEmpty(country))
                return Ok();
            var result = _lookupDataRetriever.GetCities(country);
            return Ok(result);
        }
        [HttpGet("Country")]
        public IActionResult GetCountry()
        {
            var result = _lookupDataRetriever.GetCountries();
            return Ok(result);
        }
    }
}
