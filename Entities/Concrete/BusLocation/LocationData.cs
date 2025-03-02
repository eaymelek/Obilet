using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete.BusLocation
{
    public class LocationData
    {
        public int Id { get; set; }

        [JsonPropertyName("parent-id")]
        public int ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonPropertyName("tz-code")]
        public string TzCode { get; set; }

        [JsonPropertyName("weather-code")]
        public string WeatherCode { get; set; }
        public int Rank { get; set; }

        [JsonPropertyName("reference-code")]
        public string ReferenceCode { get; set; }
        public string Keywords { get; set; }
    }
}
