using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTOs.Concrete
{
    public class BusJourneyRequest : ApiRequest
    {
        [JsonPropertyName("data")]
        public BusSearchData Data { get; set; }
    }

    public class BusSearchData
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }

        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
    public class BusJourneyResponse : ApiResponse
    {
        [JsonPropertyName("data")]
        public List<JourneyData> Data { get; set; }

    }
}
