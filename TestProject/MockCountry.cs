using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService;

namespace TestProject
{
    public class MockCountry
    {
        private readonly ILookupDataRetriever _service;
        public MockCountry(ILookupDataRetriever service)
        {
            _service = service;
        }
        public List<CountryModel> Countries { get; private set; }
        public void Refresh()
        {
            Countries = _service.GetCountries();
        }
    }
}
