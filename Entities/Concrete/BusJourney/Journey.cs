using System.Text.Json.Serialization;

namespace Entities.Concrete.BusJourney
{
    public class Journey
    {
        public string Kind { get; set; }
        public string Code { get; set; }
        public JourneyStop Stops { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public TimeSpan Duration { get; set; }

        [JsonPropertyName("original-price")]
        public string OriginalPrice { get; set; }

        [JsonPropertyName("internet-price")]
        public int InternetPrice { get; set; }
        public string Booking { get; set; }
        public string BusName { get; set; }
        public Policy Policy { get; set; }
        public List<string> Features { get; set; }
        public string Description { get; set; }
        public bool? Available { get; set; }

    }
}