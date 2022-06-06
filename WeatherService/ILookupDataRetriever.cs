using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService
{
    public interface ILookupDataRetriever
    {
        List<CityModel> GetCities(string country);
        List<CountryModel> GetCountries();
    }
}
