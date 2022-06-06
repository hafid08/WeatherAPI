using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService
{
    public class WeatherModel
    {
        public CoordModel Coord { get; set; }
        public List<WeatherItem> Weather { get; set; }
        public string Base { get; set; }
        public WeatherMain Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public DateTime DateTime { 
            get {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(1654535199);
                return dateTimeOffset.DateTime;
            } 
        }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

    }

    public class CoordModel
    {
        public decimal Lon { get; set; }
        public decimal Lat { get; set; }
    }
    public class WeatherItem 
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class WeatherMain 
    {
        public decimal Temp { get; set; }
        public decimal Celcius {
            get
            {
                return Temp - 273.15M;
            }
        }
        public decimal Fahrenheit {
            get
            {
                return (Celcius * (9M / 5M)) + 32M;
            }
        }
        [JsonProperty("feels_like")]
        public decimal FeelsLike { get; set; }
        [JsonProperty("temp_min")]
        public decimal TempMin { get; set; }
        [JsonProperty("temp_max")]
        public decimal TempMax { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        [JsonProperty("sea_level")]
        public decimal SeaLevel { get; set; }
        [JsonProperty("grnd_level")]
        public decimal GrndLevel { get; set; }
    }
    public class Wind
    {
        public decimal Speed { get; set; }
        public decimal Deg { get; set; }
        public decimal Gust { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Sys 
    {
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}
