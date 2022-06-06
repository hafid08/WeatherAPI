using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherService
{
    public class LookupDataRetriever : ILookupDataRetriever
    {
        public List<CityModel> GetCities(string country)
        {
            List<CityModel> cities = new List<CityModel>();
            string fileCity = Path.Combine(Directory.GetCurrentDirectory(), GlobalVar.CityList);
            if (File.Exists(fileCity))
            {
                string json = File.ReadAllText(fileCity);
                cities = JsonConvert.DeserializeObject<List<CityModel>>(json).FindAll(x => x.Country == country);
            }
            return cities;
        }

        public List<CountryModel> GetCountries()
        {
            List<CountryModel> countries = new List<CountryModel>();
            string fileCountry = Path.Combine(Directory.GetCurrentDirectory(), GlobalVar.CountryList);
            if (File.Exists(fileCountry))
            {
                string json = File.ReadAllText(fileCountry);
                countries = JsonConvert.DeserializeObject<List<CountryModel>>(json);
            }
            return countries.FindAll(x=> new string[] { "ID", "AC" }.Contains(x.Code));
        }
    }
    public class CityModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
    public class CountryModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
