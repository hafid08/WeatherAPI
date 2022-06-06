using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestProject;
using WeatherService;

namespace WeatherTest
{
    public class Tests
    {
        private readonly string _path = Directory.GetCurrentDirectory();
        public Tests()
        {
            GlobalVar.CityList = "city.list.json";
            GlobalVar.CountryList = "country.list.json";
            GlobalVar.Url = "https://api.openweathermap.org/data/2.5/weather";
            GlobalVar.ApiKey = "751bb75210c92e4ccddd81e4a311d78a";
        }
        [Test]
        public void TestCheckFileCountry()
        {
            
            string pathCountry = Path.Combine(_path, GlobalVar.CountryList);
            Assert.AreEqual(true, File.Exists(pathCountry));
        }
        [Test]
        public void TestGetCountries()
        {
            var expectedCountries = new List<CountryModel>() { new CountryModel() { Name = "Indonesia", Code = "ID" } };
            var serviceMock = new Mock<ILookupDataRetriever>();
            serviceMock.Setup(c => c.GetCountries())
                    .Returns(expectedCountries)
                    .Verifiable();

            var sut = new MockCountry(serviceMock.Object);
            sut.Refresh();
            serviceMock.Verify();

            Assert.AreEqual(expectedCountries.Count, sut.Countries.Count);
        }
        [Test]
        public void TestCheckFileCity()
        {
            string pathCity = Path.Combine(_path, GlobalVar.CityList);
            Assert.AreEqual(true, File.Exists(pathCity));
        }
        [Test]
        public void TestGetCities()
        {
            var expectedCities = new List<CityModel>() { new CityModel() { Name = "Tiku", Country = "ID" } };
            var expectedCountry = "ID";
            var serviceMock = new Mock<ILookupDataRetriever>();
            serviceMock.Setup(c => c.GetCities(expectedCountry))
                    .Returns(expectedCities)
                    .Verifiable();

            var sut = new MockCity(expectedCountry, serviceMock.Object);
            sut.Refresh();
            serviceMock.Verify();

            Assert.AreEqual(expectedCities.Count, sut.Cities.Count);
        }
        
        [Test]
        public async Task TestGetWeather()
        {
            var expectedWeather = new WeatherModel() { Id = 1650357 };
            var expectedCity = "Bandung";
            var serviceMock = new Mock<IOpenWeather>();
            serviceMock.Setup(c => c.GetWeather(expectedCity))
                    .Returns(Task.FromResult(expectedWeather))
                    .Verifiable();

            var sut = new MockWeather(expectedCity, serviceMock.Object);
            await Task.Run(() => sut.Refresh());
            serviceMock.Verify();

            Assert.AreEqual(expectedWeather.Id, sut.Weather.Id);
        }
    }
}