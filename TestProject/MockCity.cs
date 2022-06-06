using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService;

namespace TestProject
{
    public class MockCity
    {
        private readonly string _country;
        private readonly ILookupDataRetriever _service;
        public MockCity(string country, ILookupDataRetriever service)
        {
            _country = country;
            _service = service;
        }
        public List<CityModel> Cities { get; private set; }
        public void Refresh()
        {
            Cities = _service.GetCities(_country);
        }
    }
}
